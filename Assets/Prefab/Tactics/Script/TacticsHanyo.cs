using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "MyScriptable/Tactics/Hanyo")]
public class TacticsHanyo : Tactics
{
    //最初から…こうすれば良かったんだ…
    //privateの値でゴリゴリやる

    [SerializeField] private movingKind move = movingKind.chase;

    //Aiの目指すPlayerとの最小距離
    [SerializeField] private float suitingMinDistance = 1;
    //Aiの目指すPlayerとの最大距離
    [SerializeField] private float suitingMaxDistance = 1.05f;
    //AiはPlayerから半径suitingMinDistance~suitingMaxDistanceの辺りを基準にして動く
    [SerializeField] private shootKind shot = shootKind.none;
    public override void tactics(Vector3 playerPositipn, Vector3 MyPosition, KeyPad keyPad)
    {
        if (shot != shootKind.none) keyPad.AimDirection.Value = playerPositipn - MyPosition;

        float distance = Mathf.Abs((playerPositipn - MyPosition).magnitude);
        if (move == movingKind.Random) keyPad.InputVector.Value = Vector2.Lerp(keyPad.InputVector.Value, Random.insideUnitCircle, 0.5f);
        else if (move == movingKind.Idling) keyPad.InputVector.Value = Vector2.zero;
        else
        {
            if (suitingMinDistance <= distance && distance <= suitingMaxDistance) keyPad.InputVector.Value = Vector3.zero;
            else
            {
                if (distance > suitingMaxDistance) keyPad.InputVector.Value = playerPositipn - MyPosition;
                else keyPad.InputVector.Value = -(playerPositipn - MyPosition);
            }
            if (move == movingKind.runAway) keyPad.InputVector.Value *= -1f;
        }
        //ワンライナーですまない…いつか部分クラスで実装するから…
        keyPad.Shot.Value = (shot == shootKind.always || ((shot == shootKind.around) && (suitingMinDistance <= distance && distance <= suitingMaxDistance)));
    }
}

public enum shootKind
{
    always, around, none
}

public enum movingKind
{
    chase, runAway, Random, Idling
}