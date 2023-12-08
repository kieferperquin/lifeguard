using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RaycastButtonPress : MonoBehaviour
{
    public TriggersListObject.Triggers buttons;

    [SerializeField] private GameObject controller;

    private XRRayInteractor RayInteractor;
    private GameObject button;
    private string buttonTrigger;

    private int interactableUILayer;

    public float sens;

    private bool pressedOnce = true;

    [SerializeField] private Text debug;

    void Start()
    {
        interactableUILayer = LayerMask.NameToLayer("InteractableUI");

        RayInteractor = controller.GetComponent<XRRayInteractor>();
    }

    void Update()
    {
        ControllerRay();
    }

    void ControllerRay()
    {
        buttonTrigger = buttons.ToString();
        RaycastHit res;
        if (RayInteractor.TryGetCurrent3DRaycastHit(out res))
        {
            //debug.text = "tag = " + res.collider.tag + "      layer = " + res.transform.gameObject.layer; 
            //debug.text = $"world pos = {Mathf.Round(res.point.x * 100f) / 100f}, {Mathf.Round(res.point.y * 100f) / 100f}, {Mathf.Round(res.point.z * 100f) / 100f}";

            if (res.transform.gameObject.layer == interactableUILayer)
            {
                bool trigger = Input.GetAxis(buttonTrigger) >= sens;

                if (!trigger)
                {
                    pressedOnce = true;
                }

                if (trigger && pressedOnce) //if trigger is pressed (true), activate onclick
                {
                    pressedOnce = false;

                    button = res.collider.transform.gameObject;
                    button.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
    }
}