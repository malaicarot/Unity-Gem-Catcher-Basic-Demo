using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{

    // public static float speed = 6f;

    public float timer;

    public float existTime = 4f;



    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= existTime)
        {
            Destroy(gameObject);

            timer = 0;

        }
        // transform.Translate(Vector3.up * speed * Time.deltaTime);

        // if(existTime <= 0){
        //     Destroy(gameObject);
        // } 


    }
}
