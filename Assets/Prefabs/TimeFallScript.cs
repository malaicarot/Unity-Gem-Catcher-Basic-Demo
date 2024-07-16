using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFallScript : MonoBehaviour
{
    public GameObject addTime;

    public GameObject minusTime;


    // Thoi gian duoc tinh tu lan cuoi 1 vat pham thoi gian duoc sinh ra
    public float timer;
    // Thoi gian mot vat pham thoi gian moi duoc sinh ra
    public float spawnInterval = 6f;

    public ScoreManager _ScoreManager;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Spawner(); // Ham sinh gem

            timer = 0;

        }

    }

    void Spawner()
    {

        if (_ScoreManager._gameState == gameState.gameOver) // neu trang thai gameOver thi khong thuc hien sinh Gem
        {

            return;

        }
        else
        {
            float randomGem = Random.Range(1f, 10f); // random 2 loai vat pham

            float randomX = Random.Range(-8f, 8f); // Gem duoc sinh ngau nhien tren truc ngang man hinh

            // Tạo ra viên ngọc tại vị trí ở trên màn hình. 
            Vector3 spawnPosition = new Vector3(randomX, 15f, 0); //Vector3(tọa độ x, tọa độ y và chiều sâu z)


            if (randomGem < 6)
            {
                // Sử dụng Instantiate để tạo ra một bản sao của prefab viên ngọc tại vị trí và hướng quy định.
                Instantiate(addTime, spawnPosition, Quaternion.identity); // Instantiate(Object nào, vị trí nào, không có hướng quay)

            }
            else
            {
                Instantiate(minusTime, spawnPosition, Quaternion.identity);
            }
        }

    }
}
