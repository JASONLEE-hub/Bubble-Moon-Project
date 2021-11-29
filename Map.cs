using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private GameObject Explosion;

    private Vector3 SpawnPosition;

    private void Start()
    {
        SpawnPosition = Player.GetComponent<Transform>().position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("이건 되는데");
            Debug.Log("lifeDown");
            Player.SetActive(false);
            Explosion.SetActive(true);
            ReDelay(Player, Explosion);
        }

    }

    IEnumerator ReDelay(GameObject Player, GameObject Explosion)
    {
        yield return new WaitForSeconds(2f);
        
        // 터지는 애니메이션 , 리스폰
        GameObject.Find("GameSystem").GetComponent<GameSystem>().playerLifeInt -= 1;
        Explosion.SetActive(false);
        Player.transform.position = SpawnPosition;
        Player.SetActive(true);
    }

}
