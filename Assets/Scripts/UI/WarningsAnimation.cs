using System.Collections;
using UnityEngine;

public class WarningsAnimation : MonoBehaviour
{

    public static WarningsAnimation instance;

    int i;

    GameObject gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        instance = this;

        gameManager = GameObject.Find("GameManager");

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator WarningAnimationUP(bool Left, bool LeftCent, bool Cent, bool RightCent, bool Right)                                           
    {

        if (Left)
        {

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            
        }

        if (LeftCent)
        {
            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            
        }

        if (Cent)
        {
            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            
        }

        if (RightCent)
        {
            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(3).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(3).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(3).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(3).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(3).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(3).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            
        }

        if (Right)
        {
            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(4).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(4).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(4).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(4).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(4).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(4).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            
        }

        
    }

    public IEnumerator WarningAnimationDown(bool Left, bool LeftCent, bool Cent, bool RightCent, bool Right)                                          
    {

        if (Left)
        {
            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            
        }

        if (LeftCent)
        {
            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            
        }

        if (Cent)
        {
            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            
        }

        if (RightCent)
        {

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(3).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(3).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(3).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(3).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(3).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(3).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            
        }

        if (Right)
        {

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(4).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(4).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(4).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(4).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(4).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(4).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            
        }
    }


    public IEnumerator WarningAnimationUP(bool Left, bool LeftCent, bool Cent, bool RightCent, bool Right, int repeat)                                           
    {

        if (Left)
        {

            for (i = 1; i < repeat; i++)
            {

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);

            }
            
        }

        if (LeftCent)
        {
            for (i = 1; i < repeat; i++)
            {
            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            }
        }

        if (Cent)
        {   
            for (i = 1; i < repeat; i++)
            {
            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            }
            
        }

        if (RightCent)
        {
            for (i = 1; i < repeat; i++)
            {
            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(3).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(3).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            }
            
        }

        if (Right)
        {
            for (i = 1; i < repeat; i++)
            {
            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(4).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(0).GetChild(4).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            }
            
        }

        
    }

    public IEnumerator WarningAnimationDown(bool Left, bool LeftCent, bool Cent, bool RightCent, bool Right, int repeat)                                          
    {

        if (Left)
        {
            for (i = 1; i < repeat; i++)
            {
            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            }

            
        }

        if (LeftCent)
        {
            for (i = 1; i < repeat; i++)
            {
            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            }
            
        }

        if (Cent)
        {
            for (i = 1; i < repeat; i++)
            {
            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            }
            
        }

        if (RightCent)
        {
            for (i = 1; i < repeat; i++)
            {
            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(3).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(3).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            }
            
        }

        if (Right)
        {
            for (i = 1; i < repeat; i++)
            {
            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(4).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            gameManager.GetComponent<GameManager>().camara.gameObject.transform.GetChild(0).GetChild(1).GetChild(4).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.3f);
            }
            
        }
    }

}
