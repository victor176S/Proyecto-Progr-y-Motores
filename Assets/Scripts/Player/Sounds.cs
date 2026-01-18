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

    public AudioSource hurtedSharp;

    public AudioSource boxCollision;

    public AudioSource landing;

    public AudioSource boxesFalling;

    public AudioSource musicaNivel;

    public AudioSource levelExtension;

    public AudioSource aterrizaje;

    public bool Reproduciendo;

    GameObject datosPersistentes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        instance = this;

        datosPersistentes = GameObject.Find("DatosPersistentes");
    }
    void Start()
    {
        if (musicaNivel != null)
        {
            musicaNivel.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (datosPersistentes != null)
        {
            
        viento.volume = datosPersistentes.GetComponent<DatosPersistentes>().volumenSFX;
        cargarSalto.volume = datosPersistentes.GetComponent<DatosPersistentes>().volumenSFX;
        hurted.volume = datosPersistentes.GetComponent<DatosPersistentes>().volumenSFX;
        hurtedSharp.volume = datosPersistentes.GetComponent<DatosPersistentes>().volumenSFX;
        boxCollision.volume = datosPersistentes.GetComponent<DatosPersistentes>().volumenSFX;
        landing.volume = datosPersistentes.GetComponent<DatosPersistentes>().volumenSFX;
        boxesFalling.volume = datosPersistentes.GetComponent<DatosPersistentes>().volumenSFX;
        aterrizaje.volume = datosPersistentes.GetComponent<DatosPersistentes>().volumenSFX;
        musicaNivel.volume = datosPersistentes.GetComponent<DatosPersistentes>().volumenMusica;
        levelExtension.volume = datosPersistentes.GetComponent<DatosPersistentes>().volumenMusica;
        
        }

       


        if (this.gameObject.GetComponent<PlayerMovement>().enSuelo && Input.GetKey(KeyCode.Space) || this.gameObject.GetComponent<PlayerMovement>().enSuelo && this.gameObject.GetComponent<PlayerMovement>().saltoBuffer)
        {
            landing.Play();
        }

        if (this.gameObject.GetComponent<PlayerMovement>().enSuelo)
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

                if (this.gameObject.GetComponent<PlayerMovement>().botonSaltoMantenido && this.gameObject.GetComponent<PlayerMovement>().enSuelo)
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

                hurted.Play();

                break;

            case 3:

                hurtedSharp.Play();

                break;

            case 5:

                aterrizaje.Play();

                break;
            
            default:

                break;
        }
        
       yield return new WaitForSeconds(0.01f);

    }
}
