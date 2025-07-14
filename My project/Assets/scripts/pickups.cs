using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickups : MonoBehaviour
{
    // reference to player
    public playercontrols player;

    // Start is called before the first frame update
    void Start()
    {
        // grab ref to play
        player = GameObject.Find("player").GetComponent<playercontrols>();
    }

    void OnTriggerEnter(Collider other)
    {
        //if the player collides with the coin coin destroyed and coin count increase
        if (other.name == "player")
        {
            player.coinCount++;
            Destroy(this.gameObject);
        }
    }
 
}
