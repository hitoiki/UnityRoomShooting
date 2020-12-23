using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponState
{
    /*このWeaponは打ち出されるBulletに必要な情報全てを持つ
       飛ばすBulletはinspectorで弄る仕組みにせず、Weaponを代入して生成される
    */
    [SerializeField] public string weaponName;
    [SerializeField] public float speed = 1;
    [SerializeField] public float range = 1;
    [SerializeField] public int damage = 1;
    [SerializeField] public int AmmoParShot;
    [SerializeField] public float shotInterval;
}

