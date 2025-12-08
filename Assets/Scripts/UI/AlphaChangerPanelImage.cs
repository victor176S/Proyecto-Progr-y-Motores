using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class AlphaChangerPanelImage : MonoBehaviour
{

    static public AlphaChangerPanelImage instance;

    public GameObject objeto;

    public float contador;
    public float tiempo;

    [Header ("transitionMiddleIntensity - (transicionEndIntesity")] 
    [Header ("+ transicionStartIntesity) tiene que ser igual a 1")]

    public bool fade;

    public bool fadeActive;

    public bool appearActive;

    public bool transitionStart;

    public bool transitionEnd;

    public bool appear;

    public int opcion;

    public float transicionStartAlphaLimit;

    public float transicionEndAlphaLimit;

    public float transicionStartIntesity;

    public float transicionEndIntesity;

    public float transitionMiddleIntensity;
    public bool hasChildren;

    public float alpha;

    public float delay;

    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //transitionMiddleIntensity - (transicionEndIntesity + transicionStartIntesity) tiene que ser igual a 1

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AlphaChange(tiempo, delay);

        alpha = objeto.gameObject.GetComponent<UnityEngine.UI.Image>().color.a;
    }

    public void AlphaChange(float tiempo, float delay)
    {
        if (appear)
        {
            StartCoroutine(AppearLogic(tiempo, delay));
        }

        if (fade)
        {
            StartCoroutine(FadeLogic(tiempo, delay));
        }
    }

    public IEnumerator FadeLogic(float tiempo, float delay)
    {

        yield return new WaitForSeconds(delay);
        
        if (contador <= tiempo)
        {
            contador += Time.deltaTime * 6;

            if (fade)
            {
                objeto.gameObject.GetComponent<UnityEngine.UI.Image>().color += new Color (0f,0f,0f, 0f - (1/tiempo * Time.deltaTime * 6));

                if (hasChildren)
                {
                    ObjectChildren.instance.ApplyAlphaToChildren();
                }
            }

        }

        if (contador > tiempo && fadeActive)
        {
            contador = tiempo; 
        }
    }

    public void FadeLogic(float tiempo, bool transitionStart, bool transitionEnd)
    {
        if (contador <= tiempo)
        {
            contador += Time.deltaTime;

            if (fade)
            {
                //if (transitionStart && objeto.gameObject.GetComponent<UnityEngine.UI.Image>().color.a <= 0.3f)
                if (transitionStart && objeto.gameObject.GetComponent<UnityEngine.UI.Image>().color.a <= transicionStartAlphaLimit)
                {
                    objeto.gameObject.GetComponent<UnityEngine.UI.Image>().color += new Color (0f,0f,0f, 0f - (transicionStartIntesity/tiempo * Time.deltaTime));
                }

                if (objeto.gameObject.GetComponent<UnityEngine.UI.Image>().color.a > 0.3f && objeto.gameObject.GetComponent<UnityEngine.UI.Image>().color.a < transicionEndAlphaLimit)
                {
                    objeto.gameObject.GetComponent<UnityEngine.UI.Image>().color += new Color (0f,0f,0f, 0f - (transitionMiddleIntensity/tiempo * Time.deltaTime));
                }

                if (transitionEnd && objeto.gameObject.GetComponent<UnityEngine.UI.Image>().color.a >= transicionEndAlphaLimit)
                {
                    objeto.gameObject.GetComponent<UnityEngine.UI.Image>().color += new Color (0f,0f,0f, 0f - (transicionEndIntesity/tiempo * Time.deltaTime));
                }

            }

        }

        if (contador > tiempo && fadeActive)
        {
            contador = tiempo; 
        }
    }

    public IEnumerator AppearLogic(float tiempo, float delay)
    {

        yield return new WaitForSeconds(delay);

        if (contador <= tiempo)
        {
            contador += Time.deltaTime;

            if (appear)
            {
                objeto.gameObject.GetComponent<UnityEngine.UI.Image>().color += new Color (0f,0f,0f, 0f + (1/tiempo * Time.deltaTime));
            }

        }

        if (contador > tiempo && appearActive)
        {
            contador = tiempo; 
        }
    }

    public void AppearLogic(float tiempo, bool transitionStart, bool transitionEnd)
    {
        if (contador <= tiempo)
        {
            contador += Time.deltaTime;

            if (appear)
            {
                objeto.gameObject.GetComponent<UnityEngine.UI.Image>().color += new Color (0f,0f,0f, 0f - (1/tiempo * Time.deltaTime));
            }

        }

        if (contador > tiempo && appearActive)
        {
            contador = tiempo; 
        }
    }
}
