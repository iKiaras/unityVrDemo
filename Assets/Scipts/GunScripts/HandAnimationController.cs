using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class HandAnimationController : MonoBehaviour
{
    [SerializeField] private InputDeviceCharacteristics controllerType;
    [SerializeField] private InputDevice controller;
    private List<InputDevice> controllerDeviceList = new List<InputDevice>();
    private Animator animatorController;
    
    void Start()
    {
        animatorController = GetComponent<Animator>();
        StartCoroutine(connectToControllers());
    }

    // Update is called once per frame

    void Update()
    {
        if (controllerDeviceList.Count > 0)
        {
            if (controller.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
            {
                animatorController.SetFloat("Grip", triggerValue);
            }
            else
            {
                animatorController.SetFloat("Grip", 0);
            }

            if (controller.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > 0.1f)
            {
                animatorController.SetFloat("Trigger", gripValue);
            }
            else
            { 
                animatorController.SetFloat("Trigger", 0);

            }
        }
    }


    private IEnumerator connectToControllers()
    {
        InputDevices.GetDevicesWithCharacteristics(controllerType, controllerDeviceList);

        while (controllerDeviceList.Count.Equals(0))
        {
            yield return new WaitForSeconds(1f);
            InputDevices.GetDevicesWithCharacteristics(controllerType, controllerDeviceList);
        }
        controller = controllerDeviceList[0];
    }
}
