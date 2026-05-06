using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public enum States
{
    None,
    Idle,
    Walk,
    Locate,
    Attack,
    Dead,
}
public class PlayerScript : MonoBehaviour
{
    States state;
    InputAction moveAction;
    InputAction attackAction;
    Rigidbody rb;
    public Transform cam;
    public float speed = 6f;
    public float runSpeed = 8f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Animator anim;
    public bool attackBeginning;
    bool isAttacking;
    bool isWalking;
    public TextMeshProUGUI dialogue;
    public Vector2 direction;
    //public ButtonControl buttonWest { get; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        state = States.Idle;
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");

        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        DoLogic();
        print("state = " + state);
    }
    public void DoLogic()
    {
       /* if (attackAction.triggered)
        {
            print("Attack!!!");
        }*/

        if (state == States.Idle)
        {
            DoIdle();
            CheckForDeath();
            CheckForAttack();
        }
        if (state == States.Walk)
        {
            DoMove(false);
            CheckForDeath();
            CheckForAttack();
        }
        if (state == States.Dead)
        {
            IsDead();
        }
        if (state == States.Attack)
        {
            AttackCollide();
            CheckForDeath();
        }
    }
    void DoIdle()
    {
        if (moveAction.ReadValue<Vector2>().magnitude > 0.1f)
        {
            state = States.Walk;
        }
    }
    public void IsDead()
    {

    }
    public void CheckForAttack()
    {
        if( attackAction.triggered )
        {
            print("Attack!!!");
            state = States.Attack;

            //player attack animation
            anim.SetBool("Attack", true);
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", false);
            
        }
    }
    public void DoMove(bool fast)
    {
        //new input system
        float horizontal = moveAction.ReadValue<Vector2>().x;
        float vertical = moveAction.ReadValue<Vector2>().y;

        //Vector3 playerVelocity;

        Vector2 direction = moveAction.ReadValue<Vector2>().normalized;// new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            Vector3 vel = moveDir.normalized * speed;
            rb.linearVelocity = new Vector3(vel.x, rb.linearVelocity.y, vel.z);
            anim.SetBool("Walk", true);
            anim.SetBool("Attack", false);
            /*
            if (fast == false)
            {
                anim.SetBool("Walk", true);
                anim.SetBool("Attack", false);
                speed = 5f;
            }
            else
            {
                anim.SetBool("Attack", true);
                anim.SetBool("Walk", false);
                speed = 9f;
            }
            */
        }
        else if((isAttacking == false) && direction.magnitude >= 0)
        {
            state = States.Idle;
            anim.SetBool("Walk", false);
            anim.SetBool("Attack", false);
        }
        else 
        {
            isAttacking = true;
            state = States.Attack;
            anim.SetBool("Attack", true);
            anim.SetBool("Walk", false);
        }
       
    }

    void CheckForDeath()
    {

    }

    public void AttackCollide()
    {
        //
        anim.SetBool("isAttacking", true);
    }

    public void AttackStart()
    {
        isAttacking = true;
    }

    public void ZeroAttack()
    {
        isAttacking = false;
    }



    public void AttackFinished()
    {
        //change to idle state
        state = States.Idle;
        anim.SetBool("Attack", false); 
        anim.SetBool("Idle", true);
        anim.SetBool("isAttacking", false);

        isAttacking = false;

    }

    public void OnTriggerStay(Collider coll)
    {
        print("hand has hit " + coll.gameObject.tag);

        if (coll.gameObject.tag == "Enemy" && (isAttacking == true))
        {
            print("do destroy");
            Destroy(coll.gameObject);
            AudioManager.instance.Play("sfx1", AudioManager.instance.sfxVol);
            //LevelManager.instance.targetCount--;
        }
    }
   
}
