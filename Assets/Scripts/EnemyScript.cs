using UnityEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject player;
    public float speed = 2.0f;
    public float minDist = 1f;
    public Transform target;
    Rigidbody rb;
    public bool isPartrolling;
   // public Animator anim;
    //PlayerScript playerScript;

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

    }

    // Update is called once per frame
    void Update()
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
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    public void OnTriggerStay(Collider coll)
    {
        print("hand has hit " + coll.gameObject.tag);

        if (coll.gameObject.tag == "Enemy" + ("isAttacking", true))
        {
            Destroy(gameObject);
        }
    }
}
