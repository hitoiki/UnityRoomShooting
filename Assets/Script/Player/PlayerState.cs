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

    [SerializeField] int Sethp = 0;
    [SerializeField] int Setammo = 0;
    [SerializeField] float Setspeed = 0;

    public bool IsDead;
    public Rigidbody2D rb;
    public Bullet bullet;

    private void Awake()
    {
        _hp.Value = Sethp;
        _ammo.Value = Setammo;
        speed.Value = Setspeed;
        IsDead = false;
    }

    public void Damage(int n)
    {
        if (!IsDead)
        {
            _hp.Value -= n;
            if (_hp.Value <= 0) IsDead = true;
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


}

