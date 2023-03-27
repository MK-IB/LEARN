using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMesh : MonoBehaviour
{
    public List<Transform> pointTransforms = new List<Transform>();
    public List<Transform> pointsAboveGround = new List<Transform>();
    public Material meshMaterial;

    void Start()
    {
        CreateCircularPoints();
        StartCoroutine(CreateMesh(pointTransforms, true));
        StartCoroutine(CreateMesh(pointsAboveGround, true));
    }

    void CreateCircularPoints()
    {
        Vector3 centerPoint = Vector3.zero;
        GameObject centerGo = new GameObject("Center_Point");
        centerGo.transform.position = centerPoint;
        
        Vector3 offset = new Vector3(0, 0,5);
        pointTransforms.Add(centerGo.transform);
        for (int i = 0; i < 10; i++)
        {
            Vector3 newPointPos = centerPoint + (offset + new Vector3(0.5f * i,0, -0.5f * i));
            GameObject newPoint = new GameObject("Point" + "(" + i +")");
            newPoint.transform.position = newPointPos;
            pointTransforms.Add(newPoint.transform);
        }
        CreatePointsAboveGround();
    }

    void CreatePointsAboveGround()
    {
        for (int i = 0; i < pointTransforms.Count; i++)
        {
            Vector3 newPointPos = pointTransforms[i].position + Vector3.up * 1;
            GameObject newPoint = new GameObject("PointAboveGround" + "(" + i +")");
            newPoint.transform.position = newPointPos;
            pointsAboveGround.Add(newPoint.transform);
        }
    }

    private IEnumerator CreateMesh(List<Transform> pointsList, bool c)
    {
        yield return new WaitForSeconds(0.5f);
        
        var mul = c == true ? 3 : 6;
        var mesh = new Mesh();
        var noOfPoints = pointsList.Count;
        Vector3[] vertices = new Vector3[noOfPoints];
        int[] triangles = new int[(noOfPoints - 2) * mul];

        for (int i = 0; i < noOfPoints - 2; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }
        
        for (int i = 0; i < pointsList.Count; i++)
        {
            vertices[i] = pointsList[i].position;
        }
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        
        GameObject myMesh = new GameObject("My Mesh");
        MeshFilter meshFilter = myMesh.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
        MeshRenderer renderer = myMesh.AddComponent<MeshRenderer>();
        renderer.material = meshMaterial;
        mesh.RecalculateNormals();
    }
    void Update()
    {
        
    }
}
