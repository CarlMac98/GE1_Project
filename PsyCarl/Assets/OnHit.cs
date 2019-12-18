using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour
{ 
    private Transform fireball;
    //GameObject sun = new GameObject();
    private bool hit;
    private Vector3 dir = new Vector3();
    private float dist = 0;
    private float speed = 0;
    public int time = 7;
    
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hit = true;
            
        }
        if (collision.gameObject.tag == "Sun")
        {
            Destroy(this.gameObject);
        }
        
    }





    
    void Start()
    {
        Vector3 pos = transform.position;
        
        fireball = GameObject.FindGameObjectWithTag("Sun").transform;

        dir = fireball.position - pos;
        dist = dir.magnitude;
        
        dir.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (hit == true)
        {

            speed = dist / time;
            transform.position += dir * speed * Time.deltaTime;
           
        }
    }
}
