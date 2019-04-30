using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Text score;
    public Image back;
    private bool second = false;
    
    // Start is called before the first frame update
    void Start()
    {
        score.text = "SCORE : " + GlobalData.score + " m";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (second)
            {
                SceneManager.LoadScene("Title");
            }
            else
            {
                score.GetComponent<Text>().color = new Color(0f, 0f, 0f, 1f);
                back.GetComponent<Image>().color = new Color(0.71610f, 0.9716981f, 0.1191705f, 0.6f);
                second = true;
            }
        }
    }
}
