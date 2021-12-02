using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public AudioClip meteorSound;

    public AudioClip BGM;

    [SerializeField]
    private Camera camera1;

    [SerializeField]
    private Camera camera2;

    [SerializeField]
    private Camera camera3;

    [SerializeField]
    private GameObject Meteor;


    private void Start()
    {
        StartCoroutine(TitleMusic(meteorSound, BGM, camera1, camera2, camera3, Meteor));
        StartCoroutine(RE());
    }

    private void Update()
    {
        playGame();
    }

    IEnumerator TitleMusic(AudioClip meteorSound, AudioClip BGM, Camera camera1, Camera camera2, Camera camera3, GameObject Meteor)
    {
        yield return new WaitForSeconds(0.5f);
        SoundManager.instance.SFXPlay("meteoSound!", meteorSound);
        yield return new WaitForSeconds(2f);
        SoundManager.instance.SFXPlay("TitleBGM!", BGM);
        camera1.enabled = false;
        camera2.enabled = true;
        yield return new WaitForSeconds(6f);
        Meteor.SetActive(false);
        camera2.enabled = false;
        camera3.enabled = true;
    }

    public void playGame()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("anykey");
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator RE()
    {
        yield return new WaitForSeconds(45f);
        SceneManager.LoadScene("Title");
    }

}
