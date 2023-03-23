using System;
using System.Collections;
using System.Collections.Generic;
using Obi;
using Unity.VisualScripting;
using UnityEngine;

public class MyRope : MonoBehaviour
{
    public ObiSolver solver;
    public List<Transform> ropePoints;
    public Material ropeMaterial;

    private ObiRopeBlueprint _ropeBlueprint;
    private List<int> myIndices = new List<int>();

    private void Start()
    {
        StartCoroutine(CreateBlueprint());
    }

    IEnumerator CreateBlueprint()
    {
        var blueprint = ScriptableObject.CreateInstance<ObiRopeBlueprint>();
        int filter = 1;
        blueprint.path.Clear();
        for (int i = 0; i < ropePoints.Count; i++)
        {
            if (i == 0)
            {
                blueprint.path.AddControlPoint(ropePoints[i].position, -Vector3.right, Vector3.right, Vector3.up, 0.1f,
                    0.1f, 1, filter, Color.white, "start");
                myIndices.Add(1);
            }

            if (i == ropePoints.Count - 1)
            {
                ropePoints[i].position = ropePoints[0].position;
                blueprint.path.AddControlPoint(ropePoints[i].position, -Vector3.right, Vector3.right, Vector3.up, 0.1f,
                    0.1f, 1, filter, Color.white, "end");
                //myIndices.Add(2);
            }

            else
            {
                blueprint.path.AddControlPoint(ropePoints[i].position, -Vector3.right, Vector3.right, Vector3.up, 0.1f,
                    0.1f, 1, filter, Color.white, "controlpoint");
                //myIndices.Add(3);
            }
        }

        /*blueprint.path.AddControlPoint(Vector3.zero, -Vector3.right, Vector3.right, Vector3.up, 0.1f, 0.1f, 1, filter, Color.white, "start");
        blueprint.path.AddControlPoint(Vector3.one, -Vector3.right, Vector3.right, Vector3.up, 0.1f, 0.1f, 1, filter, Color.white, "end");*/
        blueprint.path.FlushEvents();

        yield return StartCoroutine(blueprint.Generate());
        _ropeBlueprint = blueprint;
        CreateRope();
    }

    void CreateRope()
    {
        GameObject ropeObject = new GameObject("rope", typeof(ObiRope), typeof(ObiRopeExtrudedRenderer));

// get component references:
        ObiRope rope = ropeObject.GetComponent<ObiRope>();
        ObiRopeExtrudedRenderer ropeRenderer = ropeObject.GetComponent<ObiRopeExtrudedRenderer>();
        ropeObject.GetComponent<Renderer>().material = ropeMaterial;

// load the default rope section:
        ropeRenderer.section = Resources.Load<ObiRopeSection>("DefaultRopeSection");

// instantiate and set the blueprint:
        ObiParticleAttachment attach = rope.AddComponent<ObiParticleAttachment>();
        ObiActorBlueprint actorBlueprint = attach.particleGroup.blueprint;
        
        attach.particleGroup = actorBlueprint.groups[0];
        rope.ropeBlueprint = _ropeBlueprint;

// parent the cloth under a solver to start simulation:
        rope.transform.parent = solver.transform;
    }
}