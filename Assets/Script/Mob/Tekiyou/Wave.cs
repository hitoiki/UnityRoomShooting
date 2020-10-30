using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    private float time;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        time += Time.deltaTime;
        rb.velocity = Vector2.left * speed + Vector2.up * speed * Mathf.Cos(time);
        if (time >= 7) time -= 7;
    }
}
