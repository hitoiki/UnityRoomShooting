using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TekiState
{
    // 敵の持つ状態
    // PlayerStateを元に色々

    [SerializeField] int Sethp = 0;
    [SerializeField] float SetSight = 0;
    [SerializeField] float Setspeed = 0;
    [SerializeField] float Sethands = 0;
    [SerializeField] int SettouchDamage = 0;
    [SerializeField] Weapon SetWeapon = null;


    private ReactiveProperty<int> _hp = new ReactiveProperty<int>();
    public IReadOnlyReactiveProperty<int> hp => _hp;
    public ReactiveProperty<float> shootinginterval { get; set; } = new ReactiveProperty<float>();
    private ReactiveProperty<float> _sight = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<float> sight => _sight;
    private ReactiveProperty<Weapon> _weapon = new ReactiveProperty<Weapon>();
    public IReadOnlyReactiveProperty<Weapon> weapon => _weapon;
    public ReactiveProperty<float> _speed = new ReactiveProperty<float>();
    public ReactiveProperty<float> speed => _speed;
    public ReactiveProperty<int> _touchDamage = new ReactiveProperty<int>();
    public IReadOnlyReactiveProperty<int> touchDamage => _touchDamage;

    private ReactiveProperty<TekiMode> _tekiMode = new ReactiveProperty<TekiMode>();
    public IReadOnlyReactiveProperty<TekiMode> tekiMode => _tekiMode;

    public Rigidbody2D rb;
    private void Awake()
    {

        _hp.Value = Sethp;
        _sight.Value = SetSight;
        _speed.Value = Setspeed;
        _touchDamage.Value = SettouchDamage;
        _weapon.Value = SetWeapon;
        _tekiMode.Value = TekiMode.alive;

    }

    public void Damage(int n)
    {
        if (_tekiMode.Value == TekiMode.alive)
        {
            _hp.Value -= n;
            if (_hp.Value <= 0) this._tekiMode.Value = TekiMode.dead;
        }
    }

    public void ChangeWeapon(Weapon w)
    {
        _weapon.Value = w;
    }

}

public enum TekiMode
{
    alive, dead, pose
}