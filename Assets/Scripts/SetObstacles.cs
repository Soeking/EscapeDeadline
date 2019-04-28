using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SetObstacles : MonoBehaviour
{
    public static string[] obstaclesElement = { "car","cat","enemy","red","monster","none","none","none","none","none"};
    public static List<string[]> obstacles = new List<string[]>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void firstAddLine()
    {
        for (int j = 0; j < 10; j++)
        {
            string[] tateLine = new String[5];
            for (int i = 0; i < 5; i++)
            {
                tateLine[i] = obstaclesElement[Random.Range(0, 10)];
            }   
            obstacles.Add(tateLine);
        }
    }
    
    public static void addLine()
    {
        string[] tateLine = new String[5];
        for (int i = 0; i < 5; i++)
        {
            tateLine[i] = obstaclesElement[Random.Range(0, 10)];
        }   
        obstacles.Add(tateLine);
    }

    public static void deleteLine()
    {
        obstacles.RemoveAt(0);
    }
}
