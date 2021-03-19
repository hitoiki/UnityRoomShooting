using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PLMenu : MonoBehaviour
{
    //GameDataLogとPlayerModeを同期させるだけ
    [SerializeField] private PlayerState state = null;
    [SerializeField] private GameState mode = null;
    private PlayerMode modeBeforePose;

    private void Start()
    {
        if (state == null) state = GetComponent<PlayerState>();
        mode.nowGameMode.Subscribe(x =>
        {
            if (x == modeEnum.menu)
            {
                modeBeforePose = state.playerMode;
                state.playerMode = PlayerMode.pose;
            }
            else
            {
                state.playerMode = modeBeforePose;
            }
        });
    }
}
