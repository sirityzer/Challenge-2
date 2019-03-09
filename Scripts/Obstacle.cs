using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Vector3 pos1 = new Vector3(-3, 0, 0);
    private Vector3 pos2 = new Vector3(3, 0, 0);
    public float speed = 0.5f;
    private Vector3 start;

    void Start()
    {
        start = gameObject.transform.position;
    }
 
    void Update()
    {
        transform.position = Vector3.Lerp(start+pos1, start+pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}

