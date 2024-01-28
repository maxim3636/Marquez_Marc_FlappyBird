using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipaIncreaseScore : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision){

        if(collision.gameObject.CompareTag("Player")){

            Score.instance.UpdateScore();
        }
    }
   
}
