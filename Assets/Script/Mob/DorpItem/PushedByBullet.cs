using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushedByBullet : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }
}
