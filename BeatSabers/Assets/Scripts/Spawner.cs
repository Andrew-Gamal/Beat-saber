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

     // Start is called before the first frame update
    void Start()
    {
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

    }
}
