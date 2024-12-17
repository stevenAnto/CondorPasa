using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class controlCondor : MonoBehaviour
{
    public Image barraVida;
    [SerializeField] public float vidaActual=500f;
    [SerializeField] public float vidaMaxima = 500f;
    [SerializeField] private float parametroRotation = 90f;
    [SerializeField] private float parametroImpulso = 50f;
    [SerializeField] private float consumoVidaPorSegundo = 5f;
    Rigidbody rigidbody;
    Transform transform;
    private bool isRotationFrozen = false;
    // Start is called before the first frame update
    void Start()
    {
         GameObject canvas = GameObject.Find("Canvas");
         Transform background = canvas.transform.Find("background");
         barraVida = background.transform.Find("barraVida").GetComponent<Image>();

            // Verificar si la barraVida fue asignada correctamente
    if (canvas != null)
    {
        //barraVida = canvas.transform.Find("barraVida").GetComponent<Image>();
        Debug.Log("La barra de vida ha sido asignada correctamente.");
    }
    else
    {
        Debug.LogError("No se encontró la barra de vida.");
    }
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.fillAmount = vidaActual/vidaMaxima;
        Impulso();
        Rotacion();
        if(vidaActual<=0){
             Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.name);
                print("muerto por vida");

        }

    }
    private void Impulso()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up*Time.deltaTime*parametroImpulso);

            print("impulso");
            vidaActual -=consumoVidaPorSegundo*Time.deltaTime;
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
                vidaActual = vidaMaxima;
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
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.name);
                print("muerto");
                break;
        }
    }
}
