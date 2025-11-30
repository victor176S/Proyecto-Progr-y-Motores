using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DatosPersistentes : MonoBehaviour
{
    public static DatosPersistentes instance;

    public float volumenMusica;

    public float volumenSFX;

    public string textoInput;

    public bool codigoLyrics;

    public bool fueraDelMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {  

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            Debug.Log(volumenSFX);

            Debug.Log(volumenMusica);

            if (textoInput == "alexans")
            {
                codigoLyrics = true;
            }
        
            Debug.Log(codigoLyrics);


    }
}
