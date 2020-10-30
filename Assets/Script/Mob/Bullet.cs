using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public void Init()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        var touchable = col.gameObject.GetComponent<ITouchable>();
        if (touchable != null)
        {
            touchable.touchBullet();
            touchable.subEffect();
            this.gameObject.SetActive(false);
        }
    }
}
