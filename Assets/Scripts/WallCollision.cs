using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    Quaternion quaternion;
    Vector3 position;
    public GameObject redObj;
    public GameObject monsterObj;
    
    void Start()
    {
        this.position = gameObject.transform.position;
        this.quaternion = gameObject.transform.rotation;
        switch (gameObject.tag)
        {
            case "car":
            case "cat":
            case "enemy":
                {
                    break;
                }
            case "red":
            case "monster":
                {
                    gameObject.GetComponent<Collider2D>().isTrigger = true;
                    break;
                }
        }

        int temp = 0;
        float sub = float.MaxValue;

        for(int i = 0; i < GlobalData.yPosition.Length; i++)
        {
            float te = gameObject.transform.position.y - GlobalData.yPosition[i];
            if(Mathf.Abs(te) <= Mathf.Abs(sub))
            {
                sub = te;
                temp = i;
            }
        }
        gameObject.layer = -temp + 12;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, position.y, 0.0f);
        gameObject.transform.rotation = this.quaternion;
        if (gameObject.tag != "red" && gameObject.tag != "monster")
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

        if (!GlobalData.isBlackOut) transform.Translate((float) (BackGroundFloor.speed * Time.deltaTime), 0.0f, 0.0f);
        if(transform.position.x <= -12.0f || transform.position.x >= 13.0f || transform.position.y <= -10.0f || transform.position.y >= 10.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == gameObject.layer && collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "enemy" && Human.Attacking)
            {
                int Ran = (int)Random.Range(0.0f, 10.0f);
                if(Ran < 2)
                {
                    GameObject obj = Instantiate(redObj, gameObject.transform.position, Quaternion.identity);
                    obj.name = "Red";
                    obj.AddComponent<WallCollision>();
                }
                else if(Ran < 4)
                {
                    GameObject obj = Instantiate(monsterObj, gameObject.transform.position, Quaternion.identity);
                    obj.name = "Monster";
                    obj.AddComponent<WallCollision>();
                }
                Destroy(gameObject);
            }
            else
            {
                BackGroundFloor.onStop();
                GlobalData.isStop = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == gameObject.layer && collision.gameObject.tag == "Player")
        {
            BackGroundFloor.finishDash();
            GlobalData.isStop = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == gameObject.layer && collision.gameObject.tag == "Player")
        {
            BackGroundFloor.finishDash();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == gameObject.layer && collision.gameObject.tag == "Player")
        {
            
        }
    }
}
