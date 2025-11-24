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
                //un poco hacia arriba
                
                camYextra = 25;

                break;

            case 1:

                camYextra = 0;

                break;

        }
       
    }
}
