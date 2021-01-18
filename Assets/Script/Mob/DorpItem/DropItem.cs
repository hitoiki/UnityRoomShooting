using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour, IActionable
{

    public void actionPlayer(PlayerState p)
    {
        Debug.Log("taked");
    }
}
