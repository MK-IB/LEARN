using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeshOutOfRandPoints : MonoBehaviour
{
    public int numberOfPoints = 10;
    public Material meshMaterial;
    private Vector3[] points;

    private void Start()
    {
        // Generate random points
        points = new Vector3[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        }

        // Create mesh
        Mesh mesh = new Mesh();
        mesh.vertices = points;

        int[] triangles = new int[(numberOfPoints - 2) * 3];
        for (int i = 0; i < numberOfPoints - 2; i++)
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

    private void OnDrawGizmos()
    {
        if (points.Length == 0) return;
        for (int i = 0; i <= numberOfPoints; i++)
        {
            Gizmos.DrawCube(points[i], Vector3.one * .2f);
        }
    }
}