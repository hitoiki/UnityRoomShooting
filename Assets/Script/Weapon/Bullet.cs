using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 1;
    public int damage = 1;
    protected Vector2 direction;
    public abstract void Init();
    public abstract void shoot(Vector2 vec);

    private void OnCollisionEnter2D(Collision2D col)
    {
        var touchable = col.gameObject.GetComponent<ITouchable>();
        if (touchable != null)
        {
            touchable.touchBullet(this);
            this.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero) rb.velocity = direction * speed;
    }
}
