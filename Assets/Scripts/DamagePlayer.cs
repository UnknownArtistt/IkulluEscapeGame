using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DamagePlayer : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.DealDamage();
            StartCoroutine(VibrationWithDuration(0.7f));
        }
    }

    private IEnumerator VibrationWithDuration(float duration)
    {
        Gamepad.current.SetMotorSpeeds(0.25f, 0.75f);

        yield return new WaitForSeconds(duration);

        Gamepad.current.SetMotorSpeeds(0f, 0f);
    }
}
