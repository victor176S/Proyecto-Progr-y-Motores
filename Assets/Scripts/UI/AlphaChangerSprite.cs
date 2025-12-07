using UnityEngine;
using UnityEngine.Tilemaps;

public class AlphaChangerSprite : MonoBehaviour
{

    static public AlphaChangerSprite instance;

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
        AlphaChange();
    }

    public void AlphaChange()
    {
        if (appear)
        {
            AppearLogic(tiempo);
        }

        if (fade)
        {
            FadeLogic(tiempo);
        }
    }

    public void FadeLogic(float tiempo)
    {
        if (contador <= tiempo)
        {
            contador += Time.deltaTime;

            if (fade)
            {
                objeto.gameObject.GetComponent<SpriteRenderer>().color += new Color (0f,0f,0f, 0f - (1/tiempo * Time.deltaTime));
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
                //if (transitionStart && objeto.gameObject.GetComponent<SpriteRenderer>().color.a <= 0.3f)
                if (transitionStart && objeto.gameObject.GetComponent<SpriteRenderer>().color.a <= transicionStartAlphaLimit)
                {
                    objeto.gameObject.GetComponent<SpriteRenderer>().color += new Color (0f,0f,0f, 0f - (transicionStartIntesity/tiempo * Time.deltaTime));
                }

                if (objeto.gameObject.GetComponent<SpriteRenderer>().color.a > 0.3f && objeto.gameObject.GetComponent<SpriteRenderer>().color.a < transicionEndAlphaLimit)
                {
                    objeto.gameObject.GetComponent<SpriteRenderer>().color += new Color (0f,0f,0f, 0f - (transitionMiddleIntensity/tiempo * Time.deltaTime));
                }

                if (transitionEnd && objeto.gameObject.GetComponent<SpriteRenderer>().color.a >= transicionEndAlphaLimit)
                {
                    objeto.gameObject.GetComponent<SpriteRenderer>().color += new Color (0f,0f,0f, 0f - (transicionEndIntesity/tiempo * Time.deltaTime));
                }

            }

        }

        if (contador > tiempo && fadeActive)
        {
            contador = tiempo; 
        }
    }

    public void AppearLogic(float tiempo)
    {
        if (contador <= tiempo)
        {
            contador += Time.deltaTime;

            if (appear)
            {
                objeto.gameObject.GetComponent<SpriteRenderer>().color += new Color (0f,0f,0f, 0f + (1/tiempo * Time.deltaTime));
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
                objeto.gameObject.GetComponent<SpriteRenderer>().color += new Color (0f,0f,0f, 0f - (1/tiempo * Time.deltaTime));
            }

        }

        if (contador > tiempo && appearActive)
        {
            contador = tiempo; 
        }
    }
}
