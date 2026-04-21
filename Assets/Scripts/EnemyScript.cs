using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using UnityEditor.Rendering;

public enum EnemyStates
{
    Idle,
    MoveAway,
}
public class EnemyScript : MonoBehaviour
{
    public NavMeshAgent agent;
    EnemyStates state;

    public GameObject player;
    Vector3 destinationPoint;


    public float speed = 2.0f;
    public float minDist = 1f;
    //public Transform target;
    Rigidbody rb;
    public bool isPartrolling;
    public Animator anim;
    //PlayerScript playerScript;
    public float range = 20f;
    public float inBetweenDistance = 10f;
    //Vector3 destination;
    //public Vector3 targetPoint;

    public float restTimer = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerScript = GetComponent<PlayerScript>();
        print("player position=" + player.transform.position);
        print("my position=" + transform.position);
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindWithTag("player");
        state = EnemyStates.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        DoLogic();
       
        

        //DoPatrol();

      

    }
    public void DoLogic()
    {
        if (state == EnemyStates.Idle)
        {
            DoIdle();
        }
        if (state == EnemyStates.MoveAway)
        {
            MoveAwayState();
        }
    }
    


    void MakeTargetPoint()
    {
        destinationPoint = player.transform.position;
        float x, z;

        //make a random number between -3 and +3
        x = Random.Range(-range, range);

        //extend it by 2 metres
        if(x < 0 )
        {
            x -= inBetweenDistance;
        }
        else
        {
            x += inBetweenDistance;
        }

        //Z
        z = Random.Range(-range, range);
        if (z < 0)
        {
            z -= inBetweenDistance;
        }
        else
        {
            z += inBetweenDistance;
        }

        destinationPoint.x = x;
        destinationPoint.z = z;
        destinationPoint.y = player.transform.position.y;

        //debug gameobject to show where agent will eventually go

        agent.SetDestination(destinationPoint);
        print("setting target to " + destinationPoint);




    }


    void DoPatrol()
    {

        /*
        // anim.SetBool("isPartrolling", false);
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance > minDist)
            transform.position += transform.forward * speed * Time.deltaTime;
        // anim.SetBool("isPartrolling", true);
        Vector3 targetPosition = new Vector3(player.transform.position.x, this.transform.position.y, target.position.z);
        this.transform.LookAt(targetPosition);
        // print("the distance is " + distance);
        if (distance >= 12)
        {

        }
        */
    }
    void DoIdle()
    {
        restTimer = 3;
        anim.SetBool("EnemyIdle", true);
        anim.SetBool("EnemyWalk", false);
        if (Keyboard.current.eKey.isPressed)
        {
            MakeTargetPoint();
            state = EnemyStates.MoveAway;
            print("E key is pressed");
        }
    }
    void MoveAwayState()
    {
        float distance = Vector3.Distance(destinationPoint, transform.position);

        //transform.position += transform.forward * speed * Time.deltaTime;
        //Vector3 enemyTargetPointPosition = new Vector3(targetPoint.x, this.transform.position.y, targetPoint.z);
        //this.transform.LookAt(targetPoint);
        anim.SetBool("EnemyIdle", false);
        anim.SetBool("EnemyWalk", true);
        // check for enemy agent reaching the destination point
        print("distance = " + distance );
        
        //if the enemy is close to the point, change the state to idle
        if ( distance < 3.0f )
        {
            print("Timer is currently at " + restTimer);
            restTimer -= Time.deltaTime;
            if (restTimer <= 0)
            {
                state = EnemyStates.Idle;
            }
            
        }


        
    }
    void timerEnd()
    {

    }
}
