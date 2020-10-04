using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public float time;
    public float lap1Time;
    public float lap2Time;
    public float lap3Time;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

}
