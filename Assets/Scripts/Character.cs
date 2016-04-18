using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour {

    public enum State
    {
        IDLE,
        WALKING,
        RUNNING,
        STRAFING,
        ATTACKING,
        COUNTERING
    };
    State currentState;
    bool moving = false;
    bool attacking = false;
    bool movingCamera = false;
    AnimatorStateInfo currentBaseState;

    public float gravity = 20.0f;
    public int health = 100;
    public string InputPrefix = "A";
    float moveSpeed = 2.5f;

    int heavyAttack = 40;
    int lightAttack = 15;

    Rigidbody m_Rigidbody;
    Animator m_Animator;
    CapsuleCollider m_Capsule;
    CharacterController m_CharacterController;

    Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Capsule = GetComponent<CapsuleCollider>();
        m_CharacterController = GetComponent<CharacterController>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        currentState = State.IDLE;
    }

    void Update()
    {
        if (m_CharacterController.isGrounded)
        {
            moveDirection = Vector3.zero;
            moveDirection = new Vector3(Input.GetAxis(InputPrefix + "Horizontal"), 0, Input.GetAxis(InputPrefix + "Vertical"));
            if (moveDirection.x != 0 || moveDirection.z != 0)
            {
                moving = true;
            }
            else
            {
                moving = false;
            }
            updateStates();
            moveDirection = transform.TransformDirection(moveDirection) * moveSpeed;        
        }     
        else
        {
            updateStates();
        }     

        moveDirection.y -= gravity * Time.deltaTime;
        m_CharacterController.Move(moveDirection * Time.deltaTime);
    }

    void updateStates()
    {
        if(!attacking)
        {
            if (Input.GetButtonDown(InputPrefix + "Fire1"))
            {
                m_Animator.SetTrigger("attack");
                attacking = true;
            }
            else if (Input.GetButtonDown(InputPrefix + "Action1"))
            {
                m_Animator.SetTrigger("strike");
                attacking = true;
            }
            else if (Input.GetButtonDown(InputPrefix + "Action2"))
            {
                m_Animator.SetTrigger("shieldBash");
                attacking = true;
            }
            else if (Input.GetButtonDown(InputPrefix + "Action3"))
            {
                m_Animator.SetTrigger("rollingShieldBash");
                attacking = true;
            }
            else if (Input.GetButtonDown(InputPrefix + "Action4"))
            {
                m_Animator.SetTrigger("counter");
                attacking = true;
            }
            else if (Input.GetButtonDown(InputPrefix + "Fire2"))
            {
                m_Animator.SetTrigger("parry");
                attacking = true;
            }
            else if (Input.GetButtonDown(InputPrefix + "Action6"))
            {
                m_Animator.SetTrigger("taunt");
                attacking = true;
            }    
        }

        if (moving && !attacking)
        {
            if (moveDirection.z > 0.5f && Input.GetButton(InputPrefix + "Fire3"))
            {
                currentState = State.RUNNING;
                moveSpeed = 5.0f;
            }
            else if(moveDirection.z > 0.1f)
            {
                currentState = State.WALKING;
                moveSpeed = 2.5f;
            }
            else if(moveDirection.x != 0)
            {
                currentState = State.STRAFING;
            }          
        }
        else
        {
            currentState = State.IDLE;
        }

        switch (currentState)
        {
            case State.ATTACKING:
                break;
            case State.WALKING:
                int orientation = (int)(moveDirection.z / moveDirection.z);
                m_Animator.SetFloat("moveSpeed", 0.5f * orientation);
                break;
            case State.RUNNING:
                m_Animator.SetFloat("moveSpeed", moveDirection.z);
                break;
            case State.STRAFING:
                m_Animator.SetFloat("strafe", -moveDirection.x);
                break;
            case State.IDLE:
            default:
                m_Animator.SetFloat("moveSpeed", 0.0f);
                m_Animator.SetFloat("strafe", 0.0f);
                break;
        }

        currentBaseState = m_Animator.GetCurrentAnimatorStateInfo(0);
    }
    // animation callbacks 
    void endAttack()
    {
        attacking = false;
        //Debug.Log("Attack Ended");
    }

    void endStrafe()
    {
        currentState = State.IDLE;
        Debug.Log("Strafe Ended");
    }
}
