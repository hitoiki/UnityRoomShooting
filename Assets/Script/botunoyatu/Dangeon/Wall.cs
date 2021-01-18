using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IBulletTouchable
{
    // Start is called before the first frame update
    public void touchBullet(Bullet b)
    {
        Debug.Log("bulletTouch");
    }
}
