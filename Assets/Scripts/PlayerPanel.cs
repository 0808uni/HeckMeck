using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPanel : MonoBehaviour
{
    bool isDropped;

    public void DropDown()
    {
        Vector3 pos = transform.position;

        if (!isDropped)
        {
            pos.y -= 100;
            isDropped = true;
        }
        else
        {
            pos.y += 100;
            isDropped = false;
        }

        transform.position = pos;
    }
}
