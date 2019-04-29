using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //transform.Translate(-0.5f, 0f, 0f);
        /*this.gameObject.AddComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.5f, 0.0f));//*/
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((float)(BackGroundFloor.speed * Time.deltaTime), 0.0f, 0.0f);
        if(transform.position.x <= -12.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == gameObject.layer && collision.gameObject.tag == "Player")
        {
            //BackGroundFloor;
        }
    }
}
