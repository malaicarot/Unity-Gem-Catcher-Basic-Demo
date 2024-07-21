using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{

    public float timer;

    public float existTime = 3f;



    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;


        if (timer >= existTime)
        {
            Destroy(gameObject);

            timer = 0;

        }
        
        
    }
}
