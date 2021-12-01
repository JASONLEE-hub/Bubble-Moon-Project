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
    [SerializeField]
    private Text moonFullCountstr;
    [SerializeField]
    private GameObject Player;
    public GameObject Goal;
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private int stageCount;
    public GameObject Play;
    public GameObject Results;
    public int score;
    public int moonFullCountInt;
    public float time;
    public Text RANKText;
    public Text resultScoreText;
    public Text resultMoonText;
    public Text resultMoonFullText;
    public Text resultTimeText;
    public GameObject CompassMoonAct;
    public GameObject CompassMoonInAct;
    public GameObject BGM;

    public bool timeBool = true;

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

    public void RESULTS(GameObject Play, GameObject RESULTS, int score, int moon, int moonFull , float time, Text Rank, Text scoreText, Text moonText,Text moonFullText , Text timeText)
    {
        timeBool = false;
        Play.SetActive(false);
        timeText.text = time.ToString();
        moonText.text = moon.ToString();
        moonFullText.text = moonFull.ToString();
        score = score * 1000 + moon * 100;
        scoreText.text = score.ToString();
        if(score >= 540500)
        {
            Rank.text = "S";
        }
        else if(score >= 500500)
        {
            Rank.text = "A";
        }
        else if(score >= 400500)
        {
            Rank.text = "B";
        }
        else if(score >= 200500)
        {
            Rank.text = "C";
        }
        else if(score >= 100500)
        {
            Rank.text = "D";
        }
        else if (score >= 500)
        {
            Rank.text = "F";
        }
        RESULTS.SetActive(true);
        
    }

    public void StageUp()
    {
        stageCount++;
        SceneManager.LoadScene(stageCount);
    }
}
