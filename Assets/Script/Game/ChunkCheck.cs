using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkCheck : MonoBehaviour
{
    private bool isRunHere = false;
    private int touchTimes = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.name == "mainplay")
        {
            if (AllBools.runThroughChunk && isRunHere)
            {
                AllBools.runThroughChunk = false;
            }
            else if (touchTimes == 0)
            {
                AllBools.runThroughChunk = true;
                AllBools.canCreateNextChumk = true;
            }

            if (isRunHere)
            {
                Direction.nowChunk = null;
                isRunHere = false;
            }
            else
            {
                Direction.nowChunk = transform;
                isRunHere = true;
                touchTimes++;
            }
            
        }
    }
}
