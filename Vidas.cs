using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Vidas : MonoBehaviour
{
    public Text perder;
    public Image perderfondo;
    public float vidas = 5;
    public Text numerovidas;
    public Text cronometro;
    public float tiempo;
    private bool oportunidad = true;
    public Transform respawn;

    public GameObject finJuegoPanel;


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        numerovidas.text = "vidas:" + vidas;
       
        if (vidas > 0)
        {
            tiempo = Time.time;
            cronometro.text = "tiempo: " + tiempo.ToString("0"); 
        }
        if (vidas <= 0)
        {
            if (oportunidad == true)
            {
                vidas = 1;
                transform.position = respawn.position;
                oportunidad = false;
            }
            else
            {
                vidas = 0;
                numerovidas.enabled = false;
                finJuegoPanel.SetActive(true);

            }

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bala")
        {

            vidas--;
        }

        else if (other.gameObject.tag == "powerup")
        {

            vidas+= 0.5f;
            Destroy(other.gameObject);
        }



       

        if (other.gameObject.tag == "morirse")
        {
            if (oportunidad == true)
            {
                vidas = 1;
                transform.position = respawn.position;
                oportunidad = false;
            }
            else
            {
                vidas = 0;
                numerovidas.enabled = false;
                finJuegoPanel.SetActive(true);

            }
            
        }

    }
}
