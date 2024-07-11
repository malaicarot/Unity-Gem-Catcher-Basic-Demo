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

    public ScoreManager _ScoreManager;

    public float speed = 5.0f;
    private Animator animator;
    public Rigidbody2D rb;


    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); //bắt đầu animation khép mở chân
    }

    void Update()
    {

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
        isGrounded = jump != 0; // khai báo biến isMoving
        animator.SetBool("isGrounded", isGrounded);
        if (isGrounded)
        {
            isGrounded = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }



    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("CloneGround"))
    //     {
    //         // rb.AddForce(Vector3.down * jumpForce, ForceMode2D.Force);


    //     }
    // }



}
