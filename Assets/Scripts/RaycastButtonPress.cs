using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RaycastButtonPress : MonoBehaviour
{
    [SerializeField] private GameObject LeftController, RightController;

    private XRRayInteractor LeftRayInteractor, RightRayInteractor;
    private XRController LeftXRController, RightXRController;

    private GameObject button;

    public string buttonTrigger;
    public float sens;

    [SerializeField] private Text debug;
    void Start()
    { // setting all the components i need
        LeftRayInteractor = LeftController.GetComponent<XRRayInteractor>();
        LeftXRController = LeftController.GetComponent<XRController>();

        RightRayInteractor = RightController.GetComponent<XRRayInteractor>();
        RightXRController = RightController.GetComponent<XRController>();
    }

    void Update()
    { // checking if i do something with an controller
        ControllerRay(RightRayInteractor, RightXRController); // Right
        ControllerRay(LeftRayInteractor, LeftXRController); // Left
    }

    private void ControllerRay(XRRayInteractor RayInteractor, XRController XRcontroller)
    {
        /* what am i checking / want it to check
            
            
        */
        RaycastHit res;
        if (RayInteractor.TryGetCurrent3DRaycastHit(out res))
        {
            //Vector3 groundPt = res.point; // the coordinate that the ray hits
            
            if (res.collider.CompareTag("UI-Interactable"))
            {
                bool trigger = false;
                float buttonPressed = Input.GetAxis(buttonTrigger);

                if (buttonPressed >= sens)
                {
                    trigger = true;
                }

                if (trigger) //if trigger is pressed (true), activate onclick
                {
                    button = res.collider.transform.gameObject;

                    button.GetComponent<Button>().onClick.Invoke();
                }
            }
            else
            {
                
            }
        }
        else
        {
            debug.text = "";

        }
    }
}