using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "MyScriptable/Tactics/Hanyo")]
public class TacticsHanyo : Tactics
{
    //最初から…こうすれば良かったんだ…
    //privateの値でゴリゴリやる

    [SerializeField] private bool chase = true;
    [SerializeField] private float distanceToKeep = 1;
    [SerializeField] private float distanceAreaToKeep = 0.05f;
    [SerializeField] private bool shot = true;
    public override void tactics(Vector3 playerPositipn, Vector3 MyPosition, KeyPad keyPad)
    {
        keyPad.AimDirection.Value = playerPositipn - MyPosition;
        if (chase)
        {
            float distance = (playerPositipn - MyPosition).magnitude;
            if (Mathf.Abs(distance - distanceToKeep) <= distanceAreaToKeep) keyPad.InputVector.Value = Vector3.zero;
            else
            {
                if (distance > distanceToKeep) keyPad.InputVector.Value = playerPositipn - MyPosition;
                else keyPad.InputVector.Value = -(playerPositipn - MyPosition);
            }
        }
        else keyPad.InputVector.Value = Vector3.zero;
        keyPad.Shot.Value = shot;
    }
}
