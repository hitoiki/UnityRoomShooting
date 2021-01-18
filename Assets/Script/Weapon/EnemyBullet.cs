using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet, IPlayerTouchable
{
    public void touchPlayer(PlayerState p)
    {
        this.gameObject.SetActive(false);
        p.Damage(weaponState.damage);
    }

}
