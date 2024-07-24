using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedItemsSpawn : MonoBehaviour
{

    public GameObject speedItems;

    public float spawnInterval = 5f;

    public float speedIncrease = 2f;


    public ScoreManager _ScoreManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpwanSpeedItems());

    }

    

    IEnumerator SpwanSpeedItems()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            Spawner();

        }
    }


    void Spawner()
    {

        if (_ScoreManager._gameState == gameState.gameOver)
        {
            return;
        }
        else
        {
            float randomX = Random.Range(-8f, 8f);

            Vector3 spawnPosition = new Vector3(randomX, 1f, 0);

            // GameObject spawnerSpeed = 
            Instantiate(speedItems, spawnPosition, Quaternion.identity);
            // StartCoroutine(AutoDestroyItems(spawnerSpeed));
        }

    }


    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         StartCoroutine(SpeedUp(other));
    //         Destroy(gameObject);
    //     }
    // }



    // IEnumerator SpeedUp(Collider2D player)
    // {

    //     CharacterMovement characterMovement = player.GetComponent<CharacterMovement>();
    //     if (characterMovement != null)
    //     {
    //         characterMovement.speed *= speedIncrease;
    //         Debug.Log("Tốc độ tăng: " + characterMovement.speed);

    //         yield return new WaitForSeconds(spawnInterval);

    //         // // Trả lại tốc độ ban đầu
    //         characterMovement.speed /= speedIncrease;

    //         Debug.Log("Tốc độ trở về ban đầu: " + characterMovement.speed);

    //     }
    //     Debug.Log("Hủy GameObject");
    //     Destroy(gameObject);
    // }

    // IEnumerator AutoDestroyItems(GameObject speed){

    //     yield return new WaitForSeconds(spawnInterval);

    //     Destroy(speed);

    // }
}
