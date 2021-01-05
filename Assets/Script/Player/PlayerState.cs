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

    //本当はいらないけど、inspectorで突っ込みたいのでMonoBehaviourにする

    [SerializeField] int Sethp = 0;
    [SerializeField] int Setammo = 0;
    [SerializeField] float Setspeed = 0;
    [SerializeField] float Sethands = 0;
    [SerializeField] Weapon SetWeapon = null;

    //式木？の機能を使って初期化させておく
    private ReactiveProperty<int> _hp => new ReactiveProperty<int>(Sethp);
    public IReadOnlyReactiveProperty<int> hp => _hp;
    private ReactiveProperty<int> _ammo => new ReactiveProperty<int>(Setammo);
    public IReadOnlyReactiveProperty<int> ammo => _ammo;
    public ReactiveProperty<float> _speed => new ReactiveProperty<float>(Setspeed);
    public IReadOnlyReactiveProperty<float> speed => _speed;
    private ReactiveProperty<float> _hands => new ReactiveProperty<float>(Sethands);
    public IReadOnlyReactiveProperty<float> hands => _hands;

    private ReactiveProperty<Weapon> _weapon => new ReactiveProperty<Weapon>(SetWeapon);
    public IReadOnlyReactiveProperty<Weapon> weapon => _weapon;


    public PlayerMode playerMode;
    public Rigidbody2D rb;
    private void Awake()
    {
        /*
        _hp.Value = Sethp;
        _ammo.Value = Setammo;
        _speed.Value = Setspeed;
        _hands.Value = Sethands;
        _weapon.Value = SetWeapon;
        playerMode = PlayerMode.alive;
        */
    }

    public void Damage(int n)
    {
        if (playerMode == PlayerMode.alive)
        {
            _hp.Value -= n;
            if (_hp.Value <= 0) this.playerMode = PlayerMode.dead;
        }
    }

    public void UseAmmo(int n)
    {
        if (playerMode == PlayerMode.alive)
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

public enum PlayerMode
{
    alive, dead, pose
}

