using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
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
    public GameObject CompassMoonAct;
    public GameObject CompassMoonInAct;

    public bool timeBool = true;

    private float time;

    private void Start()
    {
        moonFullCountstr.text += moonFullCountInt.ToString();
    }

    private void Update()
    {
        if (timeBool)
        {
            time += Time.deltaTime;
            timeText.text = string.Format("{0:N2}", time);
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

    public void StageUp()
    {
        stageCount++;
        SceneManager.LoadScene(stageCount);
    }
}
