using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cube : MonoBehaviour
{
    float CubeSpeed=1f;
    float speedfromUser=1f;
    Rigidbody rb;
    [SerializeField] GameObject cubeSlicedPrefab;

    private static Cube _Cube;
    public static Cube Instance => _Cube;

    void Awake()
    {
        _Cube = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        speedfromUser = PlayerPrefs.GetFloat("LevelSpeed");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * (-transform.right) * (CubeSpeed * speedfromUser);
    }

    public void explode()
    {
        Vector3 direction = (transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        GameObject slicedFruit = Instantiate(cubeSlicedPrefab, transform.position, rotation);
        slicedFruit.GetComponent<Rigidbody>().AddForce(-transform.forward * 1000);
        Destroy(gameObject);

    }
}
