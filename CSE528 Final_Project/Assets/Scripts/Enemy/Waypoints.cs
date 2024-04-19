using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points=null;
    
    void Awake () 
    {
        points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++) 
        {
            points [i] = this.transform.GetChild (i);
        }
    }
}