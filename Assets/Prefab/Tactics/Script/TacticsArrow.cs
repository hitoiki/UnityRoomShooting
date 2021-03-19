using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Tactics/Arrow")]
public class TacticsArrow : Tactics
{
    //必要なの取り敢えずまとめてるだけなのでごちゃごちゃなのは勘弁
    [SerializeField] private bool dasei = false;
    [SerializeField] private Vector3 aimingPoint = Vector3.zero;
    public override void tactics(Vector3 playerPositipn, Vector3 MyPosition, KeyPad keyPad)
    {
        if (!dasei)
        {
            keyPad.InputVector.Value = aimingPoint - MyPosition;
            keyPad.InputVector.Value = aimingPoint - MyPosition;
        }
    }
}
