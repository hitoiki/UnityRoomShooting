using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, ITouchable
{
    // Start is called before the first frame update
    public void touchPlayer(PlayerState p) { }
    public void touchBullet(Bullet b)
    {
        Debug.Log("bulletTouch");
    }
}
