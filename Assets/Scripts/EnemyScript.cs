using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

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
    public float speed = 2.0f;
    public float minDist = 1f;
    public Transform target;
    Rigidbody rb;
    public bool isPartrolling;
    // public Animator anim;
    //PlayerScript playerScript;
    public float range = 30f;
    public float inBetweenDistance = 15f;

    public GameObject enemyTargetPoint;
    public Vector3 targetPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerScript = GetComponent<PlayerScript>();
        print("player position=" + player.transform.position);
        print("my position=" + transform.position);
        rb = GetComponent<Rigidbody>();
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

        enemyTargetPoint.transform.position = point;

        print("setting target to " + point);
        targetPoint = point;


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
        if (Keyboard.current.eKey.isPressed)
        {
            MakeTargetPoint();
            state = EnemyStates.MoveAway;
        }
    }
    void MoveAwayState()
    {
        if (enemyTargetPoint == null)
            return;
        transform.position += transform.forward * speed * Time.deltaTime;
        Vector3 enemyTargetPointPosition = new Vector3(targetPoint.x, this.transform.position.y, targetPoint.z);
        this.transform.LookAt(targetPoint);
        //Ray movePosition = targetPoint = 
    }
}
