using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IKeyPad : MonoBehaviour
{
    public bool Shot { get; set; }

    private Vector2 keyVector;
    public Vector2 KeyVector
    {
        set
        {
            keyVector = value.normalized;
        }
        get { return keyVector; }
    }
    //ハンドルがfroatになってるのはアナログパッドに対応するため

    public abstract void KeyPadUpdate();
}

