using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Cubes;
    [SerializeField] private Transform[] points;
    [SerializeField] private float Beat = (60 / 105) * 2;
    private float Timer;

    float currentTime;
    float StartingTime;

    [SerializeField] Text CountdownTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        StartingTime = Menu.Instance.TimerValue();
        currentTime = StartingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer > Beat)
        {
            GameObject cube = Instantiate(Cubes[Random.Range(0, 2)], points[Random.Range(0, 1)]);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
            Timer -= Beat;
        }
        Timer += Time.deltaTime;

        //Timer Text Cont Down
        currentTime -= 1 * Time.deltaTime;
        CountdownTimer.text = currentTime.ToString("00.00");

        if (currentTime <= 0)
        {
            currentTime = 0;
            if (Time.timeScale == 1.0)
                Time.timeScale = 0.0f;

        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
