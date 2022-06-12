using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform cam;
    [SerializeField] GameObject mainBody;
    [SerializeField] GameObject robot;
    Animator V1animator;


    public float forwardSpeed = 10f;
    public float sideSpeed = 6f;
    public float reverseSpeed = 5f;

    private float speed;

    Vector3 direction;


    private float mainBodyVelocitySmooth;
    [SerializeField] float mainBodySmoothTime = 0.1f;

    private float robotScmoothVelocity;
    [SerializeField] float robotSmoothTime = 0.3f;


    [SerializeField] float testCounter1;
    [SerializeField] float testCounter2;
    [SerializeField] float testCounter3;
    [SerializeField] float testCounter4;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        V1animator = robot.GetComponent<Animator>();
        V1animator.SetBool("activation", true);
    }

    void Update()
    {
        if (direction.magnitude >= 0.05f)
        {
            V1animator.SetBool("isWalking", true);

                //Robot pointing in direction of movement and camera
            float robotTargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float robotAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, robotTargetAngle, ref robotScmoothVelocity, robotSmoothTime);
            transform.rotation = Quaternion.Euler(0f, robotAngle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, robotAngle, 0f) * Vector3.forward;

            controller.Move(moveDirection * Time.deltaTime * 10);
        }
        if (direction.magnitude < 0.05f)
        {
            V1animator.SetBool("isWalking", false);
        }


            //Head rotation
        float mainBodyTargetAngle = (cam.eulerAngles.y);
        float mainBodyAngle = Mathf.SmoothDampAngle(mainBody.transform.eulerAngles.y, mainBodyTargetAngle, ref mainBodyVelocitySmooth, mainBodySmoothTime);
        mainBody.transform.rotation = Quaternion.Euler(0f, mainBodyAngle, 0f);
    }

    
    public void Move(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();

        if (inputVector.y <= -0.05f)
        {
            speed = reverseSpeed;
        }
        else
        {
            speed = forwardSpeed;
        }

        direction = new Vector3(inputVector.x * sideSpeed, 0, inputVector.y * speed);
    }
}
