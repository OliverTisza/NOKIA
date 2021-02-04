using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformToggler : MonoBehaviour
{

    GameObject[] groupOnePlatforms;
    GameObject[] groupTwoPlatforms;

    public GameObject blackPlayer;
    public GameObject whitePlayer;

    public GameObject win;

    void Start()
    {
        groupOnePlatforms = GameObject.FindGameObjectsWithTag("White");
        groupTwoPlatforms = GameObject.FindGameObjectsWithTag("Black");
        win.SetActive(false);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TogglePlatforms();
        }

        if( blackPlayer.GetComponent<PlayerMovement>().isFinished && whitePlayer.GetComponent<PlayerMovement>().isFinished)
        {
            //Debug.Log("You are win!");
            LevelComplete();
        }

    }

    void LevelComplete()
    {
        win.SetActive(true);
        /* 
         * Wait x seconds
         * Transition to next level (maybe with parameter?)
        */
    }

    void TogglePlatforms()
    {
        foreach (var platform in groupOnePlatforms)
        {
            if (!platform.name.Contains("Player"))
            {
                platform.GetComponent<BoxCollider2D>().enabled = !platform.GetComponent<BoxCollider2D>().enabled;
                platform.GetComponent<SpriteRenderer>().enabled = !platform.GetComponent<SpriteRenderer>().enabled;
                
            }
            
        }

        foreach (var platform in groupTwoPlatforms)
        {
            if (!platform.name.Contains("Player"))
            {
                platform.GetComponent<BoxCollider2D>().enabled = !platform.GetComponent<BoxCollider2D>().enabled;
                platform.GetComponent<SpriteRenderer>().enabled = !platform.GetComponent<SpriteRenderer>().enabled;
                
            }
                
        }

       
    }
}
