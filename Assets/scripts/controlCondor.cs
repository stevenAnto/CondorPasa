using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlCondor : MonoBehaviour
{
    [SerializeField] private float parametroRotation = 90f;
    [SerializeField] private float parametroImpulso = 50f;
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
            rigidbody.AddRelativeForce(Vector3.up*Time.deltaTime*parametroImpulso);
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
            transform.Rotate(Vector3.left*Time.deltaTime*parametroRotation);
            print("ziquierda");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.right*Time.deltaTime*parametroRotation);
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
            case "toNivel2":
                print("Pasate siguiente nivel 2");
                SceneManager.LoadScene("nivel2");
                break;
            case "toNivel3":
                print("Pasate siguiente nivel 3 ");
                SceneManager.LoadScene("nivel3");
                break;
            case "toNivel4":
                print("Pasate siguiente nivel 4 ");
                SceneManager.LoadScene("nivel4");
                break;
            case "toFinal":
                print("Ganaste todo el juego ");
                SceneManager.LoadScene("nivel1");
                break;
            default:
                SceneManager.LoadScene("nivel1");
                print("muerto");
                break;
        }
    }
}
