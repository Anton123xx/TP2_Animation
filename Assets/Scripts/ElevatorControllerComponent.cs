using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioClip))]
public class ElevatorControllerComponent : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

    //private bool doorOpen = false;

    //[SerializeField] private string openAnimation = "bigDoorOpen";
    //[SerializeField] private string closeAnimation = "bigdDoorClose";

    private float waitTime = 4;
    //[SerializeField] private bool pauseInteraction = false;
    public AudioSource aS;

    public AudioClip doorOpen, doorClose, moving;

    [SerializeField] GameObject[] elevatorMap;

    public int level = 1;
    //public int numberOfLevels = 2;

    [SerializeField] GameObject player;
    [SerializeField] Transform playerPosition;

    private void Awake()
    {
        //if (doorAudio == null)
        //{
        //    doorAudio = GetComponent<AudioClip>();
        //}

        //if (aS == null)
        //{
        //    aS = GetComponent<AudioSource>();
        //}

        //elevatorMap = new GameObject[numberOfLevels];
        elevatorMap[0] = GameObject.FindGameObjectWithTag("E0");
        elevatorMap[1] = GameObject.FindGameObjectWithTag("E1");
        elevatorMap[2] = GameObject.FindGameObjectWithTag("E2");

        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform;



    }


    private void Update()
    {

    }

    private IEnumerator ClosingDoor()
    {
        //pauseInteraction = true;
        yield return new WaitForSeconds(waitTime);


        animator.SetBool("close", true);
        yield return new WaitForSeconds(2);
        aS.PlayOneShot(doorClose);
        //pauseInteraction = false;

        animator.SetBool("open", false);
        animator.SetBool("close", false);
    }

    public void Open()
    {

        animator.SetBool("open", true);
        aS.PlayOneShot(doorOpen);
        StartCoroutine(ClosingDoor());

    }


    public void GoUp()
    {

        //Debug.Log("UP");

        level++;
        aS.PlayOneShot(moving);
        player.SetActive(false);
        playerPosition.position = new Vector3(playerPosition.position.x, elevatorMap[level].transform.position.y, playerPosition.position.z);
        player.SetActive(true);

        elevatorMap[level].GetComponentInChildren<ElevatorControllerComponent>().Invoke("Open", moving.length);

    }


    public void GoDown()
    {


        //Debug.Log("DOWN");

        level--;
        aS.PlayOneShot(moving);
        player.SetActive(false);
        playerPosition.position = new Vector3(playerPosition.position.x, elevatorMap[level].transform.position.y, playerPosition.position.z);
        player.SetActive(true);

        elevatorMap[level].GetComponentInChildren<ElevatorControllerComponent>().Invoke("Open", moving.length);

    }

}