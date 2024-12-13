using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombustibleControl : MonoBehaviour
{
    private AudioSource audioSource;
    private Collider objectCollider;

    public float rotationSpeed = 50f; // Velocidad de rotación

    void Start()
    {
        // Obtener el AudioSource ya existente en el objeto
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource no encontrado en el objeto.");
        }

        // Obtener el Collider del objeto
        objectCollider = GetComponent<Collider>();
        if (objectCollider == null)
        {
            Debug.LogError("Collider no encontrado en el objeto.");
        }
    }

    void Update()
    {
        // Movimiento de rotación de izquierda a derecha infinitamente
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Reproduce el sonido de colisión si el AudioSource está configurado
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }

        // Cambiar el tamaño del objeto a cero
        transform.localScale = Vector3.zero;

        // Desactiva el collider para que no pueda interactuar nuevamente
        if (objectCollider != null)
        {
            objectCollider.enabled = false;
        }

        // Destruye el objeto después de 3 segundos
        Destroy(gameObject, 3f);
    }
}
