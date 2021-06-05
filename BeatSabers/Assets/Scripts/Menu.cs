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

    float SpeedValue;
    float SpeedValueEasy = 50f;
    float SpeedValueHard = 100f;
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
        SpeedSlider.onValueChanged.AddListener(delegate { SpeedValueChangeCheck(); });
        SpeedSlider.value = PlayerPrefs.GetFloat("LevelSpeed");
        output= PlayerPrefs.GetFloat("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("LevelSpeed", SpeedSlider.value);
        PlayerPrefs.SetFloat("Timer", output);
    }

    public float SpeedValueChangeCheck()
    {
        //Debug.Log(SpeedSlider.value);
        if(SpeedSlider.value == 1)
        {
            SpeedValue = SpeedValueEasy;
        }
        if(SpeedSlider.value == 2)
        {
            SpeedValue = SpeedValueHard;
        }
        PlayerPrefs.SetFloat("LevelSpeed", SpeedValue);
        return SpeedValue;
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
        PlayerPrefs.SetFloat("Timer",output);

        return output;
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
