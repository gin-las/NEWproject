using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemybehavior : MonoBehaviour
{
public Transform player;
       public List<Transform> locations;

       private int locationIndex = 0;
       private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
       player = GameObject.Find("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 0.2f && !agent.pathPending){
            MoveToNextPatrolLocation();
        }
    }

    void InitalizePatrolRoute(){                                     
        foreach(Transform child in locations)
        locations.Add(child);
    }

    void MoveToNextPatrolLocation(){
        if(locations.Count == 0){
            return;
        }
        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;

    }

    private void OnTriggerEnter(Collider other){
        if(other.name == "player"){
            agent.destination = player.position;
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.name == "player"){

        }
    }
 
}
