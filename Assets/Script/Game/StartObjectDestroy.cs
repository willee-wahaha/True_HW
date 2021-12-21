using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartObjectDestroy : MonoBehaviour
{
    public Transform t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AllBools.runThroughStart)
        {
            Destroy(t.gameObject);
        }
    }
}
