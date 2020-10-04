using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePlace : MonoBehaviour
{

    public int nr;
    public GameHandler gameHander;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameHander.GatePassed(nr);
    }
}
