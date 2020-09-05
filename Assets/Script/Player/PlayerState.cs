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
    public ReactiveProperty<int> hp { get; set; } = new ReactiveProperty<int>();
    public ReactiveProperty<int> ammo { get; set; } = new ReactiveProperty<int>();
    public ReactiveProperty<float> speed { get; set; } = new ReactiveProperty<float>();

    [SerializeField] int Sethp = 0;
    [SerializeField] int Setammo = 0;
    [SerializeField] float Setspeed = 0;

    public Rigidbody2D rb;

    public Bullet bullet;

    private void Awake()
    {
        hp.Value = Sethp;
        ammo.Value = Setammo;
        speed.Value = Setspeed;

    }
}

