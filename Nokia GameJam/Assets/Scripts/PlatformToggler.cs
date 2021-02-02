using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformToggler : MonoBehaviour
{

    GameObject[] whitePlatforms;
    GameObject[] blackPlatforms;
    // Start is called before the first frame update
    void Start()
    {
        whitePlatforms = GameObject.FindGameObjectsWithTag("White");
        blackPlatforms = GameObject.FindGameObjectsWithTag("Black");
    }

    // Update is called once per frame
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
            if (platform.GetComponent<SpriteRenderer>())
            {
                platform.GetComponent<BoxCollider2D>().enabled = !platform.GetComponent<BoxCollider2D>().enabled;
                platform.GetComponent<SpriteRenderer>().enabled = !platform.GetComponent<SpriteRenderer>().enabled;
                //platform.tag = "Black";
            }
            
        }

        foreach (var platform in blackPlatforms)
        {
            if (platform.GetComponent<SpriteRenderer>())
            {
                platform.GetComponent<BoxCollider2D>().enabled = !platform.GetComponent<BoxCollider2D>().enabled;
                platform.GetComponent<SpriteRenderer>().enabled = !platform.GetComponent<SpriteRenderer>().enabled;
                //platform.tag = "White";
            }
                
        }

        /*
        whitePlatforms = GameObject.FindGameObjectsWithTag("White");
        blackPlatforms = GameObject.FindGameObjectsWithTag("Black");
        */
    }
}
