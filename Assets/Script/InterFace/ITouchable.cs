using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletTouchable
{
    //自機、弾が触れられるものを示すインターフェース
    void touchBullet(Bullet b);
}

public interface IPlayerTouchable
{
    void touchPlayer(PlayerState p);
}