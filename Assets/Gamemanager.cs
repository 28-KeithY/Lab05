using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public GameObject ScoreText;
    public int scorecount;
    public Text TimeText;
    public float timeleft;
    public int timeRemaining;

    private AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        audiosource = GetComponent<AudioSource>();
        audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.GetComponent<Text>().text = "Score: " + scorecount;

        timeleft -= Time.deltaTime;

        timeRemaining = Mathf.FloorToInt(timeleft % 60);

        TimeText.text = "Time: " + timeRemaining.ToString();

        if(timeleft <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }

        if(scorecount >= 100)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
