using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GemMover : MonoBehaviour
{
 
    public static float speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime); //tạo chuyển động theo phương thẳng đứng hướng xuống với tốc độ trên theo thời gian
    }

    void OnTriggerEnter2D(Collider2D other) //other chính là thông tin của bất kỳ collider nào va chạm với collider này
    {

        if (other.gameObject.CompareTag("Player"))
        {
            //Khai báo biến tên audioSource để gán thông tin và các hàm của audio component từ lệnh other.GetComponent<AudioSource>()
            AudioSource audioSource = other.GetComponent<AudioSource>();

            //play âm thanh từ component đó
            audioSource.Play();

            if (gameObject.CompareTag("BlueGem"))
            {
                ScoreManager.AddScore(1);
                Destroy(gameObject);

            }
            else if (gameObject.CompareTag("GreenGem"))
            {
                ScoreManager.AddScore(2);
                Destroy(gameObject);

            }
            else if (gameObject.CompareTag("BlackGem"))
            {
                ScoreManager.AddScore(-1);
                Destroy(gameObject);

            }
              else if (gameObject.CompareTag("AddTime"))
            {
                ScoreManager.AddTime(5);
                Destroy(gameObject);

            }
              else if (gameObject.CompareTag("SubTime"))
            {
                ScoreManager.AddTime(-3);
                Destroy(gameObject);

            }

        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            //Khai báo biến tên audioSource để gán thông tin và các hàm của audio component từ lệnh other.GetComponent<AudioSource>()
            AudioSource audioSource = other.GetComponent<AudioSource>();

            //play âm thanh từ component đó
            audioSource.Play();
            Destroy(gameObject);
        }
    }


}
