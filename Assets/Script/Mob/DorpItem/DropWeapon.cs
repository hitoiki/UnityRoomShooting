using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropWeapon : MonoBehaviour, IActionable
{
    public Text nameWriter;
    public Weapon dropWeapon;
    public EffectDealer effector;

    private void Awake()
    {
        if (dropWeapon == null) dropWeapon = GetComponent<Weapon>();
        if (effector == null) effector = GetComponent<EffectDealer>();
        nameWriter.text = dropWeapon.weaponState.weaponName;
    }
    public virtual void ChangeWeapon(Weapon w)
    {
        dropWeapon = w;
        nameWriter.text = dropWeapon.weaponState.weaponName;
    }

    public void ChangeEffector(EffectDealer e)
    {
        effector = e;
    }
    public virtual void actionPlayer(PlayerState p)
    {
        Debug.Log("taked");
        Weapon buf = p.weapon.Value;
        p.ChangeWeapon(dropWeapon);
        ChangeWeapon(buf);
    }
}
