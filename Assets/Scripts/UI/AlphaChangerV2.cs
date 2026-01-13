using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.UI;

public class AlphaChangerV2 : MonoBehaviour
{

    public static AlphaChangerV2 instance;

    public GameObject objeto;
    [SerializeField] private bool hasChildren;

    [SerializeField] private bool atStart;

    [Tooltip("entre 0 y 1")]
    [SerializeField] private float alpha;
    [SerializeField] private bool fade;
    [SerializeField] private bool appear;
    [SerializeField] private float timeChangeAlpha;

    [SerializeField] private float delay;
    public List<GameObject> hijosRawImage;
    public List<GameObject> hijosTextMesh;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (atStart)
        {
            StartCoroutine(AlphaChanger());
        }      
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator AlphaChanger()
    {

        yield return new WaitForSeconds(delay);

        if (fade)
        {
            
        }
        else
        {
            appear = true;
        }

        Debug.Log("AlphaChanger1");

        if (hasChildren == false)
        {

            Debug.Log("AlphaChanger2");

            if (fade == true)
            {
                if (objeto.GetComponent<SpriteRenderer>() != null)
                {
                    for (int i = 0; i < alpha * 255; i++)
                    {
                        yield return new WaitForSeconds(timeChangeAlpha / (alpha * 255));
                        objeto.gameObject.GetComponent<SpriteRenderer>().color += new Color (0f,0f,0f, 0f - alpha/255);
                    }
                }

                if (objeto.GetComponent<UnityEngine.UI.Image>() != null)
                {
                    for (int i = 0; i < alpha * 255; i++)
                    {
                        yield return new WaitForSeconds(timeChangeAlpha / (alpha * 255));
                        objeto.gameObject.GetComponent<UnityEngine.UI.Image>().color += new Color (0f,0f,0f, 0f - alpha/255);
                    }
                }
            }

            if (appear == true)
            {
                if (objeto.GetComponent<SpriteRenderer>() != null)
                {
                    for (int i = 0; i < alpha * 255; i++)
                    {
                        yield return new WaitForSeconds(timeChangeAlpha / (alpha * 255));
                        objeto.gameObject.GetComponent<SpriteRenderer>().color += new Color (0f,0f,0f, 0f + alpha/255);
                    }
                }

                if (objeto.GetComponent<UnityEngine.UI.Image>() != null)
                {

                    Debug.Log("AlphaChanger3");

                    for (int i = 0; i < alpha * 255; i++)
                    {

                        Debug.Log("AlphaChangerFor");

                        yield return new WaitForSeconds(timeChangeAlpha / (alpha * 255));
                        objeto.gameObject.GetComponent<UnityEngine.UI.Image>().color += new Color (0f,0f,0f, 0f + alpha/255);
                    }
                }
            }

            
        }

        else
        {

            if (fade == true)
            {
                if (objeto.GetComponent<SpriteRenderer>() != null)
                {
                    for (int i = 0; i < alpha * 255; i++)
                    {
                        yield return new WaitForSeconds(timeChangeAlpha / (alpha * 255));
                        objeto.gameObject.GetComponent<SpriteRenderer>().color += new Color (0f,0f,0f, 0f - alpha/255);
                        ChangeChildAlpha();
                    }
                }

                if (objeto.GetComponent<UnityEngine.UI.Image>() != null)
                {
                    for (int i = 0; i < alpha * 255; i++)
                    {
                        yield return new WaitForSeconds(timeChangeAlpha / (alpha * 255));
                        objeto.gameObject.GetComponent<UnityEngine.UI.Image>().color += new Color (0f,0f,0f, 0f - alpha/255);
                        ChangeChildAlpha();
                    }
                }
            }

            if (appear == true)
            {
                if (objeto.GetComponent<SpriteRenderer>() != null)
                {
                    for (int i = 0; i < alpha * 255; i++)
                    {
                        yield return new WaitForSeconds(timeChangeAlpha / (alpha * 255));
                        objeto.gameObject.GetComponent<SpriteRenderer>().color += new Color (0f,0f,0f, 0f + alpha/255);
                        ChangeChildAlpha();
                        
                    }
                }

                if (objeto.GetComponent<UnityEngine.UI.Image>() != null)
                {

                    Debug.Log("AlphaChanger3");

                    for (int i = 0; i < alpha * 255; i++)
                    {

                        Debug.Log("AlphaChangerFor");

                        yield return new WaitForSeconds(timeChangeAlpha / (alpha * 255));
                        objeto.gameObject.GetComponent<UnityEngine.UI.Image>().color += new Color (0f,0f,0f, 0f + alpha/255);
                        ChangeChildAlpha();
                    }
                }
            }
        } 
    }

    void ChangeChildAlpha()
    {

                foreach (GameObject hijo in hijosRawImage)
                {
                   hijo.gameObject.GetComponent<RawImage>().color = new Color (255f,255f,255f,objeto.gameObject.GetComponent<UnityEngine.UI.Image>().color.a/2);
                }   
                foreach (GameObject hijo in hijosTextMesh)
                {
                   hijo.gameObject.GetComponent<TextMeshProUGUI>().color = new Color (255f,255f,255f,objeto.gameObject.GetComponent<UnityEngine.UI.Image>().color.a/2);
                }

    }
}
