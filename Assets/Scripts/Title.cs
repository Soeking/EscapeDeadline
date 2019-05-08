using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public Image back;
    public Image image;
    private bool second = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene("Explain");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (second)
            {
                SceneManager.LoadScene("GamePart");
            }
            else
            {
                back.GetComponent<Image>().color = new Color(0.7813148f, 0.4622642f, 1f, 0.682353f);
                image.GetComponent<Image>().enabled = true;
                second = true;
            }
        }
    }
}

