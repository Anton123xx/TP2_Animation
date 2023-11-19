using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc1BrainComponent : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool inAir;


    [HideInInspector] public float walkSpeed;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;


    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rb;
    [SerializeField] NavMeshAgent agent;

    [SerializeField] GameObject player;
    [SerializeField] Transform playerPosition;
    [SerializeField] PlayerHealthComponent playerHealth;





    private void Awake()
    {
        playerHealth = player.GetComponent<PlayerHealthComponent>();
    }






    private void Start()
    {
      
        inAir = true;
  
    }


    private void Update()
    {
        CheckRange();



        if (animator.GetBool("FOLLOW"))
        {
            Follow();
        }

        if (animator.GetBool("IDLE"))
        {
           
        }

        if(agent.isOnOffMeshLink && inAir)
        {
            Jump();
            inAir = false; 
            animator.SetTrigger("JUMP");
        }
    }
    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void CheckRange()
    {
        if ((playerPosition.position - agent.transform.position).magnitude <= 2)
        {
            Attack();
        }
        else
        {
            animator.SetBool("INRANGE", false);
        }
    }
    private void Follow()
    {
        agent.SetDestination(playerPosition.position);

    }
    private void Attack()
    {
        animator.SetBool("INRANGE", true);
        
        playerHealth.Hit();
    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.CompareTag("JUMPSPOT"))
    //    {
    //        animator.SetTrigger("JUMP");
    //    }

    //    if (collision.collider.CompareTag("LANDSPOT"))
    //    {
    //        animator.SetBool("LAND", true);
    //    }
    //}

}
