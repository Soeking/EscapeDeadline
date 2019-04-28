using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalData.isFirst)
        {
            SetObstacles.firstAddLine();
            GlobalData.change();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
