using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flow : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;


    public Vector2 vanish1;
    public Vector2 vanish2;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (speed != 0) rb.velocity = Vector2.left * speed;
    }
    private void Update()
    {
        if (rb.position.x < vanish1.x || rb.position.x > vanish2.x || rb.position.y > vanish1.y || rb.position.y < vanish2.y)
        {
            //Destroy(this.gameObject);
            //Debug.Log(rb.position.y.ToString());
            this.gameObject.SetActive(false);
        }

    }
}
