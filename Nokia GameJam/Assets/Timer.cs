using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<AudioSource>().Play();   
            SceneManager.LoadScene(0);
        }
    }
}
