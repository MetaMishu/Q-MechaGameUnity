using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    float cameraOffsetZ;

    void Start()
    {
        cameraOffsetZ = gameObject.transform.position.z - Player.position.z;
    }

    void Update()
    {
        Vector3 cameraPosition = new Vector3(Player.position.x, gameObject.transform.position.y, Player.position.z + cameraOffsetZ);

        gameObject.transform.position = cameraPosition;
    }
}
