using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{


    
    [SerializeField] [Range(0.5f, 1.0f)] 
    private float fireRate = 1.0f;
     
    [SerializeField] [Range(1.0f, 10.0f)] private int damage = 1;
    private float timer;

    [SerializeField]
    private Transform firePoint;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                fireGun();
            }
        }
    }

    private void fireGun()
    {
        Debug.DrawRay(firePoint.position, transform.forward * 100, Color.red, 2f);

        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            var Health = hitInfo.collider.GetComponent<Health>();
            if (Health != null)
            Health.TakeDamage(damage);
        }
    }
}

