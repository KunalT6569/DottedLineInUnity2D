using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DottedLineDemo : MonoBehaviour
{
    [Header("Points for line 1")]
    public Vector2 pointA;
    public Vector2 pointB;
    [Header("Points for line 2")]
    public Vector2 pointX;
    public Vector2 pointY;
    // Update is called once per frame
    void Update()
    {
        //Creating a dotted line
        DottedLine.DottedLine.Instance.DrawDottedLine(pointA, pointB);

        //Creating another dotted line
        DottedLine.DottedLine.Instance.DrawDottedLine(pointX, pointY);
    }
}
