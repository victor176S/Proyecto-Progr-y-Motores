using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static Sounds instance;

    public AudioSource viento;

    public AudioSource cargarSalto;

    public AudioSource hurted;

    public AudioSource boxCollision;

    public AudioSource landing;

    public AudioSource boxesFalling;

    public bool Reproduciendo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerMovement.instance.enSuelo && Input.GetKey(KeyCode.Space) || PlayerMovement.instance.enSuelo && PlayerMovement.instance.saltoBuffer)
        {
            landing.Play();
        }

        if (PlayerMovement.instance.enSuelo)
        {
            viento.Stop();
        }
        
    }

    void FixedUpdate()
    {
        if (!Input.GetKey(KeyCode.UpArrow))
        {
            cargarSalto.Stop();
            Reproduciendo = false;
        }
    }

    public IEnumerator PlaySound(int i, int veces)
    {
        switch (i)
        {
            case 0:

                for(int j = 1; j < veces; j++)
                {
                    viento.Play();
                }

                break;
                
            case 1:

                if (PlayerMovement.instance.botonSaltoMantenido && PlayerMovement.instance.enSuelo)
                {
                    Debug.Log("cargar salto sonido");

                    cargarSalto.Play();

                }
                else
                {
                    cargarSalto.Stop();
                    Reproduciendo = false;
                }

                   

                break;

            case 2:



                break;
            
            default:

                break;
        }
        
       yield return new WaitForSeconds(0.01f);

    }
}
