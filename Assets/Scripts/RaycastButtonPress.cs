using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class RaycastButtonPress : MonoBehaviour
{
    [SerializeField] private GameObject LeftController, RightController;

    private XRRayInteractor LeftRayInteractor, RightRayInteractor;
    private XRController LeftXRController, RightXRController;

    [SerializeField] private Text debug;
    void Start()
    {
        LeftRayInteractor = LeftController.GetComponent<XRRayInteractor>();
        LeftXRController = LeftController.GetComponent<XRController>();

        RightRayInteractor = RightController.GetComponent<XRRayInteractor>();
        RightXRController = RightController.GetComponent<XRController>();
    }

    void Update()
    {
        ControllerRay(RightRayInteractor, LeftXRController);
        ControllerRay(LeftRayInteractor, RightXRController);
    }

    private void ControllerRay(XRRayInteractor RayInteractor, XRController XRcontroller)
    {
        RaycastHit res;
        if (RayInteractor.TryGetCurrent3DRaycastHit(out res))
        {
            Vector3 groundPt = res.point; // the coordinate that the ray hits
            
            if (res.collider.CompareTag("UI-Interactable"))
            {
                if (true)
                {

                }
            }
            else
            {
                
            }
        }
        else
        {
            
        }
    }
}