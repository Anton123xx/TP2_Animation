using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=BZZ6C97e7s0&list=LL&index=11

public class PlayerInteractComponent : MonoBehaviour
{


    [SerializeField] private int rayLength = 10;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName;

    private ElevatorControllerComponent controller;


    [SerializeField] private KeyCode interactKey = KeyCode.F;

    //[SerializeField] private Image crosshair = null;







    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;
        Debug.DrawRay(transform.position, fwd * rayLength);


        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract))
        {
            //Debug.Log("HIT");
            switch (hit.collider.tag)
            {
                //case "Door":
                //    if (Input.GetKeyDown(interactKey))
                //    {

                //        hit.collider.GetComponent<DoorControllerComponent>().Interact();

                //    }

                //    break;
                case "Elevator_open":
                    if (Input.GetKeyDown(interactKey))
                    {

                        hit.collider.GetComponent<ElevatorControllerComponent>().Open();


                    }

                    break;
                case "Button_Up":

                    if (Input.GetKeyDown(interactKey))
                    {
                        ElevatorControllerComponent elevatorController =
                            hit.collider.GetComponent<ElevatorControllerComponent>();

                        if (elevatorController.level == 2)
                        {
                            //peux pas aller plus haut
                            Debug.Log("PEUXPASALLERPLUSHAUT");
                        }
                        else
                        {
                            elevatorController.GoUp();
                        }




                    }


                    break;
                case "Button_Down":

                    if (Input.GetKeyDown(interactKey))
                    {
                        ElevatorControllerComponent elevatorController =
                            hit.collider.GetComponent<ElevatorControllerComponent>();
                        if (elevatorController.level == 0)
                        {

                            //peux pas aller plus bas

                            Debug.Log("PEUXPASALLERPLUSBAS");
                        }
                        else
                        {
                            elevatorController.GoDown();
                        }


                    }

                    break;
                default:
                    Debug.Log("MARCHE PAS");
                    break;
            }


        }


    }
}