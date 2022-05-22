using UnityEngine;
using UnityEngine.InputSystem;

public class hideCursor : MonoBehaviour
{

    
    
    void Start()
    {
        ToggleCursorLockState();
    }

     void Update()
    {
        
    }

    public void ToggleCursorLockState()
{
    if (Cursor.lockState != CursorLockMode.Locked) Cursor.lockState = CursorLockMode.Locked;
    else Cursor.lockState = CursorLockMode.None;
}
}
