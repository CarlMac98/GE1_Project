//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateTerrain : MonoBehaviour
{
    Mesh m;

    Vector3[] vertices;
    int[] triangles;

    private int xSize = 200;
    private int zSize = 200;

    float maxH;
    float minH;

    public float scale = 10f;
    public float thickness = 20f;

    public float xOffset = 100f;
    public float zOffset = 100f;

    public float threshold = 4f;

    Color[] colors;
    public Gradient gradient;

    // Start is called before the first frame update
    void Start()
    {
        m = new Mesh();
        GetComponent<MeshFilter>().mesh = m;

        xOffset = Random.Range(0f, 9999f);
        zOffset = Random.Range(0f, 9999f);

        transform.position = new Vector3(-xSize / 2, 0, -zSize / 2);

        CreateShape();
        UpdateMesh();
    }

    void Update()
    {
 
    }

    private void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float xC = (float)x / scale + xOffset;
                float zC = (float)z / scale + zOffset;

                float y = (Mathf.PerlinNoise(xC, zC) * 2 - 1) * thickness;
                //float w = Random.Range(0f, threshold);
                if (y < -threshold || y > threshold)
                {
                    vertices[i] = new Vector3(x, y, z);
                    if (y < minH)
                        minH = y;
                    if (y > maxH)
                        maxH = y;
                }
                else
                {
                    //float w = Random.Range(0f, threshold);
                    vertices[i] = new Vector3(x, 0, z);
                }
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int tr = 0, vr = 0;
        //int maxsize = Mathf.Max(xSize, zSize);

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {

                triangles[tr] = vr;
                triangles[tr + 1] = vr + xSize + 1;
                triangles[tr + 2] = vr  + 1;
                triangles[tr + 3] = vr + 1;
                triangles[tr + 4] = vr + xSize + 1;
                triangles[tr + 5] = vr + xSize + 2;

                vr++;
                tr += 6;
            }
            vr++;
        }

        colors = new Color[vertices.Length];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            { 
                if (vertices[i].y > -10)
                {
                    float height = Mathf.InverseLerp(-10, maxH, vertices[i].y);
                    colors[i] = gradient.Evaluate(height);
                }
                else
                {
                    colors[i] = new Color(255, 255, 0);
                }
                i++;
            }
        }
    }

    private void UpdateMesh()
    {
        m.Clear();

        m.vertices = vertices;
        m.triangles = triangles;
        m.colors = colors;

        m.RecalculateNormals();
    }
}
