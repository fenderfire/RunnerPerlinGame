using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject dificultades;
    public void play()
    {
        dificultades.SetActive(true);
    }

    public void exit()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setfacil()
    {
        FindObjectOfType<GameManager>().dificultad = "facil";
        SceneManager.LoadScene("Escenacapsula");
    }
    public void setmedio()
    {
        FindObjectOfType<GameManager>().dificultad = "media";
        SceneManager.LoadScene("Escenacapsula");
    }
    public void setdificil()
    {
        FindObjectOfType<GameManager>().dificultad = "dificil";
        SceneManager.LoadScene("Escenacapsula");
    }
}
