using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterCtrl : MonoBehaviour
{
    public Vector3 MoveDirection;

    [SerializeField] private float speed = 10;
    Rigidbody rb;
    Animator ani;
    NavMeshAgent agent;
    public float low = 10000;
    [SerializeField] private float JumpingForce = 100000;
    private int playerDeviation = 0, turnTime = 0;

    private bool isjump = false, isrun = false, isturn = false, canturn = false;

    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Direction.Start();
        MoveDirection = Direction.vector;

        rb = transform.GetComponent<Rigidbody>();
        ani = transform.GetComponent<Animator>();
        agent = transform.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Direction.nowChunk == null)
        {
            if (turnTime == 0)
            {
                turnTime++;
                canturn = true;
            }
        }
        else
        {
            canturn = false;
            turnTime = 0;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += Direction.vector * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += Vector3.back * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.A) && !isturn && AllBools.runThroughStart)
        {
            if(canturn)
            {
                isturn = true;
                
                Turn(false);
                canturn = false;
            }
        }
        

        if (Input.GetKeyDown(KeyCode.D) && !isturn && AllBools.runThroughStart)
        {
            if (canturn)
            {
                isturn = true;

                Turn(true);
                canturn = false;
            }
        }

        transform.localPosition += MoveDirection * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {

            if (!isjump)
            {
                rb.AddForce(JumpingForce * Time.deltaTime * Vector3.up);
                isjump = true;
            }
        }

        ani.SetBool("Jump", isjump);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Land")
        {
            isjump = false;
            ani.SetBool("Jump", isjump);
        }
    }

    private void Turn(bool left)
    {
        float d = -90, dNow = transform.eulerAngles.y;
        if (left)
        {
            d *= -1;
            Direction.TurnRight();
        }
        else
        {
            Direction.TurnLeft();
        }
        MoveDirection = Direction.vector;

        Vector3 to = new Vector3(0, dNow + d, 0);
        transform.eulerAngles = to;
        
        isturn = false;
        
    }
}
