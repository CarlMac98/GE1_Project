using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChilds : MonoBehaviour
{
    List<GameObject> childs = new List<GameObject>();
    // Start is called before the first frame update

    public float scale = 10;
    void Start()
    {
        foreach (Transform child in transform)
        {
            childs.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    { 
        int b = Random.Range(0,9);
        for (int i = 0; i < childs.Count; i++)
        {
            
            Vector3 ls = childs[i].transform.localScale;
            ls.z = Mathf.Lerp(ls.z, 1 + (AudioAnalyzer.bands[b] * scale), Time.deltaTime * 3.0f);
            childs[i].transform.localScale = ls;
        }
    }
}
