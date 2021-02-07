using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button[] buttons;
    public Text tutorialText;

    private int activeIndex = 0;
    private Vector2 highlightedVector = new Vector2(5, -5);
    private Vector2 outlinedVector = new Vector2(3, -3);
    private AudioSource audioSource;

    // 0 - Start
    // 1 - Tutorial
    // 2 - Exit

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        tutorialText.gameObject.SetActive(false); ;
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(true);
        }

        buttons[0].GetComponent<Outline>().effectDistance = highlightedVector;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            SetButtonsToDefault();
            activeIndex--;
            if (activeIndex < 0) activeIndex = 2;
            buttons[activeIndex].GetComponent<Outline>().effectDistance = highlightedVector;


        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SetButtonsToDefault();
            activeIndex++;
            if (activeIndex > 2) activeIndex = 0;
            buttons[activeIndex].GetComponent<Outline>().effectDistance = highlightedVector;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Return))
        {
            switch(activeIndex)
            {
                case 0:
                    Debug.Log("Start level 1");
                    SceneManager.LoadScene(1);
                    break;
                case 1:
                    Debug.Log("Show Tutorial");
                    audioSource.Play();
                    tutorialText.gameObject.SetActive(true);
                    foreach (var button in buttons)
                    {
                        button.gameObject.SetActive(false); ;
                    }
                    break;
                case 2:
                    Application.Quit();
                    Debug.Log("Quit");
                    break;
            }

        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Escape))
        {
            audioSource.Play();
            tutorialText.gameObject.SetActive(false);
            foreach (var button in buttons)
            {
                button.gameObject.SetActive(true); ;
            }
        }

        
        
        
    }

    private void SetButtonsToDefault()
    {
        audioSource.Play();

        foreach(var b in buttons)
        {
            b.GetComponent<Outline>().effectDistance = outlinedVector;
        }
    }
}
