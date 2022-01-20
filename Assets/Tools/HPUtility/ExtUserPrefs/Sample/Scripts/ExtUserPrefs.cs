using System.IO;
using UnityEngine;

namespace HKUtility
{
    /// <summary>
    /// UserPrefsの拡張版。設定データ等の情報を保存、読み出しできます。
    /// データは、Json形式で管理されます。
    /// 暗号化、復号化機能も備わっています。
    /// </summary>
    public static class ExtUserPrefs
    {
        /// <summary>
        /// Application.persistentDataPathの各プラットフォーム保存場所
        /// IOS Application/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/Documents
        /// Android /data/data/xxx.xxx.xxx/files
        /// Windows C:/Users/xxxx/AppData/LocalLow/CompanyName/ProductName
        /// Mac /Users/xxxx/Library/Application Support/CompanyName/Product Name
        /// </summary>
        static readonly string path = Application.persistentDataPath;

        /// <summary>
        /// 定義されたクラスで、データを平文または暗号化保存します
        /// </summary>
        /// <returns>JSon変換データ。エラーの場合、null</returns>
        /// <param name="obj">保存するインスタンス名</param>
        /// <param name="fileName">保存するファイル名(平文の場合、自動で拡張子.jsonが付加されます）</param>
        /// <param name="PASS">暗号化パスワード：省略すると、Json平文で保存</param>
        /// <typeparam name="T">保存するクラス型</typeparam>
        public static string Save<T>(T obj, string fileName, string PASS = null)
        {
            string json;
            try
            {
                // 保存データをJsonへ変換
                json = JsonUtility.ToJson(obj, true);

                if (PASS == null)
                {
                    fileName = fileName.Contains(".json") ? fileName : fileName += ".json";
                }

                // 絶対パスの取得
                var conbined = Path.Combine(path, fileName);
                // 暗号化
                var encJson = PASS == null ? json : Encryption.EncryptString(json, PASS);
                // 保存
                File.WriteAllText(conbined, encJson);
            }
            catch (System.Exception ex)
            {
                Debug.LogError("データの保存でエラーが発生" + ex);
                return null;
            }
            return json;
        }

        /// <summary>
        /// 定義されたクラスで、平文、または暗号化されたデータを読み出します。
        /// </summary>
        /// <returns>平文、または復号化されたデータ.なければ、null</returns>
        /// <param name="fileName">読み出すファイル名(平文の場合、自動で拡張子.jsonが付加されます）</param>
        /// <param name="PASS">暗号化パスワード：省略すると、Json平文で保存</param>
        /// <typeparam name="T">読み出すクラス型</typeparam>
        public static T Load<T>(string fileName, string PASS = null)
        {
            T saveData;

            try
            {
                string readJson = LoadBase(ref fileName, PASS);

                // 復号化
                var decJson = PASS == null ? readJson : Encryption.DecryptString(readJson, PASS);

                // Jsonデータをオブジェクトへ変換
                saveData = JsonUtility.FromJson<T>(decJson);
            }
            catch (System.Exception ex)
            {
                Debug.LogError("データの読み出しでエラーが発生" + ex);
                return default;
            }

            return saveData;
        }


        /// <summary>
        /// スクリプタブルオブジェクト。定義されたクラスで、平文、または暗号化されたデータを読み出します
        /// </summary>
        /// <param name="obj">スクリプタブルオブジェクト</param>
        /// <param name="fileName">読み出すファイル名(平文の場合、自動で拡張子.jsonが付加されます）</param>
        /// <param name="PASS">暗号化パスワード：省略すると、Json平文で保存</param>
        public static void Load(in ScriptableObject obj, string fileName, string PASS = null)
        {
            try
            {
                string readJson = LoadBase(ref fileName, PASS);

                // Jsonデータをオブジェクトへ変換
                JsonUtility.FromJsonOverwrite(readJson, obj);
            }
            catch (System.Exception ex)
            {
                Debug.LogError("データの読み出しでエラーが発生" + ex);
            }
        }

        /// <summary>
        /// ロードの基本
        /// </summary>
        /// <param name="fileName">読み出すファイル名(平文の場合、自動で拡張子.jsonが付加されます）</param>
        /// <param name="PASS">暗号化パスワード：省略すると、Json平文で保存</param>
        /// <returns>JSon変換データ。エラーの場合、null</returns>
        static string LoadBase(ref string fileName, string PASS)
        {
            try
            {
                if (PASS == null)
                {
                    fileName = fileName.Contains(".json") ? fileName : fileName += ".json";
                }
                // 絶対パスの取得
                var conbined = Path.Combine(path, fileName);
                // 読み出し
                var readJson = File.ReadAllText(conbined);

                // 復号化
                var decJson = PASS == null ? readJson : Encryption.DecryptString(readJson, PASS);
                return readJson;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("データ読み出しエラー" + ex);
            }
        }
    }
}