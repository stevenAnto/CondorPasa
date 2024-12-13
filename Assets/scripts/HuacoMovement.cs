using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuacoMovement : MonoBehaviour
{
    public float speed = 2f; // Velocidad del movimiento
    public float distance = 2f; // Distancia m�xima hacia abajo

    private Vector3 startPosition;
    private bool movingDown = true; // Controla la direcci�n del movimiento

    void Start()
    {
        // Guardamos la posici�n inicial del objeto
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculamos la nueva posici�n
        if (movingDown)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;

            // Verificamos si lleg� a la distancia m�xima hacia abajo
            if (startPosition.y - transform.position.y >= distance)
            {
                movingDown = false; // Cambiamos la direcci�n
            }
        }
        else
        {
            transform.position += Vector3.up * speed * Time.deltaTime;

            // Verificamos si volvi� a la posici�n inicial
            if (transform.position.y >= startPosition.y)
            {
                movingDown = true; // Cambiamos la direcci�n
                transform.position = startPosition; // Aseguramos la posici�n exacta
            }
        }
    }
}