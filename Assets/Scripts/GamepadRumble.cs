using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadRumble : MonoBehaviour
{
    public InputActionAsset actionAsset; 
    private InputAction rumbleAction;

    public static GamepadRumble instance;

    private void Awake()
    {
        instance = this;
        rumbleAction = actionAsset.FindActionMap("Rumble").FindAction("RumbleAction");
    }

    
    public void TriggerRumble(float intensity, float duration)
    {
       
        if (rumbleAction != null && Gamepad.current != null)
        {
            
            Gamepad.current.SetMotorSpeeds(intensity, intensity);
           
            StartCoroutine(StopRumbleAfterDelay(duration));
        }
    }

    private IEnumerator StopRumbleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (Gamepad.current != null)
        {
            Gamepad.current.SetMotorSpeeds(0, 0);
        }
    }
}
