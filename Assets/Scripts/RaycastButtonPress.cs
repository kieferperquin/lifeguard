using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RaycastButtonPress : MonoBehaviour
{
    public triggers buttons = new triggers();

    public enum triggers //alle verschillende knoppen wat je kan duwen
    {
        None,
        XRI_Left_Trigger,
        XRI_Right_Trigger
    }

    [SerializeField] private GameObject controller;

    private XRRayInteractor RayInteractor;

    private GameObject button;

    string buttonTrigger;
    public float sens;

    [SerializeField] private Text debug;
    void Start()
    {
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
            if (res.collider.CompareTag("UI-Interactable"))
            {
                bool trigger = false;
                float buttonPressed = Input.GetAxis(buttonTrigger);

                if (buttonPressed >= sens) //if buttonPressed is bigger or equal to sens then trigger is true
                {
                    trigger = true;
                }

                if (trigger) //if trigger is pressed (true), activate onclick
                {
                    button = res.collider.transform.gameObject;

                    button.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
        else
        {
            debug.text = "";

        }
    }
}