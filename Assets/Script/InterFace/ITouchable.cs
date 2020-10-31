using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouchable
{
    //自機、弾が触れられるものを示すインターフェース
    void touchPlayer(PlayerState p);
    void touchBullet();

}
