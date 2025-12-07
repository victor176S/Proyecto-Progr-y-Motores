using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Dialogos : MonoBehaviour
{

    public static Dialogos instance;

    public string dialogo1;

    public char[] dialogo1Array;

    public TextMeshProUGUI textoCaja;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogo1 = "Texto de prueba";
        dialogo1Array = dialogo1.ToCharArray();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(DialogoLogic());
    }

    public IEnumerator DialogoLogic()
    {
        for (int i = 0; i < dialogo1Array.Length; i++)
        {
            yield return new WaitForSeconds(0.2f);
            textoCaja.text.Append(dialogo1Array[i]);
        }
        
    }
    
}
