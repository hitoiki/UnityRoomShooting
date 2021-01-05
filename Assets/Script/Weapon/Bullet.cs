using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //ObjectFlyerで飛ばす際にWeaponの情報を受け取って、飛ばす
    public WeaponState weaponState { get; private set; }
    [SerializeField] Rigidbody2D rb;
    protected float nowrange;
    protected Vector2 direction;

    //Initはコンストラクタの代わりを行う
    public virtual void Init(WeaponState w)
    {
        if (rb == null) rb = this.GetComponent<Rigidbody2D>();
        weaponState = w;
    }
    public virtual void shoot(Vector2 vec)
    {
        direction = vec;
        nowrange = weaponState.range;
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero) rb.velocity = direction * weaponState.speed;
        nowrange -= weaponState.speed * Time.deltaTime;
        if (nowrange <= 0) this.gameObject.SetActive(false);
    }

    /*public Bullet StateCasted(WeaponState castWeapon)
    {
        if (weaponState == null) Debug.Log("null");
        weaponState = castWeapon;
        Debug.Log("Casted");
        return this;
    }*/
}
