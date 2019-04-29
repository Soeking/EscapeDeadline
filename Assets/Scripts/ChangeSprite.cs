using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public GameObject BackGroundObj;
    public GameObject FloorObj;
    public GameObject carObj;
    public GameObject catObj;
    public GameObject enemyObj;
    public GameObject redObj;
    public GameObject monsterObj;
    private float realtime = 0f;
    public Sprite BackReal;
    public Sprite BackDream;
    public Sprite FloorReal;
    public Sprite FloorDream;
    public Sprite carPNG;
    public Sprite catPNG;
    public Sprite enemyPNG;
    public Sprite redPNG;
    public Sprite monsterPNG;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!!GlobalData.isDream)
        {
            realtime += Time.deltaTime;
        }

        if (realtime>=5.0)
        {
            changeSprites();
            realtime = 0;
        }
    }

    public void changeSprites()
    {
        blackOut();
        if (GlobalData.isDream)
        {
            BackGroundObj.GetComponent<SpriteRenderer>().sprite = BackReal;
            FloorObj.GetComponent<SpriteRenderer>().sprite = FloorReal;
            carObj.GetComponent<SpriteRenderer>().sprite = carPNG;
            catObj.GetComponent<SpriteRenderer>().sprite = catPNG;
            enemyObj.GetComponent<SpriteRenderer>().sprite = null;
            enemyObj.GetComponent<BoxCollider2D>().isTrigger = true;
            redObj.GetComponent<SpriteRenderer>().sprite = null;
            monsterObj.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            BackGroundObj.GetComponent<SpriteRenderer>().sprite = BackDream;
            FloorObj.GetComponent<SpriteRenderer>().sprite = FloorDream;
            carObj.GetComponent<SpriteRenderer>().sprite = null;
            catObj.GetComponent<SpriteRenderer>().sprite = null;
            enemyObj.GetComponent<SpriteRenderer>().sprite = enemyPNG;
            enemyObj.GetComponent<BoxCollider2D>().isTrigger = false;
            redObj.GetComponent<SpriteRenderer>().sprite = redPNG;
            monsterObj.GetComponent<SpriteRenderer>().sprite = monsterPNG;
        }
        GlobalData.changeReal();
    }

    public void blackOut()
    {
        
    }
}
