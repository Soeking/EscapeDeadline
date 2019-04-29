using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public GameObject carObj;
    public GameObject catObj;
    public GameObject enemyObj;
    public GameObject redObj;
    public GameObject monsterObj;
    private float moving = 0f;
    private float[] yPosition = GlobalData.yPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalData.isFirst)
        {
            SetObstacles.firstAddLine();
            GlobalData.change();
        }

        for (int i = 5; i < 10; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                switch (SetObstacles.obstacles[i][j])
                {
                    case "car":
                        {
                            GameObject obj = Instantiate(carObj, new Vector3((i - 5) * 2, yPosition[j], 0), Quaternion.identity);
                            obj.name = "Car" + i.ToString() + j.ToString();
                            obj.AddComponent<WallCollision>();
                        }
                        break;
                    case "cat":
                        {
                            GameObject obj = Instantiate(catObj, new Vector3((i - 5) * 2, yPosition[j], 0), Quaternion.identity);
                            obj.name = "Cat" + i.ToString() + j.ToString();
                            obj.AddComponent<WallCollision>();
                        }
                        break;
                    case "enemy":
                        {
                            GameObject obj = Instantiate(enemyObj, new Vector3((i - 5) * 2, yPosition[j], 0), Quaternion.identity);
                            obj.name = "Enemy" + i.ToString() + j.ToString();
                            obj.AddComponent<WallCollision>();
                        }
                        break;
                    case "red":
                        {
                            GameObject obj = Instantiate(redObj, new Vector3((i - 5) * 2, yPosition[j], 0), Quaternion.identity);
                            obj.name = "Red" + i.ToString() + j.ToString();
                            obj.AddComponent<WallCollision>();
                        }
                        break;
                    case "monster":
                        {
                            GameObject obj = Instantiate(monsterObj, new Vector3((i - 5) * 2, yPosition[j], 0), Quaternion.identity);
                            obj.name = "Monster" + i.ToString() + j.ToString();
                            obj.AddComponent<WallCollision>();
                        }
                        break;
                    case "none":
                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.moving += BackGroundFloor.speed * Time.deltaTime;
        if (this.moving >= 2f)
        {
            this.moving -= 2f;
            this.addNewLine();
        }
        else if(this.moving <= -2f)
        {
            this.moving += 2f;
            this.addNewLine();
        }
        //BackGround no speed bun idou
        //if idoukyori > x addLine
    }

    private const int SpawnY = 12;

    void addNewLine()
    {
        string[] newLine = SetObstacles.addLine();
        for (int i = 0; i < 5; i++)
        {
            switch (newLine[i])
            {
                case "car":
                    {
                        GameObject obj = Instantiate(carObj, new Vector3(SpawnY, yPosition[i], 0), Quaternion.identity);
                        obj.name = "Car" + i.ToString();
                        obj.AddComponent<WallCollision>();
                        if (!GlobalData.isDream)
                        {
                            obj.GetComponent<SpriteRenderer>().enabled = true;
                        }
                    }
                    break;
                case "cat":
                    {
                        GameObject obj = Instantiate(catObj, new Vector3(SpawnY, yPosition[i], 0), Quaternion.identity);
                        obj.name = "Cat" + i.ToString();
                        obj.AddComponent<WallCollision>();
                        if (!GlobalData.isDream)
                        {
                            obj.GetComponent<SpriteRenderer>().enabled = true;
                        }
                    }
                    break;
                case "enemy":
                    {
                        GameObject obj = Instantiate(enemyObj, new Vector3(SpawnY, yPosition[i], 0), Quaternion.identity);
                        obj.name = "Enemy" + i.ToString();
                        obj.AddComponent<WallCollision>();
                        if (!GlobalData.isDream)
                        {
                            obj.GetComponent<SpriteRenderer>().enabled = false;
                            obj.GetComponent<BoxCollider2D>().enabled = false;
                        }
                    }
                    break;
                case "red":
                    {
                        GameObject obj = Instantiate(redObj, new Vector3(SpawnY, yPosition[i], 0), Quaternion.identity);
                        obj.name = "Red" + i.ToString();
                        obj.AddComponent<WallCollision>();
                    }
                    break;
                case "monster":
                    {
                        GameObject obj = Instantiate(monsterObj, new Vector3(SpawnY, yPosition[i], 0), Quaternion.identity);
                        obj.name = "Monster" + i.ToString();
                        obj.AddComponent<WallCollision>();
                    }
                    break;
                case "none":
                    break;
            }
        }
    }
}
