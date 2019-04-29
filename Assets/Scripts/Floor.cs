using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    Vector3 position;
    Quaternion quaternion;
    // Start is called before the first frame update
    void Start()
    {
        this.position = gameObject.transform.position;
        this.quaternion = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = this.quaternion;
        gameObject.transform.position = this.position;
        if (gameObject.layer == Human.layer) this.gameObject.GetComponent<Collider2D>().isTrigger = false;
        else if (gameObject.layer != Human.layer) this.gameObject.GetComponent<Collider2D>().isTrigger = true;
    }
}
