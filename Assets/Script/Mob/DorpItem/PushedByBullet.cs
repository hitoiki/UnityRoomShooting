using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushedByBullet : MonoBehaviour, ITouchable
{
    [SerializeField] int hp;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }
    public void touchPlayer(PlayerState p)
    {
        Debug.Log("Pushed!");
    }
    public void touchBullet(Bullet b)
    {
        //rb.AddForce(b.)
        Debug.Log("Pushed!");
    }
}
