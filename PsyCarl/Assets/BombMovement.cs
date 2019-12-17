using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    
    public float var = 5f;
    public float floVel = 1f;
    public float degreesPerSecond = 30f;

    Vector3 initialPos = new Vector3();
    Vector3 floating = new Vector3();

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        degreesPerSecond = Random.Range(10f, 160f);
        var = Random.Range(2f, 15f);
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    { 
        transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime * 2.0f);
        transform.LookAt(player);
        
        floating = initialPos;

        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f));

        floating.y += Mathf.Sin(Time.fixedTime * Mathf.PI * floVel/4) * var;
        transform.position = floating;
    }
}
