using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Saber : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    private Vector3 previousposition;
    [SerializeField] private Animator myAnim;
    Animator anim;

    int counter = 0;
    private static Saber _saber;
    public static Saber Instance => _saber;

    void Awake()
    {
        _saber = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            myAnim.SetBool("BlueHit", true);
          
        }
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            myAnim.SetBool("BlueHit", false);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            myAnim.SetBool("RedHit", true);
        }
        if (Input.GetKeyUp(KeyCode.Keypad3))
        {
            myAnim.SetBool("RedHit", false);
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward, out hit , 1, layer))
        {
            if (hit.collider.gameObject.GetComponent<Cube>() != null)
            {
                hit.collider.gameObject.GetComponent<Cube>().explode();
                counter++;
            }

        }

    }

    public int count()
    {
        Debug.Log(counter);
        return counter;
    }
    
}
