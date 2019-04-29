using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundFloor : MonoBehaviour
{
    public static float speed = -2f;
    private float right = GlobalData.right;
    public GameObject floor;
    private float backLeft = -8.45f;
    private float backRight = 9.09f;
    private Vector3 backOrigin;
    private Vector3 floorOrigin;
    
    // Start is called before the first frame update
    void Start()
    {
        backOrigin = this.gameObject.transform.position;
        floorOrigin = floor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(Time.deltaTime * speed, 0f, 0f);
        floor.transform.Translate(Time.deltaTime * speed, 0f, 0f);
        if (this.gameObject.transform.position.x<=backLeft)
        {
            this.gameObject.transform.position = new Vector3(backRight, backOrigin.y);
            floor.transform.position = new Vector3(backRight, floorOrigin.y);
        }
    }

    public static void isDash()
    {
        speed = -4f;
    }

    public static void finishDash()
    {
        speed = -2f;
    }

    public static void onStop()
    {
        speed = 0f;
    }
}
