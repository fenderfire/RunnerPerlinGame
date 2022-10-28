using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    new Rigidbody rigidbody;
    public float velocidad = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        rigidbody.velocity = new Vector3(hor * velocidad * Time.deltaTime, rigidbody.velocity.y, ver * velocidad * Time.deltaTime);

        

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 2, 100), transform.position.y, transform.position.z);
       
        
        
    }
}
