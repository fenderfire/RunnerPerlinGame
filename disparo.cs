using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    public GameObject canon;
    public Transform refPoint;
    private Transform refplayer;
    public void instaciodisparo ()
    {
        GameObject bala = Instantiate(canon, refPoint.position, transform.rotation) as GameObject;

        bala.SetActive(true);


    }
    // Start is called before the first frame update
    void Start()
    {
        refplayer = FindObjectOfType<Movimiento>().transform;
        InvokeRepeating("instaciodisparo", 1f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(refplayer.position.x, transform.position.y, refplayer.position.z);
        transform.LookAt(direction);
    }
}
