using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


// Trạng thái nhảy
// public enum JumpState
// {
//     Grounded,
//     PrepareToJump,
//     Jumping,
//     InFlight,
//     Landed
// }

public class CharacterMovement : MonoBehaviour
{

    public float jumpForce = 100f;

    [SerializeField] private float y_position;

    public ScoreManager _ScoreManager;

    public float speed = 5.0f;
    [SerializeField] private Animator animator;
    public Rigidbody2D rb;

    public float timer;

    public float timeForSpeedUp = 8f;


    private bool isGrounded;

    private int jumpCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // animator = GetComponent<Animator>(); //bắt đầu animation khép mở chân
    }

    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= timeForSpeedUp)
        {
            speed = 5.0f;
            timer = 0;

        }

        if (_ScoreManager._gameState == gameState.gameOver)
        {

            return;

        }


        float moveHorizontal = Input.GetAxis("Horizontal");
        bool isMoving = moveHorizontal != 0; // khai báo biến isMoving
        animator.SetBool("isMoving", isMoving);

        // float jumpBtn = Input.GetAxis("Jump");
        // bool isGrounded = jumpBtn != 0;
        // animator.SetBool("isGrounded", isGrounded);


        if (isMoving) // nếu nhân vật đang di chuyển
        {
            transform.position += new Vector3(moveHorizontal * speed * Time.deltaTime, 0f, 0f);
        }

        float jump = Input.GetAxis("Jump");
        isGrounded = gameObject.transform.position.y <= y_position;

        animator.SetBool("isGrounded", isGrounded && jump != 0);



        if (jumpCount < 2 && jump != 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpCount++;
        }

        if (isGrounded)
        {
            jumpCount = 0;
        }

    }



}
