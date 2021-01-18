using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropRelics : DropWeapon, IBulletTouchable
{
    //撃って壊れるアイテム
    //飛び出た破片は多分PLSweeperで取ると思う
    [SerializeField] private int hp = 10;
    [SerializeField] private GameObject piece = null;

    public void touchBullet(Bullet b)
    {
        hp -= b.weaponState.damage;
        b.gameObject.SetActive(false);
        if (hp <= 0) this.gameObject.SetActive(false);
    }
}
