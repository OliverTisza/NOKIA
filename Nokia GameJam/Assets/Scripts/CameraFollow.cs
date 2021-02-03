using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Player") && collision.GetComponent<Rigidbody2D>().velocity.y > 0.0f)
        {
            //MOVE CAMERA ON Y AXIS

            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 24, gameObject.transform.position.z);
        }
        else if (collision.name.Contains("Player") && collision.GetComponent<Rigidbody2D>().velocity.y < 0.0f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 24, gameObject.transform.position.z);
        }


    }


}
