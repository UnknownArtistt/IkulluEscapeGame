using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioManager.instance.PlaySFX(6);
            LevelManager.instance.RespawnPlayer();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
