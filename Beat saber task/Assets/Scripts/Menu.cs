using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    private static Menu _menu;
    public static Menu Instance => _menu;


    float SliderValue;
    [SerializeField] Slider SpeedSlider;
    float output;
    float timer1 = 30;
    float timer2 = 60;
    [SerializeField] TMP_Dropdown val;
    void Awake()
    {
        _menu = this;
    }
    // Start is called before the first frame update
    private void Start()
    {
        SpeedSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        SpeedSlider.value = PlayerPrefs.GetFloat("LevelSpeed");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("LevelSpeed", SpeedSlider.value);

    }

    public float ValueChangeCheck()
    {
        Debug.Log(SpeedSlider.value);
        SliderValue = SpeedSlider.value;
        return SliderValue;
    }

    public float TimerValue()
    {
        if (val.value == 0)
        {
            output = timer1;
        } 
        if (val.value == 1)
        {
            output = timer2;
        }
        return output;
    }
    
    public void startButton()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
