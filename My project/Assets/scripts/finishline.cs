using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishline : MonoBehaviour
{
    public gamemanager Manager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "player")
        {
            //end game
            Manager.endGame();
        }
    }











}
