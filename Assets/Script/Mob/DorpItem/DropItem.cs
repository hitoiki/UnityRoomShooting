using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour, IActionable, ITouchable
{

    public void actionPlayer(PlayerState p)
    {
        Debug.Log("taked");
    }
    public void touchPlayer(PlayerState p)
    {
        Debug.Log("touched");
    }
    public void touchBullet(Bullet b)
    {

    }
}
