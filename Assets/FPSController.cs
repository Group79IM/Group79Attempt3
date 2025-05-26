/**
* This script is essentially fully based on a tutorial by All Things Game Dev
Reference
*
* Author: All Things Game Dev (on Youtube)
* Location: https://www.youtube.com/watch?v=qQLvcS9FxnY
* Accessed: 21/1/2025
*/

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
// using Cinemachine;

 // creates a character controller 
[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{

    [SerializeField] private AudioClip playerJumpSound;
    [SerializeField] private AudioClip footsteps;
    [SerializeField] private GameObject shopObject;
    [SerializeField] private GameObject sceneChangerObject;
    
    private ShopScript shopScript;
    private SceneChanger sceneChangerScript;

    // made the unity camera a cinemachine virtual camera to work with the other VCs
    public Camera playerCamera;

    // modified values to remove bloated irrelavent values
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
 
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;


 
    public bool canMove = true;
 
    // beginning of code following 'All Things Game Dev'
    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        shopScript = shopObject.GetComponent<ShopScript>();
        sceneChangerScript = sceneChangerObject.GetComponent<SceneChanger>();
    }

    void Update()
    {

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);


        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);


        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
            AudioSource.PlayClipAtPoint(playerJumpSound, transform.position, 0.5f);
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);
        //need an if moving then play footsteps otherwise no sound
        // AudioSource.PlayClipAtPoint(footsteps, transform.position, 1f);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        // end of code following 'All Things Game Dev'

        if (shopScript.shopOpen)
        {
            canMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
        else if (sceneChangerScript.menuOpen)
        {
            canMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
        else
        {
            canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
        }
    }
    
}
 