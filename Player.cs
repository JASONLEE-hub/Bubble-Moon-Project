using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigid;

    [SerializeField]
    private float Jump;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private GameObject Effect;

    public int moonCount = 0;

    public AudioClip moonSound;

    public AudioClip intoWater;

    public AudioClip goalSound;

    public AudioClip lifeSound;

    public AudioClip closeMagicSound;

    private void Start()
    {
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = Vector3.zero;
    }

    private void Update()
    {
        /*if (Input.GetButton("Jump"))
        {
            rigid.AddForce(new Vector3(0, Jump, 0), ForceMode.Impulse);

            if (this.transform.position.y > startPoint)
            {
                rigid.AddForce(new Vector3(0, -Jump * 0.9f, 0), ForceMode.Impulse);
            }
            if (this.transform.position.y > startPoint * 1.8f)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, startPoint, this.transform.position.z), Jump * 0.1f);
                Debug.Log("good");
            }
        }

        else if (Input.GetButtonUp("Jump"))
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, startPoint, this.transform.position.z), Jump * 0.1f);
        }

        else if (Input.GetButton("Fire1"))
        {
            rigid.AddForce(new Vector3(0, -Jump, 0), ForceMode.Impulse);

            if (this.transform.position.y < startPoint)
            {
                rigid.AddForce(new Vector3(0, Jump * 0.9f, 0), ForceMode.Impulse);
            }
            if (this.transform.position.y < startPoint * 1.8f)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, startPoint, this.transform.position.z), Jump * 0.1f);
                Debug.Log("good");
            }
        }

        else if (Input.GetButtonUp("Fire1"))
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, startPoint, this.transform.position.z), Jump * 0.1f);
        }*/
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h*0.6f, 0, v*0.6f), ForceMode.Impulse);
        transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Map")
        {
            /*Debug.Log("lifeDown");
            Material mat = GetComponent<MeshRenderer>().material;
            mat.DOFade(0, 1);
            Explosion.SetActive(true);
            Invoke("NOTING", 5f);
            // 터지는 애니메이션 , 리스폰
            GameObject.Find("GameSystem").GetComponent<GameSystem>().playerLifeInt -= 1;
            Explosion.SetActive(false);
            mat.DOFade(1, 0.2f);
            this.transform.position = SpawnPosition;*/
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Moon")
        {
            moonCount++;
            GameSystem.instance.moonUp(moonCount);
            GameSystem.instance.CompassMoonInAct.SetActive(true);
            GameSystem.instance.CompassMoonAct.SetActive(false);
            other.gameObject.SetActive(false);
            SoundManager.instance.SFXPlay("Moon", moonSound);
            Debug.Log("moonUp!");
            if(moonCount == GameObject.Find("GameSystem").GetComponent<GameSystem>().moonFullCountInt)
            {
                GameSystem.instance.Goal.transform.Find("Effect").gameObject.SetActive(true);
            }
        }

        else if (other.tag == "LifeItem")
        {
            GameSystem.instance.playerLifeInt++;
            SoundManager.instance.SFXPlay("Life", lifeSound);
            other.gameObject.SetActive(false);
        }

        else if (other.tag == "Goal")
        {
            if(moonCount == GameObject.Find("GameSystem").GetComponent<GameSystem>().moonFullCountInt)
            {
                GameSystem.instance.Goal.transform.Find("Effect").gameObject.SetActive(false);
                GameSystem.instance.timeBool = false;
                GameSystem.instance.BGM.SetActive(false);
                SoundManager.instance.SFXPlay("Goal", goalSound);
                Effect.SetActive(true);
                rigid.AddForce(new Vector3(0, 500, 0), ForceMode.Impulse);
                rigid.AddForce(new Vector3(0, 500, 0), ForceMode.Impulse);
                rigid.AddForce(new Vector3(0, 500, 0), ForceMode.Impulse);
                Debug.Log("Goal!");
                GameSystem.instance.RESULTS(GameSystem.instance.Play,GameSystem.instance.Results,GameSystem.instance.score,moonCount,GameSystem.instance.moonFullCountInt,GameSystem.instance.time,GameSystem.instance.RANKText,GameSystem.instance.resultScoreText,GameSystem.instance.resultMoonText,GameSystem.instance.resultMoonFullText,GameSystem.instance.resultTimeText);
                // 시간 딜레이
                StartCoroutine(StageUpD());
            }
        }

        else if (other.tag == "Trigger")
        {
            other.transform.Find("Sound").gameObject.SetActive(true);
            GameSystem.instance.CompassMoonInAct.SetActive(false);
            GameSystem.instance.CompassMoonAct.SetActive(true);
        }
        else if (other.tag == "GoalTrigger")
        {
            if(moonCount != GameSystem.instance.moonFullCountInt)
            {
                SoundManager.instance.SFXPlay("Stop!", closeMagicSound);
                rigid.velocity = Vector3.zero;
                rigid.AddForce(new Vector3(0, 0, -70f), ForceMode.Impulse);
            }
        }
        else if (other.tag == "Water")
        {
            Debug.Log("into the water");
            SoundManager.instance.SFXPlay("intoWater", intoWater);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Trigger")
        {
            other.transform.Find("Sound").gameObject.SetActive(false);
            GameSystem.instance.CompassMoonInAct.SetActive(true);
            GameSystem.instance.CompassMoonAct.SetActive(false);
        }
    }

    public void UseGravity(Rigidbody rigid)
    {
        rigid.useGravity = true;
        Debug.Log("UseGravity");
    }

    IEnumerator StageUpD()
    {
        yield return new WaitForSeconds(9f);
        GameSystem.instance.StageUp();
    }

}


