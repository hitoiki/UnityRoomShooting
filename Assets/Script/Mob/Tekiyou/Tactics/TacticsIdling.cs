using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Tactics/Idling")]
public class TacticsIdling : Tactics
{
    public override void tactics(Vector3 playerPositipn, Vector3 MyPosition, KeyPad keyPad)
    {
        keyPad.InputVector.Value = Vector3.zero;
        keyPad.Shot.Value = false;
        keyPad.Action.Value = false;
    }
}
