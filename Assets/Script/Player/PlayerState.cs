using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[System.Serializable]
public class PlayerState : MonoBehaviour
{
    // 自機の持つ状態
    // そんな量があるわけではないが、ItouchableのtouchPlayerを極力静的にしたいため
    //Monobehaviorと分けて、Observableを継承できるように

    //UniRxを導入したので、MonoBehaviourにする
    private ReactiveProperty<int> _hp = new ReactiveProperty<int>();
    public IReadOnlyReactiveProperty<int> hp => _hp;
    private ReactiveProperty<int> _ammo = new ReactiveProperty<int>();
    public IReadOnlyReactiveProperty<int> ammo => _ammo;
    public ReactiveProperty<float> speed { get; set; } = new ReactiveProperty<float>();
    private ReactiveProperty<float> _hands = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<float> hands => _hands;

    private ReactiveProperty<Weapon> _weapon = new ReactiveProperty<Weapon>();
    public IReadOnlyReactiveProperty<Weapon> weapon => _weapon;

    [SerializeField] int Sethp = 0;
    [SerializeField] int Setammo = 0;
    [SerializeField] float Setspeed = 0;
    [SerializeField] float Sethands = 0;
    [SerializeField] Weapon SetWeapon = null;


    public bool IsDead;
    public Rigidbody2D rb;
    private void Awake()
    {
        _hp.Value = Sethp;
        _ammo.Value = Setammo;
        speed.Value = Setspeed;
        _hands.Value = Sethands;
        _weapon.Value = SetWeapon;
        IsDead = false;
    }

    public void Damage(int n)
    {
        if (!IsDead)
        {
            _hp.Value -= n;
            if (_hp.Value <= 0) this.IsDead = true;
        }
    }

    public void UseAmmo(int n)
    {
        if (!IsDead)
        {
            _ammo.Value -= n;
            if (_ammo.Value <= 0) _ammo.Value = 0;
        }
    }

    public void ChangeWeapon(Weapon w)
    {
        _weapon.Value = w;
    }

}

