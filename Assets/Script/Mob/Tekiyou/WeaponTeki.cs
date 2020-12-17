using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTeki : MonoBehaviour, ITouchable
{
    Rigidbody2D rb;
    public SparkEffecter sparker;
    public GameDataLog DataLog;

    public int dealDamage = 0;
    public int dealScore = 0;

    public int hp = 5;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void touchPlayer(PlayerState p)
    {
        this.gameObject.SetActive(false);
        p.Damage(dealDamage);
    }
    public void touchBullet(Bullet b)
    {
        //Debug.Log("bulletTouch");
        //hp -= b.weaponState.damage;
        if (hp <= 0)
        {
            if (DataLog != null) DataLog.score.Value += dealScore;
            if (sparker != null) sparker.Scatt(rb.position);
            this.gameObject.SetActive(false);
        }

    }
}
