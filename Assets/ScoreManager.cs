using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public enum gameState
{
    playing,
    pause,
    gameOver
};

public class ScoreManager : MonoBehaviour
{

    // Luu trang thai game

    public gameState _gameState;


    // tạo một biến số điểm bắt đầu bằng 0 để lưu giá trị điểm của người chơi
    public static int score = 0; //static sẽ được giải thích sau trong chương c#

    private float remainingTime;


    public GameObject gameOverPanel;

    public TextMeshProUGUI scoreText; // tạo một biến thuộc kiểu TextMeshProUGUI tên scoreText và có thể truy cập từ Unity Editor

    public TextMeshProUGUI gameOverText;

    // khai báo một hàm dành cho lớp ScoreManager nhằm tăng số điểm của người chơi
    public static void AddScore(int amount) //(int amount) nghĩa là hàm sẽ chỉ nhận giá trị là integer, và giá trị này sẽ được gán vào biến có tên amount
    {
        score += amount; //tăng điểm theo giá trị của amount được truyền vào tại sự kiện gọi AddScore
    }

    void Start() // đếm giờ khi trò chơi bắt đầu
    {

        _gameState = gameState.playing;
        remainingTime = 5f; //thời gian còn lại tại thời điểm bắt đầu bằng 30s (thời lượng của trò chơi)
        StartCoroutine(CountdownTimer());
        // là một phương thức nâng cao để gọi hàm CountdownTimer
        // nhằm cho phép đồng hồ chạy song song, tiếp tục đếm khi chuyển qua frame mới và kết thúc ở frame mới khi đạt đúng thời gian
    }


    // Update is called once per frame
    void Update()
    {
        // cập nhật điểm hiển thị trên UI
        scoreText.text = "Score: " + score + " | Time: " + Mathf.CeilToInt(remainingTime); // -> Score: 10 hoặc Score: 5 ...
        if (remainingTime <= 0)
        {
            GameOver();
        }
    }


    private IEnumerator CountdownTimer()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }
    }

    private void GameOver()
    {

        gameOverText.text = "Game Over!\nScore: " + score;
        gameOverPanel.SetActive(true);



        _gameState = gameState.gameOver;


        // GemMover.DestroyGem();
        // Time.timeScale = 0;

    }

    public void OnReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


    public void OnQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif

    }


}
