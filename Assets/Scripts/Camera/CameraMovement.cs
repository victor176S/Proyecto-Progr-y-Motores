using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public static CameraMovement instance;

    private float velocidad;

    public float camYextra;

    public int vecesQueSeMueve;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Movement(int opcion)
    {
        switch (opcion)
        {
            case 0:
                
                
                camYextra = 25; //un poco hacia arriba

                break;

            case 1:

                camYextra = 0; //camara centrada

                break;

            case 2:

                camYextra = -10; //camara hacia arriba

                break;

        }
       
    }
}
