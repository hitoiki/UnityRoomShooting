using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionable
{
    //自機が拾えるものを示すインターフェース
    void actionPlayer(PlayerState player);

    //PLに触れた時、PLに触れて使われた時、弾丸に当たった時
}

