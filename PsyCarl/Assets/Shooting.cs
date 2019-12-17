using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(Shoot());
    }

    int fireRate = 2;

    IEnumerator Shoot()
    {
        while (true)
        {
            if (Input.GetButton("Fire1") || Input.GetKey(KeyCode.Mouse0))
            {
                GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
                yield return new WaitForSeconds(1.0f / fireRate);
            }
            yield return null;
        }
    }


    Coroutine cr;

    // Update is called once per frame
    void Update()
    {
       
    }
}