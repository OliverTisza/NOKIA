using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    [Header("Clamping Options")]
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(player.position.y, minY, maxY), transform.position.z);
    }

}
