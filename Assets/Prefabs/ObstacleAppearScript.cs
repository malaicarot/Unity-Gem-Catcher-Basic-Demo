using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject obstaclePrefab;
    public float timer;

    public float spawnInterval = 3f;

    public ScoreManager _ScoreManager;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Spawner();
            timer = 0;
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
            Vector3 spawnPosition = new Vector3(randomX, 1f, 0); //Vector3(tọa độ x, tọa độ y và chiều sâu z)
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        }

    }
}
