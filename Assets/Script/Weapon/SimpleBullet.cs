using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : Bullet
{
    public override void Init()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    public override void shoot(Vector2 vec)
    {
        direction = vec;
    }

}

