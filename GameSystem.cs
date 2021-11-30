using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;
    public int playerLifeInt;
    [SerializeField]
    private Text playerLifeStr;
    [SerializeField]
    private Text moonCountstr;
    public int moonFullCountInt;
    [SerializeField]
    private Text moonFullCountstr;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject Moon;
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private int stageCount;
    [SerializeField]
    private GameObject Results;
    [SerializeField]
    private Text resultTimeText;
    [SerializeField]
    private Text resultMoonFullText;
    [SerializeField]
    private Text resultMoonText;
    [SerializeField]
    private Text resultScoreText;
    [SerializeField]
    private Text RANKText;
    public int score;
    public GameObject CompassMoonAct;
    public GameObject CompassMoonInAct;

    public bool timeBool = true;

    public float time;
    private float nextTime = 0.0f;

    private void Start()
    {
        moonFullCountstr.text += moonFullCountInt.ToString();
    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (timeBool)
        {
            time += Time.deltaTime;
            timeText.text = string.Format("{0:N2}", time);
            if(Time.time > nextTime)
            {
                nextTime = Time.time + 1f;
                score -= 1;
                Debug.Log(score);
            }
        }

        playerLifeStr.text = playerLifeInt.ToString();


    }


    public void moonUp(int intMoon)
    {
        moonCountstr.text = intMoon.ToString();
    }

    public void Life(int intlife)
    {
        playerLifeStr.text = intlife.ToString();
    }

    public void RESULTS(GameObject RESULTS, int score, int moon,int moonFull ,float time,Text moonText,Text moonFullText , Text scoreText, Text timeText, Text Rank)
    {
        timeBool = false;
        timeText.text = time.ToString();
        moonText.text = moon.ToString();
        moonFullText.text = moonFull.ToString();
        score = score * 1000 + moon * 100;
        scoreText.text = score.ToString();
        switch{

        }
        Rank.text = "A";
        RESULTS.SetActive(true);
        
    }

    public void StageUp()
    {
        stageCount++;
        SceneManager.LoadScene(stageCount);
    }
}
