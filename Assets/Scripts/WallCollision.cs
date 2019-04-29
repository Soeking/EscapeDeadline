﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    Quaternion quaternion;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        this.position = gameObject.transform.position;
        this.quaternion = gameObject.transform.rotation;
        switch (gameObject.tag)
        {
            case "Object":
                {
                    break;
                }
            case "item":
                {
                    gameObject.GetComponent<Collider2D>().isTrigger = true;
                    break;
                }
        }
        gameObject.layer = (int)(gameObject.transform.position.y) + 12; 
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, position.y, 0.0f);
        gameObject.transform.rotation = this.quaternion;
        if (gameObject.tag != "item")
        {
            if (gameObject.layer == Human.layer)
            {
                this.gameObject.GetComponent<Collider2D>().isTrigger = false;
                //this.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
            }
            else if (gameObject.layer != Human.layer)
            {
                this.gameObject.GetComponent<Collider2D>().isTrigger = true;
                //this.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            }
        }
        transform.Translate((float)(BackGroundFloor.speed * Time.deltaTime), 0.0f, 0.0f);
        if(transform.position.x <= -12.0f || transform.position.x >= 13.0f || transform.position.y <= -10.0f || transform.position.y >= 10.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == gameObject.layer && collision.gameObject.tag == "Player")
        {
            //BackGroundFloor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == gameObject.layer && collision.gameObject.tag == "Player")
        {

        }
    }
}