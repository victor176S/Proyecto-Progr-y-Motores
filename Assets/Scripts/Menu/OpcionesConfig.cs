using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpcionesConfig : MonoBehaviour
{

    public static OpcionesConfig instance;
    private GameObject datosPersistentes;
    public Slider volumenMusica;

    public Slider volumenSFX;

    public TextMeshProUGUI volumenMusicaText;

    public TextMeshProUGUI volumenSFX_Text;

    public InputField codigos;

    public string textoInput;

    GameObject canvasMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        instance = this;

        datosPersistentes = GameObject.Find("DatosPersistentes");

        canvasMenu = GameObject.Find("CanvasMenu");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        datosPersistentes.GetComponent<DatosPersistentes>().volumenMusica = volumenMusica.value;

        datosPersistentes.GetComponent<DatosPersistentes>().volumenSFX = volumenSFX.value;

        canvasMenu.GetComponent<SonidosMenu>().SFX_Prueba.volume = volumenSFX.value;

        canvasMenu.GetComponent<SonidosMenu>().Musica_Prueba.volume = volumenMusica.value;

        
        volumenMusicaText.text = $"{Mathf.CeilToInt(volumenMusica.GetComponent<Slider>().value *100)} %";

        volumenSFX_Text.text = $"{Mathf.CeilToInt(volumenSFX.GetComponent<Slider>().value *100)} %";

        textoInput = codigos.GetComponent<InputField>().text;

        datosPersistentes.GetComponent<DatosPersistentes>().textoInput = textoInput;

        Debug.Log($"InputField {textoInput}");
        

    }

}
