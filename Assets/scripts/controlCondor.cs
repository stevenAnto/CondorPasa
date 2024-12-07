using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlCondor : MonoBehaviour
{
    Rigidbody rigidbody;
    Transform transform;
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
    private void Impulso(){
        if(Input.GetKey(KeyCode.Space)){
            rigidbody.AddRelativeForce(Vector3.up);
            print("impulso");
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(Vector3.left);
            print("ziquierda");
        }
        else if(Input.GetKey(KeyCode.D)){
            transform.Rotate(Vector3.right);
            print("derecha");
            
        }
    }
    private void Rotacion(){

    }
}
