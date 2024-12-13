using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuacoMovement : MonoBehaviour
{
    public float speed = 2f; // Velocidad del movimiento
    public float distance = 2f; // Distancia máxima hacia abajo

    private Vector3 startPosition;
    private bool movingDown = true; // Controla la dirección del movimiento

    void Start()
    {
        // Guardamos la posición inicial del objeto
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculamos la nueva posición
        if (movingDown)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;

            // Verificamos si llegó a la distancia máxima hacia abajo
            if (startPosition.y - transform.position.y >= distance)
            {
                movingDown = false; // Cambiamos la dirección
            }
        }
        else
        {
            transform.position += Vector3.up * speed * Time.deltaTime;

            // Verificamos si volvió a la posición inicial
            if (transform.position.y >= startPosition.y)
            {
                movingDown = true; // Cambiamos la dirección
                transform.position = startPosition; // Aseguramos la posición exacta
            }
        }
    }
}