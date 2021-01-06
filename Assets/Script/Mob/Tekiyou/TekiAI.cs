using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TekiAI : KeyPad
{
    //KeyPadを継承して色々動く
    //視野となるRayを飛ばして、Objectを取得、状況に応じてKeyPadを操作
    //知覚情報はTekiStateから色々する

    [SerializeField] private TekiState state;
    private PlayerState targetPlayer;

    private void Awake()
    {
        if (state == null) state = this.GetComponent<TekiState>();
    }
    protected override void KeyPadCheck()
    {
        var inTheHands = Physics2D.CircleCastAll(this.transform.position, state.sight.Value, Vector2.zero).Select(x => x.collider.GetComponent<PlayerState>());
        if (inTheHands.Any(x => x != null))
        {
            targetPlayer = inTheHands.Where(x => x != null).First();
            Aiming(targetPlayer);
        }
        else Idling();
    }

    protected virtual void Aiming(PlayerState p)
    {
        InputVector.Value = targetPlayer.transform.position - this.transform.position;
        AimDirection.Value = targetPlayer.transform.position - this.transform.position;
        if (Shot.Value)
        {

        }
        else
        {
            Shot.Value = true;
        }
    }
    protected virtual void Idling()
    {
        InputVector.Value = Vector2.zero;
        Shot.Value = false;
    }
}

