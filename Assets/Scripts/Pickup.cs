using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public bool isGem, isHeal;
    public bool isCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            if (isGem)
            {
                LevelManager.instance.gemsCollected++;
                UIController.instance.UpdateGemCount();
                AudioManager.instance.PlaySFX(8);
                isCollected = true;
                Destroy(gameObject);
            }

            if (isHeal)
            {
                if (PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();
                    AudioManager.instance.PlaySFX(7);
                    isCollected = true;
                    Destroy(gameObject);
                }
                else
                {
                    isCollected = true;
                    Destroy(gameObject);
                }
            }
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
