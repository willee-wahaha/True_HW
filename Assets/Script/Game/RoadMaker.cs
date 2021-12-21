using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMaker : MonoBehaviour
{

    public Transform Road;
    public Transform Chunk;
    private int nowDirection = 0, nextDirection = 0;
    public bool b = true;

    List<Transform> roadList;
    System.Random rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        
        roadList = new List<Transform>();

        for (int i=0; i<5; i++)
        {
            Transform t;
            if (AllBools.roadIsBreak)
            {
                t = Instantiate(Road.GetChild(1));
                AllBools.roadIsBreak = false;
            }
            else
            {
                t = Instantiate(Road.GetChild(0));
            }

            Transform p = transform.GetChild(1).GetChild(i);

            t.parent = p;
            t.localPosition = Vector3.zero;
        }

        nextDirection = rnd.Next(0, 3);
        Transform six;
        Transform sixp = transform.GetChild(1).GetChild(5);
        six = Instantiate(Road.GetChild(nextDirection + 3));
        six.parent = sixp;
        six.localPosition = Vector3.zero;

        nowDirection += nextDirection;
        if (nextDirection == 2) nowDirection++;
        if (nowDirection > 3) nowDirection -= 4;

        AllBools.canCreateNextChumk = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (AllBools.canCreateNextChumk)
        {
            AllBools.canCreateNextChumk = false;
            Transform c = Instantiate(transform.GetChild(0));
            c.parent = transform;
            int p = transform.childCount;
            c.position = transform.GetChild(p-2).GetChild(5).position;
            Vector3 d = new Vector3(0, 90 * nowDirection, 0);

            if (nextDirection == 1)
            {
                float x = -4.1f, z = 4;
                switch (nowDirection-1)
                {
                    case 1:
                        x = 4;
                        z = 4.1f;
                        break;

                    case 2:
                        x = 4.1f;
                        z = -4;
                        break;

                    case -1:
                        x = -4;
                        z = -4.1f;
                        break;
                }

                c.position = new Vector3(c.position.x + x, c.position.y, c.position.z + z);
            }
            else if (nextDirection == 2)
            {
                float x = 4.1f, z = 4;
                switch (nowDirection - 3)
                {
                    case -3:
                        x = 4;
                        z = -4.1f;
                        break;

                    case -2:
                        x = -4.1f;
                        z = -4;
                        break;

                    case -1:
                        x = -4;
                        z = 4.1f;
                        break;
                }

                c.position = new Vector3(c.position.x + x, c.position.y, c.position.z + z);
            }

            int breakCount = 0;
            for (int i = 0; i < 5; i++)
            {
                Transform t;
                if (AllBools.roadIsBreak)
                {
                    if(breakCount == 0)
                    {
                        t = Instantiate(Road.GetChild(Road.childCount - 1));
                        breakCount++;
                    }
                    else
                    {
                        t = Instantiate(Road.GetChild(1));
                        breakCount = 0;
                        AllBools.roadIsBreak = false;
                    }
                    
                }
                else
                {
                    if(rnd.Next(0, 50) % 10 == 1 && i < 3)
                    {
                        t = Instantiate(Road.GetChild(2));
                        AllBools.roadIsBreak = true;
                    }
                    else
                    {
                        t = Instantiate(Road.GetChild(0));
                    }
                }

                t.parent = c.GetChild(i);
                t.localPosition = Vector3.zero;
            }

            nextDirection = rnd.Next(0,3);
            Transform six;
            Transform sixp = c.GetChild(5);
            six = Instantiate(Road.GetChild(nextDirection + 3));
            six.parent = sixp;
            six.localPosition = Vector3.zero;

            nowDirection += nextDirection;
            if (nextDirection == 2) nowDirection++;
            if (nowDirection > 3) nowDirection -= 4;

            c.Rotate(d);
           

            if (transform.childCount > 6)
            {
                Transform t = transform.GetChild(2);
                Destroy(t.gameObject);
                t = transform.GetChild(1);
                Destroy(t.gameObject);
            }
            if(transform.childCount > 5)
            {
                Transform t = transform.GetChild(1);
                Destroy(t.gameObject);
            }
        }
        
    }

}
