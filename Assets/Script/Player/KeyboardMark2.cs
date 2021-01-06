using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMark2 : KeyPad
{
    protected override void KeyPadCheck()
    {
        Shot.Value = Input.GetMouseButton(0);
        Action.Value = Input.GetMouseButtonDown(1);
        Vector2 recept = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) recept += Vector2.up;

        if (Input.GetKey(KeyCode.S)) recept += Vector2.down;

        if (Input.GetKey(KeyCode.D)) recept += Vector2.right;

        if (Input.GetKey(KeyCode.A)) recept += Vector2.left;

        InputVector.Value = recept;
        AimDirection.Value = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        //AimDirection.Value = AimDirection.Value.normalized;
    }


}
