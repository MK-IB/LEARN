using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeshOutOfRandPoints : MonoBehaviour
{
    public Transform pointsParent;
    List<Vector3> pointTransforms = new List<Vector3>();
    public Material meshMaterial;
    private Vector3[] points;
    private Mesh mesh;

    private void Start()
    {
        for (int i = 0; i < pointsParent.childCount; i++)
        {
            pointTransforms.Add(pointsParent.GetChild(i).position);
        }
        points = new Vector3[pointTransforms.Count];
        for (int i = 0; i < pointTransforms.Count; i++)
        {
            points[i] = pointTransforms[i];
        }

        // Create mesh
        mesh = new Mesh();
        mesh.vertices = points;

        int[] triangles = new int[(pointTransforms.Count - 2) * 3];
        for (int i = 0; i < pointTransforms.Count - 2; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        } 

        mesh.triangles = triangles;

        // Assign mesh to MeshFilter
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        // Assign material to MeshRenderer
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = meshMaterial;
    }

    /*void SetNormals()
    {
        //Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] normals = mesh.normals;
        Vector3 surfaceNormal = transform.up;

        for (int i = 0; i < normals.Length; i++)
        {
            if (Vector3.Dot(normals[i], surfaceNormal) < 0)
            {
                normals[i] = -normals[i];
            }
        }

        mesh.normals = normals;
    }*/
    /*private void OnDrawGizmos()
    {
        if (points.Length == 0) return;
        for (int i = 0; i <= numberOfPoints; i++)
        {
            Gizmos.DrawCube(points[i], Vector3.one * .2f);
        }
    }*/
}