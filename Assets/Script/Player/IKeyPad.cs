using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class IKeyPad : MonoBehaviour
{
    public ReactiveProperty<bool> Shot { get; set; } = new ReactiveProperty<bool>();
    public ReactiveProperty<bool> Action { get; set; } = new ReactiveProperty<bool>();

    public ReactiveProperty<Vector2> InputVector { get; set; } = new ReactiveProperty<Vector2>();

    public ReactiveProperty<Vector2> AimDirection { get; set; } = new ReactiveProperty<Vector2>();

    public abstract void KeyPadUpdate();
}

