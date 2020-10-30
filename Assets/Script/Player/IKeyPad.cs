using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class IKeyPad : MonoBehaviour
{
    public ReactiveProperty<bool> Shot { get; set; } = new ReactiveProperty<bool>();
    public ReactiveProperty<bool> Take { get; set; } = new ReactiveProperty<bool>();

    public ReactiveProperty<Vector2> InputVector { get; set; } = new ReactiveProperty<Vector2>();

    //ハンドルがfroatになってるのはアナログパッドに対応するため

    public abstract void KeyPadUpdate();
}

