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
                        Instantiate(carObj, new Vector3((i - 5) * 2, j - 4, 0), Quaternion.identity);
                        break;
                    case "cat":
                        Instantiate(catObj, new Vector3((i - 5) * 2, j - 4, 0), Quaternion.identity);
                        break;
                    case "enemy":
                        Instantiate(enemyObj, new Vector3((i - 5) * 2, j - 4, 0), Quaternion.identity);
                        break;
                    case "red":
                        Instantiate(redObj, new Vector3((i - 5) * 2, j - 4, 0), Quaternion.identity);
                        break;
                    case "monster":
                        Instantiate(monsterObj, new Vector3((i - 5) * 2, j - 4, 0), Quaternion.identity);
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
        //BackGround no speed bun idou
        //if idoukyori > x addLine
    }

    void addNewLine()
    {
        string[] newLine = SetObstacles.addLine();
        for (int i = 0; i < 5; i++)
        {
            switch (newLine[i])
            {
                case "car":
                    Instantiate(carObj, new Vector3(10, i - 4, 0), Quaternion.identity);
                    break;
                case "cat":
                    Instantiate(catObj, new Vector3(10, i - 4, 0), Quaternion.identity);
                    break;
                case "enemy":
                    Instantiate(enemyObj, new Vector3(10, i - 4, 0), Quaternion.identity);
                    break;
                case "red":
                    Instantiate(redObj, new Vector3(10, i - 4, 0), Quaternion.identity);
                    break;
                case "monster":
                    Instantiate(monsterObj, new Vector3(10, i - 4, 0), Quaternion.identity);
                    break;
                case "none":
                    break;
            }
        }
    }
}
