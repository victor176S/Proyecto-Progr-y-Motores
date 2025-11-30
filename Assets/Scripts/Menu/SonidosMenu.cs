using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosMenu : MonoBehaviour
{

    public static SonidosMenu instance;

    public AudioSource SFX_Prueba;

    public AudioSource Musica_Prueba;

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
        
        

    }

    public void PlaySound(int i)
    {
        StartCoroutine(PlaySoundLogic(i));
    }
    

    public void StopSound(int i)
    {
        StartCoroutine(StopSoundLogic(i));
    }

    public IEnumerator StopSoundLogic(int i)
    {
        
        switch (i)
        {

            case 0:

            SFX_Prueba.Stop();

            yield return new WaitForSeconds(0.1f);

                break;

            case 1:

            Musica_Prueba.Stop();

            yield return new WaitForSeconds(0.1f);

                break;
            
           
        }

    }

    public IEnumerator PlaySoundLogic(int i)
    {
        
        switch (i)
        {

            case 0:

            SFX_Prueba.Play();

            yield return new WaitForSeconds(0.1f);

                break;

            case 1:

            Musica_Prueba.Play();

            yield return new WaitForSeconds(0.1f);

                break;
            
           
        }

    } 
}
