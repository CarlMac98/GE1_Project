using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateTerrain : MonoBehaviour
{
    Mesh m;

    Vector3[] vertices;
    int[] triangles;

    public int xSize = 20;
    public int zSize = 20;

    // Start is called before the first frame update
    void Start()
    {
        m = new Mesh();
        GetComponent<MeshFilter>().mesh = m;

        CreateShape();
        UpdateMesh();
    }

    private void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * .4f, z * .4f) * 2f;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int tr = 0, vr = 0;

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
    }

    private void UpdateMesh()
    {
        m.Clear();

        m.vertices = vertices;
        m.triangles = triangles;

        m.RecalculateNormals();
    }
}
