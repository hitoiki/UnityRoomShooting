using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropWeapon : MonoBehaviour, IActionable, ITouchable
{
    public Text nameWriter;
    public Weapon dropWeapon;

    private void Awake()
    {
        if (dropWeapon == null) dropWeapon = GetComponent<Weapon>();
        nameWriter.text = dropWeapon.weaponState.weaponName;
    }
    public void ChangeWeapon(Weapon w)
    {
        dropWeapon = w;
        nameWriter.text = dropWeapon.weaponState.weaponName;
    }
    public void actionPlayer(PlayerState p)
    {
        Debug.Log("taked");
        Weapon buf = p.weapon.Value;
        p.ChangeWeapon(dropWeapon);
        ChangeWeapon(buf);
    }
    public void touchPlayer(PlayerState p)
    {
        Debug.Log("touched");
    }
    public void touchBullet(Bullet b)
    {

    }
}
