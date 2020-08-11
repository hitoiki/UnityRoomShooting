using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouchable
{
    //自機、弾が触れられるものを示すインターフェース

    //返り値これでいいかちょっと不安
    void touchPlayer(Player p);
    void touchBullet();
    void subEffect();

}
