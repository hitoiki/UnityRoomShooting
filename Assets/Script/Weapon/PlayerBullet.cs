using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        var touchable = col.gameObject.GetComponent<IBulletTouchable>();
        if (touchable != null)
        {
            touchable.touchBullet(this);
            //this.gameObject.SetActive(false);
        }
    }
}
