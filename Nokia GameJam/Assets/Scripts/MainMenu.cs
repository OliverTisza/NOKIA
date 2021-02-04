using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public RectTransform selector;
    public Button[] buttons;
    public Text tutorialText;
    // Start is called before the first frame update
    void Start()
    {
        tutorialText.gameObject.SetActive(false); ;
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            
            if(selector.transform.position.y > 26)
            {
                selector.anchoredPosition -= new Vector2(0,26);
            } else
            {
                selector.anchoredPosition += new Vector2(0, 13);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (selector.anchoredPosition.y >= 0)
            {
                selector.anchoredPosition -= new Vector2(0, 13);
            }
            else
            {
                selector.anchoredPosition += new Vector2(0, 26); 
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Return))
        {
            int case_switch = (int)selector.anchoredPosition.y;

            switch (case_switch)
            {
                case 13:

                    Debug.Log("Start level 1");
                    SceneManager.LoadScene("Level1");
                    break;

                case 0:

                    Debug.Log("Show Tutorial");

                    tutorialText.gameObject.SetActive(true);
                    selector.gameObject.SetActive(false);
                    foreach (var button in buttons)
                    {
                        button.gameObject.SetActive(false); ;
                    }
                    break;

                case -13:
                    Debug.Log("Quit");
                    break;

                default:
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Escape))
        {
            tutorialText.gameObject.SetActive(false);
            selector.gameObject.SetActive(true);
            foreach (var button in buttons)
            {
                button.gameObject.SetActive(true); ;
            }
        }

        
        
        
    }
}
