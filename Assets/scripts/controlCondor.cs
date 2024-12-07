using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlCondor : MonoBehaviour
{
    Rigidbody rigidbody;
    Transform transform;
    private bool isRotationFrozen = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Impulso();
        Rotacion();

    }
    private void Impulso()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up);
            print("impulso");
              // Reactivar rotación si estaba congelada
            if (isRotationFrozen)
            {
                rigidbody.freezeRotation = false;
                isRotationFrozen = false;
            }
        }

    }
    private void Rotacion()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.left);
            print("ziquierda");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.right);
            print("derecha");

        }
    }
    private void OnCollisionEnter(Collision collision){
        switch (collision.gameObject.tag){
            case "combustible":
                print("combustible");
                 rigidbody.freezeRotation = true;
                isRotationFrozen = true;
                break;
            case "seguro":
                print("seguro");
                 rigidbody.freezeRotation = true;
                isRotationFrozen = true;
                break;
            case "siguienteNivel":
                print("llegaste");
                SceneManager.LoadScene("nivel2");
                break;
            default:
                SceneManager.LoadScene("nivel1");
                print("muerto");
                break;
        }
    }
}
