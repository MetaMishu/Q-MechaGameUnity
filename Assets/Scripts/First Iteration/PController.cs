using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] float movementFactor = 10.0f;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");


        var movement = new Vector3(horizontal, 0, vertical);
        characterController.SimpleMove(movement * movementFactor * Time.deltaTime);

         
    }
}
