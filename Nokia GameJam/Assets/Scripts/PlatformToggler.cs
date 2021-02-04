using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformToggler : MonoBehaviour
{

    GameObject[] whitePlatforms;
    GameObject[] blackPlatforms;

    public GameObject blackPlayer;
    public GameObject whitePlayer;

    public GameObject win;

    void Start()
    {
        whitePlatforms = GameObject.FindGameObjectsWithTag("White");
        blackPlatforms = GameObject.FindGameObjectsWithTag("Black");
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
            Debug.Log("You are win!");
            win.SetActive(true);
        }

    }

    void TogglePlatforms()
    {
        foreach (var platform in whitePlatforms)
        {
            if (!platform.name.Contains("Player"))
            {
                platform.GetComponent<BoxCollider2D>().enabled = !platform.GetComponent<BoxCollider2D>().enabled;
                platform.GetComponent<SpriteRenderer>().enabled = !platform.GetComponent<SpriteRenderer>().enabled;
                
            }
            
        }

        foreach (var platform in blackPlatforms)
        {
            if (!platform.name.Contains("Player"))
            {
                platform.GetComponent<BoxCollider2D>().enabled = !platform.GetComponent<BoxCollider2D>().enabled;
                platform.GetComponent<SpriteRenderer>().enabled = !platform.GetComponent<SpriteRenderer>().enabled;
                
            }
                
        }

       
    }
}
