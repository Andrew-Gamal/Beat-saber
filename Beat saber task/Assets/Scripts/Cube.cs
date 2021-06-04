using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cube : MonoBehaviour
{
    float CubeSpeed=1f;
   // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += Time.deltaTime * (-transform.right) * (CubeSpeed * Menu.Instance.ValueChangeCheck());
    }


}
