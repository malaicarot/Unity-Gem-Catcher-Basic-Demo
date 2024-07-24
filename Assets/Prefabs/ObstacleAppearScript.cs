using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject obstaclePrefab;
    public float timer;

    public float spawnInterval = 3f;

    public ScoreManager _ScoreManager;

    public float riseSpeed = 2.0f;


    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            Spawner();
        }
    }




    // Update is called once per frame
    // void Update()
    // {
    //     timer += Time.deltaTime;
    //     if (timer >= spawnInterval)
    //     {
    //         Spawner();
    //         timer = 0;
    //     }

    // }

    void Spawner()
    {
        if (_ScoreManager._gameState == gameState.gameOver)
        {
            return;
        }
        else
        {
            float randomX = Random.Range(-8f, 8f);
            Vector3 spawnPosition = new Vector3(randomX, 0.03f, 0); // Vị trí xuất hiện đầu tiên của chướng ngại là dưới mặt đất

            GameObject spawnerWood = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

           StartCoroutine(RiseObstacle(spawnerWood));

        }

    }


    // Hàm di chuyển chướng ngại từ dưới mặt đất lên mặt đất

  IEnumerator RiseObstacle (GameObject obstacle)
    {

        Vector3 targetPosition = new Vector3(obstacle.transform.position.x, 1.22f, obstacle.transform.position.z); // vị trí chướng ngại sẽ là ở trên mặt đất


        while (obstacle.transform.position != targetPosition) // nếu chướng ngại còn ở dưới mặt đất => di chuyển lên
        {
            obstacle.transform.position = Vector3.MoveTowards(obstacle.transform.position, targetPosition, riseSpeed * Time.deltaTime);

            yield return null;

        }

        yield return new WaitForSeconds(spawnInterval);

        Destroy(obstacle);
    }

}



