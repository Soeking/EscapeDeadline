using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Deadline : MonoBehaviour
{
    private float speed = 4f;
    public Text kyori;
    private float far=300;
    public GameObject Human;
    //public Human human;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GlobalData.isBlackOut)
        {
            this.gameObject.transform.Translate(Time.deltaTime * (speed + BackGroundFloor.speed), 0f, 0f);
        }

        far = Human.transform.position.x - this.gameObject.transform.position.x;
        kyori.text = far + "m";
        if (far>=0)
        {
            gameOver();
        }
    }

    void gameOver()
    {
        GlobalData.score = BackGroundFloor.moveSum + Human.transform.position.x + 8f;
        SceneManager.LoadScene("Result");
    }
}
