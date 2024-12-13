using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public float rotationSpeed = 45f; // Velocidad de rotación en grados por segundo

    // Update es llamado una vez por frame
    void Update()
    {
        // Rotar el objeto en 45 grados por segundo de manera infinita
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
