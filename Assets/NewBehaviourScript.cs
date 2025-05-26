// /**
// This script is essentially fully based on a tutorial by Noblob on Youtube,
// Reference
// *
// Author: Noblob (on Youtube),
// Location: https://www.youtube.com/watch?v=A8AfFgOZvQ4,
// Accessed: 24/1/2025,
// */

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerFootsteps : MonoBehaviour
// {
//      public GameObject footstep; // object containing the noise file as the source
//      public bool walking = false; // flag for if the player is walking

//     void Start(){
//         footstep.SetActive(false); // footstep noise loop is off at the start of the game as the player is not walking
//     }

//    // my modification includes changing the hardcoding of saying footsteps.SetActive for each case into a simpler boolean value 
//     void Update()
//     {
//         // checks if the player is holding down any movement keys and sets the bool to true
//         if(Input.GetKeyDown("w")  Input.GetKeyDown("a")  Input.GetKeyDown("s")  Input.GetKeyDown("d")){ 
//             walking = true;
//         }
//             // checks if the player lets go of any movement keys and sets the bool to false
//             if(Input.GetKeyUp("w")  Input.GetKeyUp("a")  Input.GetKeyUp("s")  Input.GetKeyUp("d")){
//                 walking = false;
//             }
//                 // checks if the player taps a movement key and sets the bool to true
//                 if(Input.GetKey("w")  Input.GetKey("a")  Input.GetKey("s") || Input.GetKey("d")){
//                     walking = true;
//                 }

//         // plays the footstep loop when the player is currently walking
//         if(walking == true){
//             footstep.SetActive(true);
//         }
//         // stops the footstep loop when the player is not currently walking
//         else if(walking == false){
//             footstep.SetActive(false);
//         }
//     }
// }