using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Npc2BrainComponent : MonoBehaviour
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


    [SerializeField] GameObject[] nodes;
    [SerializeField] GameObject eyes;
    public Ray ray;
    public float maxDistance = 30;
    public LayerMask layerMask;
    int index = 0;
    float guardTime = 3f;
    bool guard = false;


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
        if (nodes == null)
        {
            nodes[0] = GameObject.FindGameObjectWithTag("N0");
            nodes[1] = GameObject.FindGameObjectWithTag("N1");
            nodes[2] = GameObject.FindGameObjectWithTag("N2");
            nodes[3] = GameObject.FindGameObjectWithTag("N3");
        }

    }


    private void Update()
    {
        if (CanSeePlayer())
        {
            Charge();
        }

        if (animator.GetBool("AGRO"))
        {

            agent.destination = playerPosition.position;
            CheckRange();

        }



        if (animator.GetBool("MOVE"))
        {

            GoToNextNode();

        }




    }

    private void Charge()
    {
        animator.SetBool("AGRO", true);

        StopAllCoroutines();


    }
    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void CheckRange()
    {
        if ((playerPosition.position - agent.transform.position).magnitude <= 1)
        {
            //Attack();
            animator.SetBool("INRANGE", true);
            animator.SetTrigger("ATTACK");
        }
        else
        {
            animator.SetBool("INRANGE", false);
        }
    }

    public void Attack()
    {
       
        playerHealth.Hit();
    }

    private bool CanSeePlayer()
    {
        //transform.LookAt(targetTransform);/////////
        ray = new Ray(eyes.transform.position, eyes.transform.forward);
        Debug.DrawRay(eyes.transform.position, eyes.transform.forward * maxDistance);
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask))
        {
            //Debug.Log(hit.collider.tag);
            return hit.collider.CompareTag("PLAYER");
        }

        return false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        switch (collider.tag)
        {
            case "N0":
                guard = true;
                StartCoroutine(Wait());

                break;
            case "N1":
                guard = true;
                StartCoroutine(Wait());

                break;
            case "N2":
                guard = true;
                StartCoroutine(Wait());

                break;
            case "N3":
                guard = true;
                StartCoroutine(Wait());

                break;
            default: break;
        }
    }


    IEnumerator Wait()
    {
        do
        {
            animator.SetTrigger("WAIT");
            agent.destination = this.transform.position;
            Debug.Log("WAITING");

            guard = false;
            yield return new WaitForSeconds(guardTime);
        }
        while (guard);

        if (!guard)
        {
            animator.SetTrigger("MOVE");
            GoToNextNode();
            StopCoroutine(Wait());


        }



    }
    private void GoToNextNode()
    {
        Debug.Log("MOVING");

        agent.destination = nodes[index].transform.position;
        if (index == 3)
        {

            index = 0;
        }
        else
        {
            index++;
        }

    }

}
