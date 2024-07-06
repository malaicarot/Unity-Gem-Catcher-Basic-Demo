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
        // Debug.Log("Phát hiện va chạm giữ viên ngọc này và một game object collider khác!");
        // Debug.Log("đang xử lý va chạm...");
        if (other.gameObject.CompareTag("Player"))
        {
            //Khai báo biến tên audioSource để gán thông tin và các hàm của audio component từ lệnh other.GetComponent<AudioSource>()
            AudioSource audioSource = other.GetComponent<AudioSource>();

            //play âm thanh từ component đó
            audioSource.Play();

            if (gameObject.CompareTag("BlueGem"))
            {
                ScoreManager.AddScore(1);

            }
            else if (gameObject.CompareTag("GreenGem"))
            {
                ScoreManager.AddScore(2);

            }
            else if (gameObject.CompareTag("BlackGem"))
            {
                ScoreManager.AddScore(-1);

            }

            // Debug.Log(gameObject);
            // Debug.Log("viên ngọc đã va chạm với game object có nhãn player");
            Destroy(gameObject);
            // Debug.Log("đã xóa viên ngọc này ");
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            //Khai báo biến tên audioSource để gán thông tin và các hàm của audio component từ lệnh other.GetComponent<AudioSource>()
            AudioSource audioSource = other.GetComponent<AudioSource>();

            //play âm thanh từ component đó
            audioSource.Play();
            // Debug.Log("viên ngọc đã va chạm với game object có nhãn ground");
            Destroy(gameObject);
            // Debug.Log("đã xóa viên ngọc này");
        }
    }

    // public static void DestroyGem()
    // {
    //     speed = 0;
    // }
}
