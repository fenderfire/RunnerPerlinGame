using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int depth = 20;

    public int width = 256;
    public int height = 256;

    public float scale = 20f;

    public float offsetX = 200f;
    public float offsetZ = 200f;

    public float velocity = 5f;
    public GameObject muro;
    public GameObject cannon;
    public GameObject powerUp;
    private float murosspawn;
    private float probtorreta;
    private float probpowerup;

    private void Awake()
    {
        dificultad();
    }
    private void Start()
    {
        offsetX = Random.Range(0f, 99999f);
        offsetZ = Random.Range(0f, 99999f);
        GenerateHeights();
        InvokeRepeating("GenerateHeights", 1f, 2f);
    }

    private void dificultad()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        switch (gm.dificultad)
        {
            case "facil":
                murosspawn = 0.3f;
                probtorreta = 4;
                probpowerup = 96;
                break;
          
            case "media":
                murosspawn = 0.4f;
                probtorreta = 5;
                probpowerup = 95;
                break;
           
            case "dificil":
                murosspawn = 0.45f;
                probtorreta = 6;
                probpowerup = 94;
                break;

            default:
                break; 
        }
    }

    // Start is called before the first frame update
    void Update()
    {
       
        
        offsetX += velocity * Time.deltaTime;
    }

    
    void GenerateHeights()
    {
        float[,] heights = new float[width, height];
        
        {
            for (int x = 0; x< height; x++)
            {
                int z = 0;
                float value = CalculateHeight(x, z);

                if (value < murosspawn)
                {
                    Vector3 pos = new Vector3(x, 5, z);
                    GameObject cuboAzul = Instantiate(muro, pos, Quaternion.identity) as GameObject;
                    cuboAzul.SetActive(true);
                    Debug.Log(value);
                }

                if (value > murosspawn)
                {
                    int aleatorio = Random.Range(0, 101);

                    if (aleatorio < probtorreta)
                    {
                        Vector3 pos = new Vector3(x, 1.5f, z);
                        GameObject torreta = Instantiate(cannon, pos, Quaternion.identity) as GameObject;
                        torreta.SetActive(true);
                    }
                   
                    if (aleatorio > probpowerup)
                    {
                        Vector3 pos = new Vector3(x, 1.5f, z);
                        GameObject power = Instantiate(powerUp, pos, Quaternion.identity) as GameObject;
                        power.SetActive(true);
                    }
                }


            }
        }

        
    }

    float CalculateHeight(int x, int z)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float zCoord = (float)z / height * scale + offsetZ;

        float vPerlin = Mathf.PerlinNoise(xCoord, zCoord);
        return vPerlin;
    }
}
