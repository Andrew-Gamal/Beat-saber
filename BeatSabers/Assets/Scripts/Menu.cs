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

    float SpeedValueEasy = 50f;
    float SpeedValueHard = 100f;
    [SerializeField] Slider SpeedSlider;

    int timer1 = 30;
    int timer2 = 60;
    [SerializeField] TMP_Dropdown TimeMenuVal;
    void Awake()
    {
        _menu = this;
    }
    // Start is called before the first frame update
    private void Start()
    {
       // SpeedSlider.onValueChanged.AddListener(delegate { SpeedValueChangeCheck(); });
        SpeedSlider.value = PlayerPrefs.GetFloat("LevelSpeed");
        TimeMenuVal.value = PlayerPrefs.GetInt("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("LevelSpeed", SpeedSlider.value);
        PlayerPrefs.SetInt("Timer", TimeMenuVal.value);
    }

    public float SpeedValueChangeCheck()
    {
        //Debug.Log(SpeedSlider.value);
        if(SpeedSlider.value == 1)
        {
            SpeedSlider.value = SpeedValueEasy;
        }
        if(SpeedSlider.value == 2)
        {
            SpeedSlider.value = SpeedValueHard;
        }
        PlayerPrefs.SetFloat("LevelSpeed", SpeedSlider.value);
        return SpeedSlider.value;
    }

    public float TimerValue()
    {
        if (TimeMenuVal.value == 0)
        {
            TimeMenuVal.value = timer1;
        } 
        if (TimeMenuVal.value == 1)
        {
            TimeMenuVal.value = timer2;
        }
        PlayerPrefs.SetInt("Timer", TimeMenuVal.value);

        return TimeMenuVal.value;
    }
    
    public void startButton()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
