using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TekiGenerator : MonoBehaviour
{
    public List<TekiState> follower;
    public float spownTime;
    public float spownBure;
    private float timer;

    public EffectDealer effector = null;
    public GameDataLog dataLog = null;
    private List<ObjectFlyer<TekiState>> flyers = null;

    void Start()
    {

    }
    void Spown(Vector3 spownPoint, int spownNumber)
    {
        var newTeki = flyers[spownNumber].GetMob(spownPoint, (x => { }), (x => { x.Init(); }));
    }

}
