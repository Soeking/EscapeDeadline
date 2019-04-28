using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Timers;
public class Deadline : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;



        Timer timer = new Timer();
        timer.Interval = 100;
        timer.Elapsed += (s, e) => pos.y += 1f; myTransform.position = pos;
        timer.Start();



    }


}
