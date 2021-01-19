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

    [SerializeField] int setHp = 0;
    [SerializeField] int setAmmo = 0;
    [SerializeField] float setSpeed = 0;
    [SerializeField] float setHands = 0;
    [SerializeField] Weapon setWeapon = null;

    //式木？の機能を使って初期化させておく
    private ReactiveProperty<int> _hp = new ReactiveProperty<int>();
    public IReadOnlyReactiveProperty<int> hp => _hp;
    private ReactiveProperty<int> _ammo = new ReactiveProperty<int>();
    public IReadOnlyReactiveProperty<int> ammo => _ammo;
    public ReactiveProperty<float> _speed = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<float> speed => _speed;
    private ReactiveProperty<float> _hands = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<float> hands => _hands;

    private ReactiveProperty<Weapon> _weapon = new ReactiveProperty<Weapon>();
    public IReadOnlyReactiveProperty<Weapon> weapon => _weapon;


    public PlayerMode playerMode;
    public Rigidbody2D rb;
    private void Awake()
    {

        _hp.Value = setHp;
        _ammo.Value = setAmmo;
        _speed.Value = setSpeed;
        _hands.Value = setHands;
        _weapon.Value = setWeapon;
        playerMode = PlayerMode.alive;

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

    public void AddAmmo(int n)
    {
        if (playerMode == PlayerMode.alive)
        {
            _ammo.Value += n;
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

