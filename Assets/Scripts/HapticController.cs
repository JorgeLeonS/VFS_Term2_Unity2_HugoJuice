using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticController : MonoBehaviour
{
    public XRBaseController leftController;
    public XRBaseController rightController;

    public float defaultAmplitud = 0.1f;
    public float defaultDuration = 0.2f;

    public void SendHaptics(bool isRightController)
    {
        if(isRightController)
            rightController.SendHapticImpulse(defaultAmplitud, defaultDuration);
        else
            leftController.SendHapticImpulse(defaultAmplitud, defaultDuration);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
