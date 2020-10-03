using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject follow;

    private Transform t;
    // Start is called before the first frame update
    void Start()
    {
        t = follow.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =new Vector3(t.position.x, t.position.y, transform.position.y);
    }
}
