using System.Collections;
using UnityEngine;

public class ArrowsAnim : MonoBehaviour
{

    public static ArrowsAnim instance;

    private float velocidad;

    public int vecesQueSeMueve;

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

    public IEnumerator TopToBottomArrowsAnim() //works
    {

        velocidad = 50/vecesQueSeMueve;

        for (int i = 0; i < vecesQueSeMueve; i++) //works
        {
            GameManager.instance.TopToBottomArrows.gameObject.transform.GetChild(0).position += new Vector3 (0, -5f, 0) * velocidad;
            GameManager.instance.TopToBottomArrows.gameObject.transform.GetChild(1).position += new Vector3 (0, -5f, 0) * velocidad;

            yield return new WaitForSeconds (0.02f);
        }

        for (int i = 0; i < vecesQueSeMueve; i++)
        {

            yield return new WaitForSeconds (0.02f);

        }

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
            GameManager.instance.TopToBottomArrows.gameObject.transform.GetChild(0).position += new Vector3 (0, -1f, 0) * velocidad;
            GameManager.instance.TopToBottomArrows.gameObject.transform.GetChild(1).position += new Vector3 (0, -1f, 0) * velocidad;

            yield return new WaitForSeconds (0.02f);
        }

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
            GameManager.instance.TopToBottomArrows.gameObject.transform.GetChild(0).position += new Vector3 (0, 1f, 0) * velocidad;
            GameManager.instance.TopToBottomArrows.gameObject.transform.GetChild(1).position += new Vector3 (0, 1f, 0) * velocidad;

            yield return new WaitForSeconds (0.02f);
        }

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
            GameManager.instance.TopToBottomArrows.gameObject.transform.GetChild(0).position += new Vector3 (0, -1f, 0) * velocidad;
            GameManager.instance.TopToBottomArrows.gameObject.transform.GetChild(1).position += new Vector3 (0, -1f, 0) * velocidad;

            yield return new WaitForSeconds (0.02f);
        }

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
            GameManager.instance.TopToBottomArrows.gameObject.transform.GetChild(0).position += new Vector3 (0, 1f, 0) * velocidad;
            GameManager.instance.TopToBottomArrows.gameObject.transform.GetChild(1).position += new Vector3 (0, 1f, 0) * velocidad;

            yield return new WaitForSeconds (0.02f);
        }

        //las flechas vuelven y se recolocan

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
            GameManager.instance.TopToBottomArrows.gameObject.transform.GetChild(0).position += new Vector3 (0, 5f, 0) * velocidad;
            GameManager.instance.TopToBottomArrows.gameObject.transform.GetChild(1).position += new Vector3 (0, 5f, 0) * velocidad;

            yield return new WaitForSeconds (0.02f);
        }
    }

    public IEnumerator LeftToRightArrowsAnim() //works
    {
        velocidad = 50/vecesQueSeMueve;

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
            GameManager.instance.LeftToRightArrows.gameObject.transform.GetChild(0).position += new Vector3 (5f, 0, 0) * velocidad;
            GameManager.instance.LeftToRightArrows.gameObject.transform.GetChild(1).position += new Vector3 (5f, 0, 0) * velocidad;

            yield return new WaitForSeconds (0.02f);
        }

        for (int i = 0; i < vecesQueSeMueve; i++)
        {

            yield return new WaitForSeconds (0.02f);

        }

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
            GameManager.instance.LeftToRightArrows.gameObject.transform.GetChild(0).position += new Vector3 (1f, 0, 0) * velocidad;
            GameManager.instance.LeftToRightArrows.gameObject.transform.GetChild(1).position += new Vector3 (1f, 0, 0) * velocidad;

            yield return new WaitForSeconds (0.02f);
        }

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
            GameManager.instance.LeftToRightArrows.gameObject.transform.GetChild(0).position += new Vector3 (-1f, 0, 0) * velocidad;
            GameManager.instance.LeftToRightArrows.gameObject.transform.GetChild(1).position += new Vector3 (-1f, 0, 0) * velocidad;

            yield return new WaitForSeconds (0.02f);
        }

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
            GameManager.instance.LeftToRightArrows.gameObject.transform.GetChild(0).position += new Vector3 (1f, 0, 0) * velocidad;
            GameManager.instance.LeftToRightArrows.gameObject.transform.GetChild(1).position += new Vector3 (1f, 0, 0) * velocidad;

            yield return new WaitForSeconds (0.02f);
        }

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
            GameManager.instance.LeftToRightArrows.gameObject.transform.GetChild(0).position += new Vector3 (-1f, 0, 0) * velocidad;
            GameManager.instance.LeftToRightArrows.gameObject.transform.GetChild(1).position += new Vector3 (-1f, 0, 0) * velocidad;

            yield return new WaitForSeconds (0.02f);
        }

        //las flechas vuelven y se recolocan

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
            GameManager.instance.LeftToRightArrows.gameObject.transform.GetChild(0).position += new Vector3 (-5f, 0, 0) * velocidad;
            GameManager.instance.LeftToRightArrows.gameObject.transform.GetChild(1).position += new Vector3 (-5f, 0, 0) * velocidad;

            yield return new WaitForSeconds (0.02f);
        }

    }

    public IEnumerator BottomToRightArrowsAnim() 
    {

        velocidad = 50/vecesQueSeMueve;

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
            GameManager.instance.BottomToTopArrows.gameObject.transform.GetChild(0).position += new Vector3 (0, 5f, 0) * velocidad;
            GameManager.instance.BottomToTopArrows.gameObject.transform.GetChild(1).position += new Vector3 (0, 5f, 0) * velocidad;

            yield return new WaitForSeconds (0.02f);
        }

        for (int i = 0; i < vecesQueSeMueve; i++)
        {

            yield return new WaitForSeconds (0.02f);

        }

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
            GameManager.instance.BottomToTopArrows.gameObject.transform.GetChild(0).position += new Vector3 (0, 1f, 0) * velocidad;
            GameManager.instance.BottomToTopArrows.gameObject.transform.GetChild(1).position += new Vector3 (0, 1f, 0) * velocidad;

            yield return new WaitForSeconds (0.02f);
        }

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
            GameManager.instance.BottomToTopArrows.gameObject.transform.GetChild(0).position += new Vector3 (0, -1f, 0) * velocidad;
            GameManager.instance.BottomToTopArrows.gameObject.transform.GetChild(1).position += new Vector3 (0, -1f, 0) * velocidad;

            yield return new WaitForSeconds (0.02f);
        }

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
            GameManager.instance.BottomToTopArrows.gameObject.transform.GetChild(0).position += new Vector3 (0, 1f, 0) * velocidad;
            GameManager.instance.BottomToTopArrows.gameObject.transform.GetChild(1).position += new Vector3 (0, 1f, 0) * velocidad;

            yield return new WaitForSeconds (0.02f);
        }

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
            GameManager.instance.BottomToTopArrows.gameObject.transform.GetChild(0).position += new Vector3 (0, -1f, 0) * velocidad;
            GameManager.instance.BottomToTopArrows.gameObject.transform.GetChild(1).position += new Vector3 (0, -1f, 0) * velocidad;

            yield return new WaitForSeconds (0.02f);
        }

        //las flechas vuelven y se recolocan

        for (int i = 0; i < vecesQueSeMueve; i++)
        {
            GameManager.instance.BottomToTopArrows.gameObject.transform.GetChild(0).position += new Vector3 (0, -5f, 0) * velocidad;
            GameManager.instance.BottomToTopArrows.gameObject.transform.GetChild(1).position += new Vector3 (0, -5f, 0) * velocidad;

            yield return new WaitForSeconds (0.02f);
        }
    }

    
}
