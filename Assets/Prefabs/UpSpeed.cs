using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpSpeed : MonoBehaviour
{

    public float timeForSpeedUp = 2f;

    public float speedIncrease = 2f;



    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            CharacterMovement characterMovement = other.GetComponent<CharacterMovement>();

            characterMovement.speed *= speedIncrease;

            Destroy(gameObject);


        }
    }

    IEnumerator SpeedReturn(Collider2D player, float originalSpeed)
    {
        yield return new WaitForSeconds(timeForSpeedUp);

        CharacterMovement characterMovement = player.GetComponent<CharacterMovement>();

        characterMovement.speed = originalSpeed;

        Debug.Log("Tốc độ trở về ban đầu: " + characterMovement.speed);


    }


}
