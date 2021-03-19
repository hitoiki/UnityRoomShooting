using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemWithGem : DropWeapon
{
    [SerializeField] int addAmmo = 100;
    public override void actionPlayer(PlayerState p)
    {
        //Debug.Log("taked");
        Weapon buf = p.weapon.Value;
        p.ChangeWeapon(dropWeapon);
        p.SetAmmo(addAmmo / dropWeapon.weaponState.AmmoParShot);
        this.gameObject.SetActive(false);
    }
}
