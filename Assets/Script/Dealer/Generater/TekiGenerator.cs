using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TekiGenerator : MonoBehaviour
{
    public List<TekiState> follower;

    [SerializeField] private float spownTime = 2;
    [SerializeField] private float spownTimeBure = 1;
    [SerializeField] private float spownPointRadius = 1;
    private float timer;

    [SerializeField] private EffectDealer effector = null;
    [SerializeField] private GameState dataLog = null;
    private List<ObjectFlyer<TekiState>> flyers = new List<ObjectFlyer<TekiState>>();

    void Start()
    {
        foreach (TekiState state in follower)
        {
            flyers.Add(new ObjectFlyer<TekiState>(state));
        }
    }

    private void Update()
    {
        if (timer <= spownTime)
        {
            Vector2 RandomPoint = Random.insideUnitCircle.normalized * spownPointRadius;
            Spown(RandomPoint, Random.Range(0, flyers.Count));
            timer += spownTime;
            timer += Random.Range(-spownTimeBure, spownTimeBure);
        }
        timer -= Time.deltaTime;
    }
    void Spown(Vector3 spownPoint, int spownNumber)
    {
        if (flyers[spownNumber] != null) flyers[spownNumber].GetMob(spownPoint, (x => { Setting(x); }), (x => { x.Init(); }));
    }

    void Setting(TekiState teki)
    {
        Rigidbody2D r = teki.rb;
        int s = teki.getScore;
        teki.tekiMode.Where(x => { return x == TekiMode.dead; }).Subscribe(x =>
        {
            effector.SparkScatt(r.position);
            dataLog.score.Value += s;
            //Debug.Log("called");
        });

    }

}
