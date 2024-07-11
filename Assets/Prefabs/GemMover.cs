using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GemMover : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {

    // }

    // Update is called once per frame
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
