using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformToggler : MonoBehaviour
{

    GameObject[] whitePlatforms;
    GameObject[] blackPlatforms;
   
    void Start()
    {
        whitePlatforms = GameObject.FindGameObjectsWithTag("White");
        blackPlatforms = GameObject.FindGameObjectsWithTag("Black");
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TogglePlatforms();
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
