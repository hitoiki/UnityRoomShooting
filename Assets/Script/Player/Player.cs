using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    // 自機の持つ状態
    // そんな量があるわけではないが、ItouchableのtouchPlayerを極力静的にしたいため

    //Monobehaviorと分けて、Observableを継承できるように
    public int hp { get; set; } = 1;
    public int ammo { get; set; } = 0;

    public Bullet bullet;

    public Player(int h, int b)
    {
        this.hp = h;
        this.ammo = b;
        bullet = null;
    }
    public static Player identity = new Player(0, 0);

    public static Player operator +(Player a, Player b)
    {
        return new Player(a.hp + b.hp, a.ammo + b.ammo);
    }
}

