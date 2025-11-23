using System.Collections;
using UnityEngine;

public class ReOrganizeUI : MonoBehaviour
{

    

    public static ReOrganizeUI instance;

    public int veces = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        //SI NO SE PONE EL SCRIPT A UN OBJETO, ESTO DA ERROR
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator UIFromRightToTop()
    {
        //X = 550 Y = -90 con respecto a la pantalla?

        for (int i = 0; i < veces; i++)
        {
            GameManager.instance.LivesUI.transform.position += new Vector3 (-16, 1, 0);

            GameManager.instance.porcentajeSaltoText.transform.position += new Vector3 (-28, 3, 0);

            GameManager.instance.DashCharge.transform.position += new Vector3 (0, 5, 0);

            yield return new WaitForSeconds (0.02f);
        }

        
    }
}
