using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;

        if (Input.GetKey(KeyCode.W))
        {
            pos.y += 1f;
            myTransform.position = pos;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= 1f;
            myTransform.position = pos;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= 1f;
            myTransform.position = pos;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += 1f;
            myTransform.position = pos;
        }
    }
}
