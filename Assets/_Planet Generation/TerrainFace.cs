using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainFace
{
    private Mesh _mesh;
    private int _resolution;
    private Vector3 _localUp;
    private Vector3 axisA, axisB;

    public TerrainFace(Mesh mesh, int resolution, Vector3 localUp)
    {
        _mesh = mesh;
        _resolution = resolution;
        _localUp = localUp;
        
        axisA = new Vector3(localUp.y, localUp.z, localUp.x);
        axisB = Vector3.Cross(localUp, axisA);
    }

    public void ConstructMesh()
    {
        Vector3[] vertices = new Vector3[_resolution * _resolution];
        int[] triangles = new int[(_resolution - 1) *(_resolution - 1) * 6];
        
    }

}
