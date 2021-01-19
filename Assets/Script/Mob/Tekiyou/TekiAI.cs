using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TekiAI : KeyPad
{
    //KeyPadを継承して色々動く
    //視野となるRayを飛ばして、Objectを取得、状況に応じてKeyPadを操作
    //知覚情報はTekiStateから色々する

    //現在時間でTacticsを切り替えて行動している
    //距離によって判断を変えたさもある
    //敵は武器で変わるから弾幕撃つ武器用意すればそれで大丈夫説ある

    [SerializeField] private TekiState state;
    [SerializeField] private PlayerState targetPlayer;
    private float orderingTime = 0;
    private int nowOrder = 0;

    [SerializeField] private List<TacticsTag> orderList = null;
    private void Awake()
    {
        if (state == null) state = this.GetComponent<TekiState>();
    }
    protected override void KeyPadCheck()
    {

        var inTheHands = Physics2D.CircleCastAll(state.transform.position, state.sight.Value, Vector2.zero).Select(x => x.collider.GetComponent<PlayerState>());
        if (inTheHands.Any(x => x != null))
        {
            targetPlayer = inTheHands.Where(x => x != null).First();
            if (orderingTime < orderList[nowOrder].time)
            {
                orderList[nowOrder].writtenTactics.tactics(targetPlayer.transform.position, state.transform.position, this);
                orderingTime += Time.deltaTime;
            }
            else
            {
                nowOrder += 1;
                nowOrder %= orderList.Count;
                orderingTime = 0;
            }


        }
        else Idling();
    }
    protected virtual void Idling()
    {
        InputVector.Value = Vector2.zero;
        Shot.Value = false;
    }
}

[System.Serializable]
public class TacticsTag
{
    public Tactics writtenTactics;
    public float time;
}