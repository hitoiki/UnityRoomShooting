using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Blinker : MonoBehaviour
{
    private float nextTime;
    public float interval = 1.0f;   // 点滅周期

    // Use this for initialization
    void Start()
    {
        nextTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime)
        {
            var renderComponent = GetComponent<Image>();
            renderComponent.enabled = !renderComponent.enabled;

            nextTime += interval;
        }
    }
}
