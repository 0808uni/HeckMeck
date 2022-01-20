# UnityBaseProject
 Unityプロジェクトのベースとなる基本構成で、新しくプロジェクトを作成する場合、これから始めることで初期で様々な必要アセットのインポートや初期の設定を省略できます。また、再利用可能であることも特徴です。
 
## リポジトリテンプレート
このプロジェクトはテンプレートとして作成されています
クラウドのGitHubページ（このページ）から右上緑文字の***use this template***「テンプレートを使う」でこのリポジトリのコピーから新しいプロジェクトをスタートすることができます

## Unityバージョン
- 2021.2.8f1

## Gitで管理対象とするファイルのプラットフォーム情報 (gitignore)
- Unity
- MacOS
- VisualStudio
- VisualStudioCode

## インポートされているアセット
- AssetPostprocessUTF8Encode（BOM付きUTF-8でファイルの作成時自動保存）
- DOTWeen（コードによるアニメーションの実装）
- CrossSceneReference (シーン間データ受け渡しを可能にする)
- VContainer（Unity向けDIコンテナ）
- ExtPlayerPrefs（データの保存、読み出しツール。オブジェクトやスクリプタブルオブジェクトにも対応）

## 初期に作成されているフォルダ
- Animations
- Editor
- Plugins
- Prefabs
- Resources
- Scenes
- Scripts
- Sprites
- Tools

## Issue（課題）
### issueテンプレート
次の内容のテンプレートが追加されています
- バグレポート
- 機能追加テンプレート

## Commit
### コミットルール

|  Prefix  |  意味  |
| ---- | ---- |
|  fix  |  バグ修正  |
| add | 新規機能・新規ファイル追加 |
| update | バグではない機能修正 |
| refactor | 整理 (リファクタリング等) |
| remove | 削除、取り消し |
| test | テスト追加や間違っていたテストの修正 |

[GitHubを使ったチーム開発](https://soft-rime.com/post-3157/)

[コミットの書き方](https://suwaru.tokyo/【必須】gitコミットの書き方・作法【prefix-emoji】)

## Pull requests
### Pull requestテンプレート
次の内容のテンプレートが追加されています
- バグレポート
- UIに対する変更・画面
- 技術的変更点概要
- 本プルリクエストによる影響範囲
- 特にレビューをお願いしたい箇所
- レビュー優先度
