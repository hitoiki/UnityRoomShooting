using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class KeyPad : MonoBehaviour
{
    //プロパティを分離させようとも思ったが、UniRxを使ってるのであんま意味なかった
    public ReactiveProperty<bool> Shot { get; set; } = new ReactiveProperty<bool>();
    public ReactiveProperty<bool> Action { get; set; } = new ReactiveProperty<bool>();

    public ReactiveProperty<bool> MenuKey { get; set; } = new ReactiveProperty<bool>();
    public ReactiveProperty<Vector2> InputVector { get; set; } = new ReactiveProperty<Vector2>();
    public ReactiveProperty<Vector2> AimDirection { get; set; } = new ReactiveProperty<Vector2>();

    protected abstract void KeyPadCheck();
    protected virtual void UnTimedKeyPadCheck() { }
    public void KeyPadUpdate()
    {
        KeyPadCheck();
        InputVector.Value = InputVector.Value.normalized;
        AimDirection.Value = AimDirection.Value.normalized;
    }
    private void Update()
    {
        if (Time.timeScale != 0) KeyPadUpdate();
        UnTimedKeyPadCheck();

    }
}

