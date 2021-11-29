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


    int moonCount = 0;

    private void Start()
    {

    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(new Vector3(0, Jump, 0), ForceMode.Impulse);
        }
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
            GameObject.Find("GameSystem").GetComponent<GameSystem>().moonUp(moonCount);
            other.gameObject.SetActive(false);
            Debug.Log("moonUp!");
        }

        else if (other.tag == "Goal")
        {
            if(moonCount == GameObject.Find("GameSystem").GetComponent<GameSystem>().moonFullCountInt)
            {
                GameObject.Find("GameSystem").GetComponent<GameSystem>().timeBool = false;
                rigid.AddForce(new Vector3(0, 500, 0), ForceMode.Impulse);
                rigid.AddForce(new Vector3(0, 500, 0), ForceMode.Impulse);
                rigid.AddForce(new Vector3(0, 500, 0), ForceMode.Impulse);
                Debug.Log("Goal!");
                Invoke("NOTING", 4f);
                GameObject.Find("GameSystem").GetComponent<GameSystem>().StageUp();
            }
        }

        else if (other.tag == "Trigger")
        {
            GameObject.Find("GameSystem").GetComponent<GameSystem>().CompassMoonInAct.SetActive(false);
            GameObject.Find("GameSystem").GetComponent<GameSystem>().CompassMoonAct.SetActive(true);
        }
        else if (other.tag == "GoalTrigger")
        {
            if(moonCount != GameObject.Find("GameSystem").GetComponent<GameSystem>().moonFullCountInt)
            rigid.AddForce(new Vector3(0,0,-100f),ForceMode.Impulse);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Trigger")
        {
            GameObject.Find("GameSystem").GetComponent<GameSystem>().CompassMoonInAct.SetActive(true);
            GameObject.Find("GameSystem").GetComponent<GameSystem>().CompassMoonAct.SetActive(false);
        }
    }

    public void UseGravity(Rigidbody rigid)
    {
        rigid.useGravity = true;
        Debug.Log("UseGravity");
    }

    public void NOTING()
    {
        Debug.Log("NOTING!");
    }

}


