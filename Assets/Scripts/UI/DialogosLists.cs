using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DialogosLists : MonoBehaviour
{

    [SerializeField] private float delayCleanDialogue;

    public static DialogosLists instance;

    public List<string> dialogos;

    public List<int> dialogosSeleccionados;

    private string AppendToString;

    public TextMeshProUGUI textoCaja;
    private bool called;

    public int dialogo;

    public bool isOneDialog;

    public int dialogNumberEnd;

    public float tiempoDialogos;

    public float delay;

    private bool delayFinished;

    public float delayBetweenDialoges;

    private int l;

    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        dialogos.Insert(0, "Hola, has sido traido a este laboratorio para realizar algunas pruebas físicas, no te preocupes, se te dará una recompensa el final de las pruebas por el esfuerzo");

        dialogos.Insert(1, "Deberias probar a moverte");
        Debug.Log(dialogos[0]);

        /*dialogos[1] = "dialogo 2";
        dialogosArrays[1] = dialogos[1].ToCharArray();*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isOneDialog == true)
        {

             StartCoroutine(Delay());

            if (delayFinished == true)
            {
                if (!called)
                {

                    var dialogoArray = dialogos[dialogo].ToCharArray();

                    StartCoroutine(DialogoLogic(dialogoArray));
                }

            }

        }

        if (isOneDialog == false)
        {
            StartCoroutine(Delay());

            if (delayFinished == true)
            {
                if (!called)
                {
                
                    StartCoroutine(MultiDialogos());  
                
                }
            }
   
        }
        
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);

        delayFinished = true;

    }

    public IEnumerator MultiDialogos()
    {


        for (l = 0; l < dialogos.Count; l++)
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
                    yield return new WaitForSeconds(tiempoDialogos + delayBetweenDialoges);
            }

            l = 0;
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

            Debug.Log($"Append: {AppendToString}");

            //limpiar caja de texto despues de cada dialogo

            if (i == dialogoArray.Length - 1 && l < dialogos.Count - 1) //la ultima condicion permite que el ultimo dialogo no se vaya
            {

                yield return new WaitForSeconds(delayBetweenDialoges);

                Array.Clear(dialogoArray, 0, dialogoArray.Length);
                textoCaja.text = "";
                AppendToString = "";
            }
        }

    }
    
}
