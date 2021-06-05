using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIcontroler : MonoBehaviour
{
    [SerializeField] GameObject SconePanel;
    [SerializeField] TMP_Text ScoreText;

    float currentTime=0;
    float StartingTime=0;

    [SerializeField] Saber blueSaber;
    [SerializeField] Saber RedSaber;


    [SerializeField] TMP_Text CountdownTimer;
    // Start is called before the first frame update
    void Start()
    {
        StartingTime = PlayerPrefs.GetInt("Timer");
        if (StartingTime == 0)
        {
            StartingTime = 30;
        }
        if (StartingTime == 1)
        {
            StartingTime = 60;
        }
        currentTime = StartingTime;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Timer Text Cont Down
        currentTime -= 1 * Time.deltaTime;
        CountdownTimer.text = currentTime.ToString("00.00");

        if (currentTime <= 0)
        {
            currentTime = 0;
            if (Time.timeScale == 1.0)
                Time.timeScale = 0.0f;
                ScorePanel();

        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
    public void ScorePanel()
    {
        SconePanel.SetActive(true);
        ScoreText.text = (blueSaber.count() + RedSaber.count()).ToString();
      //  Debug.Log(Saber.Instance.count().ToString());
    }

    public void playAgain()
    {
        currentTime = StartingTime;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

}
