using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;

    private InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristrics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if(devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("Did not find corresponding controller model");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }
            spawnedHandModel = Instantiate(handModelPrefab, transform);
        }  
    }

     void Update()
    {
        /*        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
                if (primaryButtonValue)
                    Debug.Log("Pressing Primary Button");

                targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
                if (triggerValue > 0.1f)
                    Debug.Log("Trigger pressed " + triggerValue);

                targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
                if (primary2DAxisValue != Vector2.zero)
                    Debug.Log("Primary Touchpad " + primary2DAxisValue);*/

        if (showController)
        {
            spawnedHandModel.SetActive(false);
            spawnedController.SetActive(true); 
        }
        else
        {
            spawnedHandModel.SetActive(true);
            spawnedController.SetActive(false);
        }
    }

}
