using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRotation : MonoBehaviour
{
    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 tragetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Quaternion rotation = Quaternion.LookRotation(tragetPosition - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10.0f);

        }
    }
}
