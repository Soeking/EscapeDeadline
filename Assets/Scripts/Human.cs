using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{

    private bool UpDown = false;
    private const float moveSpeed = 3f;
    private float deltaTimes = 0f;

    public Sprite Right;
    public Sprite Left;
    public Sprite Normal;
    public Sprite Jump;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        this.deltaTimes += Time.deltaTime;

        if (this.deltaTimes >= 1.0) this.deltaTimes -= 1.0f;

        if (this.deltaTimes >= 0.75)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Right;
        }
        else if (this.deltaTimes >= 0.5)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Normal;
        }
        else if (this.deltaTimes >= 0.25)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Left;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Normal;
        }

        if (!UpDown)
        {
            if (Input.GetKey(KeyCode.W) && pos.y < 0)
            {
                pos.y += 1f;
                myTransform.position = pos;
                gameObject.layer = (int)(pos.y) + 12;
                UpDown = true;
            }
            if (Input.GetKey(KeyCode.S) && pos.y > -4)
            {
                pos.y -= 1f;
                myTransform.position = pos;
                gameObject.layer = (int)(pos.y) + 12;
                UpDown = true;
            }
        }
        else if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            UpDown = false;
        }

        if (Input.GetKey(KeyCode.A) && pos.x > -8)
        {
            pos.x -= moveSpeed * Time.deltaTime;
            myTransform.position = pos;
        }
        if (Input.GetKey(KeyCode.D) && pos.x < 8)
        {
            pos.x += moveSpeed * Time.deltaTime;
            myTransform.position = pos;
        }
    }
}
