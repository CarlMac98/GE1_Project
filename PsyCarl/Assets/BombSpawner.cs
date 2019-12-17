using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxBombs = 5, rng = 30;
    public GameObject bombs;
    public Transform player;

    bool spawning = true;
    void Start()
    {
        IEnumerator spwn = Spawner();
        StartCoroutine(spwn);
        IEnumerator cont = SpwControl();
        StartCoroutine(cont);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpwControl()
    {
        int bombs = GameObject.FindGameObjectsWithTag("Bomb").Length;
        if (bombs < maxBombs && spawning == false)
        {
            StartCoroutine(Spawner());
            spawning = false;
        }

        if (bombs >= maxBombs && spawning == true)
        {
            StopCoroutine(Spawner());
            spawning = false;
        }
        yield return new WaitForSeconds(5.0f);
    }


    IEnumerator Spawner()
    {
        while (true)
        {
            if (GameObject.FindGameObjectsWithTag("Bomb").Length < maxBombs)
            {
                Vector3 posPlayer = player.position;
                Vector3 pos = transform.TransformPoint(new Vector3(Random.Range(-rng, rng) + posPlayer.x, Random.Range(0, 4) + posPlayer.y, Random.Range(-rng, rng) + posPlayer.z));
                Quaternion rot = Quaternion.Euler(0, 0, 0);

                GameObject bombs = GameObject.Instantiate(this.bombs, pos, rot);
                //bombs.AddComponent<Rigidbody>();
                //bombs.AddComponent<OnHit>();
            }

            yield return new WaitForSeconds(1.0f);
        }
    }
}
