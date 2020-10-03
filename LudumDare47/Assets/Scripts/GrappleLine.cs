using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleLine : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public bool active;

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            
        }
    }

    public void SetLine(Vector2 pos1, Vector3 pos2)
    {
        active = true;
    }
}
