using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonController : MonoBehaviour
{
    // input fields 
    private ThirdPersonInputAction playerAction;
    private InputAction move;

    // movement fields
    private Rigidbody rb;
    [SerializeField] private float movementForce = 1.0f;
    [SerializeField] private float maxSpeed = 5.0f;
    // movement field: chaching the direction of the input in a vector3
    private Vector3 forceDirection = Vector3.zero;

    // Getting a reference for the camera for it to be relative to our position and not dependend on any wierd axis
    // so the when lets say W is pressed, the player walks away from the camera 
    [SerializeField]
    private Camera playerCamera;


    //grabbing references
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();

        //initialising 'ThirdPersonInputAction' here, creating a new instance
        playerAction = new ThirdPersonInputAction();
    }


    //subscribing to the input events
    private void OnEnable()
    {
        move = playerAction.Player.Move;
    // turning on the action map, DONT USE enabled! Use Enable, thats a function. The other is a property
        playerAction.Player.Enable();
    }
    private void OnDisable()
    {
    playerAction.Player.Disable();

    }

    //building up the force and applying the force to the rb and grabbing the input from the move action
    private void FixedUpdate()
    {   //multiplied by movementForce to we can fine tune
        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;

        //applying the force
        rb.AddForce(forceDirection, ForceMode.Impulse);
        //resetting the force so that it stops when the player stops pushing the button
        forceDirection = Vector3.zero;

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized; 
    }
    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized; 
    }
}
