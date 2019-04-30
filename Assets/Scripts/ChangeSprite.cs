using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Image Screen;
    private float alpha;

    public AudioClip Dream;
    public AudioClip Real;
    private float SoundTime = 0;
    private AudioSource audioSource;

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

        if (realtime>=10.0)
        {
            changeSprites();
            realtime = 0;
        }

        if (GlobalData.isBlackOut)
        {
            blackouttime += Time.deltaTime;

            if (blackouttime > 0.6)
            {
                Screen.GetComponent<Image>().color = new Color(0f, 0f, 0f, alpha);
                alpha -= (float) (Time.deltaTime * 0.4);
            }
            
            if (blackouttime>=1.0)
            {
                blackouttime = 0;
                GlobalData.isBlackOut = false;
            }
        }
        else
        {
            alpha = 0;
        }
    }

    public void changeSprites()
    {
        blackOut();
        if (GlobalData.isDream)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            SoundTime = audioSource.time;
            audioSource.clip = Real;
            audioSource.time = SoundTime;
            audioSource.Play();

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
                VARIABLE.GetComponent<BoxCollider2D>().enabled = false;
            }
            GameObject[] monss = GameObject.FindGameObjectsWithTag("monster");
            foreach (var VARIABLE in monss)
            {
                VARIABLE.GetComponent<SpriteRenderer>().enabled = false;
                VARIABLE.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            SoundTime = audioSource.time;
            audioSource.clip = Dream;
            audioSource.time = SoundTime;
            audioSource.Play();

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
                VARIABLE.GetComponent<BoxCollider2D>().enabled = true;
            }
            GameObject[] monss = GameObject.FindGameObjectsWithTag("monster");
            foreach (var VARIABLE in monss)
            {
                VARIABLE.GetComponent<SpriteRenderer>().enabled = true;
                VARIABLE.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        GlobalData.changeReal();
    }

    public void blackOut()
    {
        Screen.GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
        GlobalData.isBlackOut = true;
    }
}
