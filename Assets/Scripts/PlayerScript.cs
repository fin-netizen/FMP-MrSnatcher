using UnityEngine;
using UnityEngine.InputSystem;

public enum States
{
    None,
    Idle,
    Walk,
    Locate,
    Run,
    Dead,
}
public class PlayerScript : MonoBehaviour
{
    States state;
    InputAction moveAction;
    Rigidbody rb;
    public Transform cam;
    public float speed = 6f;
    public float runSpeed = 8f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        state = States.Idle;
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        DoLogic();
    }
    public void DoLogic()
    {
        if (state == States.Idle)
        {
            DoIdle();
            CheckForDeath();
        }
        if (state == States.Walk)
        {
            DoMove(false);
            CheckForDeath();

            if (Input.GetKey(KeyCode.LeftShift))
            {
                state = States.Run;
            }

        }
        if (state == States.Dead)
        {
            IsDead();
        }
        if (state == States.Run)
        {
            DoMove(true);
            CheckForDeath();

            if (Input.GetKey(KeyCode.LeftShift) == false)
            {
                state = States.Walk;
            }

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
            
            if (fast == false)
            {
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsRunning", false);
                speed = 5f;
            }
            else
            {
                anim.SetBool("IsRunning", true);
                anim.SetBool("IsWalking", false);
                speed = 9f;
            }
            
        }
        else
        {
            state = States.Idle;
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsRunning", false);
        }
    }



    void CheckForDeath()
    {

    }

}
