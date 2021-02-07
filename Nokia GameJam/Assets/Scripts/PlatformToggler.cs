using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlatformToggler : MonoBehaviour
{

    GameObject[] groupOnePlatforms;
    GameObject[] groupTwoPlatforms;

    public GameObject blackPlayer;
    public GameObject whitePlayer;

    public GameObject win;
    public AudioClip winningClip;
    public AudioClip switchingClip;
    private AudioSource audioSource;
    [SerializeField] private float waitingTimeBeforeLoadNextScene;
    private bool hasWon = false;

    void Start()
    {
        groupOnePlatforms = GameObject.FindGameObjectsWithTag("White");
        groupTwoPlatforms = GameObject.FindGameObjectsWithTag("Black");
        win.SetActive(false);
        audioSource = GetComponent<AudioSource>();
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
            if(!hasWon)
                LevelComplete();
        }

    }

    void LevelComplete()
    {
        hasWon = true;
        win.SetActive(true);
        audioSource.clip = winningClip;
        audioSource.Play();
        StartCoroutine(LoadNextScene(waitingTimeBeforeLoadNextScene));
    }

    private IEnumerator LoadNextScene(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        win.SetActive(false);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++currentSceneIndex);

    }

    void TogglePlatforms()
    {
        audioSource.clip = switchingClip;
        audioSource.Play();
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
