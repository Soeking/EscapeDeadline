using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public GameObject BackGroundObj;
    public GameObject FloorObj;
    private float realtime = 0f;
    private float blackouttime = 0f;
    public Sprite BackReal;
    public Sprite BackDream;
    public Sprite FloorReal;
    public Sprite FloorDream;
    public Canvas Canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GlobalData.isDream)
        {
            realtime += Time.deltaTime;
        }

        if (realtime>=5.0)
        {
            changeSprites();
            realtime = 0;
        }

        if (GlobalData.isBlackOut)
        {
            blackouttime += Time.deltaTime;
        }

        if (blackouttime>=0.6)
        {
            blackouttime = 0;
            GlobalData.isBlackOut = false;
        }
    }

    public void changeSprites()
    {
        blackOut();
        if (GlobalData.isDream)
        {
            BackGroundObj.GetComponent<SpriteRenderer>().sprite = BackReal;
            FloorObj.GetComponent<SpriteRenderer>().sprite = FloorReal;

            GameObject[] cars = GameObject.FindGameObjectsWithTag("car");
            foreach (var VARIABLE in cars)
            {
                VARIABLE.GetComponent<SpriteRenderer>().enabled = true;
            }
            GameObject[] cats = GameObject.FindGameObjectsWithTag("cat");
            foreach (var VARIABLE in cats)
            {
                VARIABLE.GetComponent<SpriteRenderer>().enabled = true;
            }
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");
            foreach (var VARIABLE in enemys)
            {
                VARIABLE.GetComponent<SpriteRenderer>().enabled = false;
                VARIABLE.GetComponent<BoxCollider2D>().enabled = false;
            }
            GameObject[] reds = GameObject.FindGameObjectsWithTag("red");
            foreach (var VARIABLE in reds)
            {
                VARIABLE.GetComponent<SpriteRenderer>().enabled = false;
            }
            GameObject[] monss = GameObject.FindGameObjectsWithTag("monster");
            foreach (var VARIABLE in monss)
            {
                VARIABLE.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else
        {
            BackGroundObj.GetComponent<SpriteRenderer>().sprite = BackDream;
            FloorObj.GetComponent<SpriteRenderer>().sprite = FloorDream;
            
            GameObject[] cars = GameObject.FindGameObjectsWithTag("car");
            foreach (var VARIABLE in cars)
            {
                VARIABLE.GetComponent<SpriteRenderer>().enabled = false;
            }
            GameObject[] cats = GameObject.FindGameObjectsWithTag("cat");
            foreach (var VARIABLE in cats)
            {
                VARIABLE.GetComponent<SpriteRenderer>().enabled = false;
            }
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");
            foreach (var VARIABLE in enemys)
            {
                VARIABLE.GetComponent<SpriteRenderer>().enabled = true;
                VARIABLE.GetComponent<BoxCollider2D>().enabled = true;
            }
            GameObject[] reds = GameObject.FindGameObjectsWithTag("red");
            foreach (var VARIABLE in reds)
            {
                VARIABLE.GetComponent<SpriteRenderer>().enabled = true;
            }
            GameObject[] monss = GameObject.FindGameObjectsWithTag("monster");
            foreach (var VARIABLE in monss)
            {
                VARIABLE.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        GlobalData.changeReal();
    }

    public void blackOut()
    {
        GlobalData.isBlackOut = true;
    }
}
