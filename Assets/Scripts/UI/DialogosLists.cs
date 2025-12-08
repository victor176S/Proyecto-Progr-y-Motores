using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogosLists : MonoBehaviour
{

    public static DialogosLists instance;

    public List<string> dialogos;

    public string AppendToString;

    public List<char[]> dialogosArrays;

    public TextMeshProUGUI textoCaja;
    public bool called;

    int k;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogos[0] = "Hola, has sido traido a este laboratorio para realizar algunas pruebas físicas, no te preocupes, se te dará una recompensa el final de las pruebas por el esfuerzo";
        dialogosArrays[0] = dialogos[0].ToCharArray();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    /*{
        if (!called)
        {
            StartCoroutine(DialogoLogic());
        }
    }*/

    /*public IEnumerator DialogoLogic()
    {

        switch (switch_on)
        {
            
            default:
        }

        for (int i = 0; i < dialogosArrays[0].Length; i++)
        {
            called =true;

            if (i == 0)
            {
                AppendToString += dialogo1Array[i].ToString();
                yield return new WaitForSeconds(0.03f);
            }

            else
            {
                if(dialogo1Array[i-1].ToString() == ",")
                {
                    yield return new WaitForSeconds(0.4f);
                }
                else
                {
                    yield return new WaitForSeconds(0.03f);
                }
                    AppendToString += dialogo1Array[i].ToString();
            }

           
            Debug.Log($"Dialogo: {AppendToString}");
            textoCaja.text = AppendToString;
        }

        
        textoCaja.transform.parent.gameObject.GetComponent<AlphaChangerPanelImage>().hasChildren = true;

        textoCaja.transform.parent.gameObject.GetComponent<AlphaChangerPanelImage>().fade = true;
    }*/
    
}
