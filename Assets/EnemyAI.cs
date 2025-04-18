/**
* This script is based upon personal work done during a MPIE module practical 
Reference
*
* Author: Jonathan Hook, Sanjit Samaddar
* Location: MPIE Practical 9.1
* Accessed: 23/1/2025
*/

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    GameObject player; // player game object
    private bool found = false; // checks if the player i found
    private float distanceAway = 1f; // distance away from the player that the agent must get to 
    private bool inMotion = true; // tracks if the agent should be moving
    

    void Update (){
        // code derived from practical work
        // checks if the player is 
        if(player != null){ 
        NavMeshAgent agent = GetComponent<NavMeshAgent> (); // gets the navmesh agent that is on the robot gameobject
            if(found == true && inMotion == true){ // if the player is found (got in the robots collider) and the robot is allowed to move
                // end of code derived from practical work
                agent.destination = player.transform.position + player.transform.forward * distanceAway; // robot goes towards the player while accounting for distance away and not getting too close
            }
                if (Vector3.Distance(transform.position, player.transform.position) > 5f) { //resets the distance away to 1 if the robot went 5 units away from the player
                    distanceAway = 1f;
                }
        }
    }

    void OnTriggerEnter(Collider other){
        // if the player's collider collides with the robots collider
        if (other.gameObject.name == "Player")
        {   
            player = other.gameObject;
            found = true; // player is found and then followed
            distanceAway = 1f; // robot has to get within 1 unit of the player
        }
        // if the robot goes in an end zone collider
        if(other.CompareTag("End")){
            inMotion = false; // stop moving
            distanceAway = 0f; // stop going towards the current target point
        }
            // if the robot goes in the collider of an interactable object or a door
            else if(other.CompareTag("Interactables") || other.CompareTag("Door"))
            {
                distanceAway = 5f; // go 5 units away from the player to give them space to interact
            }
    }   


  
}   

