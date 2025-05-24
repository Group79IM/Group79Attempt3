using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
   
    [SerializeField] private PlayerInput input;
    [SerializeField] private CharacterController controller;
    
    [SerializeField] float speed = 10f;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] private AudioClip footsteps;

    private Vector2 currentMovement;
    private bool movePressed;


    

    void Awake() {
        input = new PlayerInput();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 horizontalMovement = new Vector3(currentMovement.x * speed, rigidBody.velocity.y, currentMovement.y * speed);
        rigidBody.velocity = transform.TransformDirection(horizontalMovement);
        AudioSource.PlayClipAtPoint(footsteps, transform.position, 1f);
    }

    void OnMove(InputValue value) {
        currentMovement = value.Get<Vector2>();
    }
}
