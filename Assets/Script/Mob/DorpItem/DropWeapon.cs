using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWeapon : MonoBehaviour, IActionable, ITouchable
{
    public bool vanish;
    public Weapon weapon;
    public void actionPlayer(PlayerState p)
    {
        Debug.Log("taked");
        p.ChangeWeapon(weapon);
        if (vanish) Destroy(this.gameObject);
    }
    public void touchPlayer(PlayerState p)
    {
        Debug.Log("touched");
    }
    public void touchBullet()
    {

    }
}
