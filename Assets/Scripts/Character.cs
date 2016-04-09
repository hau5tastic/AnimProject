using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour {

    public float gravity = 20.0f;

    public int health = 100;
    public float moveSpeed = 5.0f;

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
    }

    void Update()
    {
        if (m_CharacterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection) * moveSpeed;
        }

        moveDirection.y -= gravity * Time.deltaTime;

        m_CharacterController.Move(moveDirection * Time.deltaTime);
    }
 
}
