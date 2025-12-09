using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogosLists : MonoBehaviour
{

    public static DialogosLists instance;

    public List<string> dialogos;

    public List<int> dialogosSeleccionados;

    public string AppendToString;

    public TextMeshProUGUI textoCaja;
    public bool called;

    public int dialogo;

    public bool isOneDialog;

    public int dialogNumberEnd;

    public float tiempoDialogos;

    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        dialogos.Insert(0, "Hola, has sido traido a este laboratorio para realizar algunas pruebas físicas, no te preocupes, se te dará una recompensa el final de las pruebas por el esfuerzo");
        
        dialogos.Insert(1, "prueba 2");
        Debug.Log(dialogos[0]);

        /*dialogos[1] = "dialogo 2";
        dialogosArrays[1] = dialogos[1].ToCharArray();*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isOneDialog)
        {
            if (!called)
            {

                var dialogoArray = dialogos[dialogo].ToCharArray();

                StartCoroutine(DialogoLogic(dialogoArray));
            }

        }

        else
        {
            if (!called)
            {
                
                StartCoroutine(MultiDialogos());  
                
            }
                
        }
        
    }

    public IEnumerator MultiDialogos()
    {
        for (int l = 0; l < dialogos.Count; l++)
            {       
                    
                    dialogo = dialogosSeleccionados[l];
                    var dialogoArray = dialogos[dialogo].ToCharArray();

                    if (dialogoArray.Length > 20)
                    {
                        tiempoDialogos = 0.14f * dialogoArray.Length / 3;
                    }

                    if(dialogoArray.Length <= 20)
                    {
                        tiempoDialogos = 0.2f * dialogoArray.Length / 2;
                    }
                    
                    Debug.Log($"Multidialogo: {dialogoArray}");
                    StartCoroutine(DialogoLogic(dialogoArray));
                    yield return new WaitForSeconds(tiempoDialogos);
                    textoCaja.text = "";
            }
    }
    

    public IEnumerator DialogoLogic(char[] dialogoArray)
    {

        Debug.Log($"Longitud dialogo corrutina");

        for (int i = 0; i < dialogoArray.Length; i++)
        {
            Debug.Log($"Longitud dialogo {dialogoArray.Length}");
            called = true;

            if (i == 0)
            {
                AppendToString += dialogoArray[i].ToString();
                yield return new WaitForSeconds(0.03f);
            }

            else
            {
                if(dialogoArray[i-1].ToString() == ",")
                {
                    yield return new WaitForSeconds(0.4f);
                }
                else
                {
                    yield return new WaitForSeconds(0.03f);
                }
                    AppendToString += dialogoArray[i].ToString();
            }

           
            Debug.Log($"Dialogo: {AppendToString}");
            textoCaja.text = AppendToString;
        }

        
        textoCaja.transform.parent.gameObject.GetComponent<AlphaChangerPanelImage>().hasChildren = true;

        textoCaja.transform.parent.gameObject.GetComponent<AlphaChangerPanelImage>().fade = true;
    }
    
}
