using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody>().velocity = -transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.forward * speed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cubo")
        {
            Debug.Log("daño1");
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("daño");
            Destroy(gameObject);
        }
    }        
}
