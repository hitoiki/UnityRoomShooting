using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : IKeyPad
{
    //入力の受付を行う
    /*インターフェースでなく、同じコンポーネントのRacerDriveを見つけて
    そこに値を突っ込む形式*/
    public override void KeyPadUpdate()
    {
        Shot.Value = Input.GetKeyDown(KeyCode.Z);
        Take.Value = Input.GetKeyDown(KeyCode.X);
        Vector2 recept = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow)) recept += Vector2.up;

        if (Input.GetKey(KeyCode.DownArrow)) recept += Vector2.down;

        if (Input.GetKey(KeyCode.RightArrow)) recept += Vector2.right;

        if (Input.GetKey(KeyCode.LeftArrow)) recept += Vector2.left;

        InputVector.Value = recept;
    }

    private void Update()
    {
        KeyPadUpdate();
    }

}
