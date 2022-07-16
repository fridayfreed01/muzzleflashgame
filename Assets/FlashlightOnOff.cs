using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightOnOff : MonoBehaviour
{
    public GameObject Flashlight;
    bool flashlightOn;
    // Start is called before the first frame update
    void Start() {
        flashlightOn = false;
        Flashlight.SetActive(false);
     
    }

    // Update is called once per frame
    void Update() {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger)) {
            if (flashlightOn) {
                flashlightOn = false;
                Flashlight.SetActive(false);
            }
            else {
                flashlightOn = true;
                Flashlight.SetActive(true);
            }
        }
    }
}
