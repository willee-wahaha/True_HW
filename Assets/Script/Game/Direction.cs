using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction
{

    public static Vector3 vector;
    public static Vector3[] allDirection = new Vector3[4];
    private static int d = 0;
    public static Transform nowChunk = null;
    // Start is called before the first frame update
    public static void Start()
    {
        allDirection[0] = Vector3.forward;
        allDirection[1] = Vector3.right;
        allDirection[2] = Vector3.back;
        allDirection[3] = Vector3.left;

        vector = allDirection[0];
    }

    public static void TurnRight()
    {
        d++;
        if (d == 4) d = 0;

        vector = allDirection[d];
    }

    public static void TurnLeft()
    {
        d--;
        if (d == -1) d = 3;

        vector = allDirection[d];
    }
}
