using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Tactics/Chase")]
public class TacticsChase : Tactics
{
    public override void tactics(Vector3 playerPositipn, Vector3 MyPosition, KeyPad keyPad)
    {
        keyPad.InputVector.Value = playerPositipn - MyPosition;
        keyPad.AimDirection.Value = playerPositipn - MyPosition;
        keyPad.Shot.Value = true;
    }
}
