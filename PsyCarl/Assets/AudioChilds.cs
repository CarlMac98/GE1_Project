using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChilds : MonoBehaviour
{
    List<GameObject> childs = new List<GameObject>();
    private int b = 0;
    // Start is called before the first frame update

    public float scale = 10;
    void Start()
    {
        b = Random.Range(0, 9);

        foreach (Transform child in transform)
        {
            childs.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    { 
        
        for (int i = 0; i < childs.Count; i++)
        {
            Vector3 ls = childs[i].transform.localScale;
            ls.z = Mathf.Lerp(ls.z, 1 + (AudioAnalyzer.bands[b] * scale), Time.deltaTime * 7.0f);
            childs[i].transform.localScale = ls;
        }
    }
}
