using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using UnityEditor.Rendering;

public enum Enemy2States
{
    Idle,
    MoveAway,
}
public class EnemyScript2 : MonoBehaviour
{
    public NavMeshAgent agent;
    EnemyStates state;
    public GameObject player;
    public float speed = 2.0f;
    public float minDist = 1f;
    public Transform target;
    Rigidbody rb;
    public bool isPartrolling;
    public Animator anim;
    //PlayerScript playerScript;
    public float range = 30f;
    public float inBetweenDistance = 15f;
    Vector3 destination;
    public Vector3 targetPoint;
    public float restTimer = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerScript = GetComponent<PlayerScript>();
        print("player position=" + player.transform.position);
        print("my position=" + transform.position);
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        if (target == null)
        {
            if (GameObject.FindWithTag("player") != null)
            {
                target = GameObject.FindWithTag("player").GetComponent<Transform>();
            }
        }
        state = EnemyStates.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == EnemyStates.Idle)
        {
            DoIdle();
        }
        if(state == EnemyStates.MoveAway)
        {
            MoveAwayState();
        }
        

        //DoPatrol();

      

    }
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }


    void MakeTargetPoint()
    {
        Vector3 point = player.transform.position;
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

        point.x = x;
        point.z = z;
        point.y = player.transform.position.y;

        //debug gameobject to show where agent will eventually go

        agent.SetDestination(point);
        print("setting target to " + point);




    }


    void DoPatrol()
    {

        // anim.SetBool("isPartrolling", false);
        if (target == null)
            return;
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance > minDist)
            transform.position += transform.forward * speed * Time.deltaTime;
        // anim.SetBool("isPartrolling", true);
        Vector3 targetPosition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        this.transform.LookAt(targetPosition);
        // print("the distance is " + distance);
        if (distance >= 12)
        {

        }
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

        }
    }
    void MoveAwayState()
    {
        // check for enemy agent reaching the destination point
        anim.SetBool("EnemyIdle", false);
        anim.SetBool("EnemyWalk", true);

        //if the enemy is close to the point, change the state to idle
        if (Vector3.Distance (destination, target.position) > 1.0f)
        {

            destination = target.position;
            agent.destination = destination;
            restTimer -= Time.deltaTime;
            if (restTimer <= 0)
            {
                state = EnemyStates.Idle;
            }
            
        }


        //transform.position += transform.forward * speed * Time.deltaTime;
        //Vector3 enemyTargetPointPosition = new Vector3(targetPoint.x, this.transform.position.y, targetPoint.z);
        //this.transform.LookAt(targetPoint);
        
    }
}
