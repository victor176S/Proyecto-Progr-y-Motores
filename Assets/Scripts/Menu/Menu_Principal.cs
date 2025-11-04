using UnityEngine;

public class Menu_Principal : MonoBehaviour
{

    public GameObject pantallaPrincipal;

    public GameObject pantallaOpciones;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        pantallaOpciones.SetActive(false);

    }

    public void ActivarPantallaOpciones()
    {

        pantallaPrincipal.SetActive(false);
        pantallaOpciones.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
