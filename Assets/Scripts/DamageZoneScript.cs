using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZoneScript : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other) {
        PlayerController playerController = other.GetComponent<PlayerController>();

        if (playerController != null) {

            if (playerController.health > 0){
	            playerController.ChangeHealth(-1);
            }
        }
   }
}
