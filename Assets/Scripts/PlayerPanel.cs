using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPanel : MonoBehaviour
{
    bool isDropped;
    [SerializeField]
    int distance;

    public void DropDown()
    {
        Vector3 pos = gameObject.transform.position;

        if (!isDropped)
        {
            pos.y -= distance;
            isDropped = true;
        }
        else
        {
            pos.y += distance;
            isDropped = false;
        }

        transform.position = pos;
    }
}
