using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpcionesConfig : MonoBehaviour
{

    public static OpcionesConfig instance;

    public Slider volumenMusica;

    public Slider volumenSFX;

    public TextMeshProUGUI volumenMusicaText;

    public TextMeshProUGUI volumenSFX_Text;

    public InputField codigos;

    public string textoInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        DatosPersistentes.instance.volumenMusica = volumenMusica.value;

        DatosPersistentes.instance.volumenSFX = volumenSFX.value;

        SonidosMenu.instance.SFX_Prueba.volume = volumenSFX.value;

        SonidosMenu.instance.Musica_Prueba.volume = volumenMusica.value;

        
        volumenMusicaText.text = $"{Mathf.CeilToInt(volumenMusica.GetComponent<Slider>().value *100)} %";

        volumenSFX_Text.text = $"{Mathf.CeilToInt(volumenSFX.GetComponent<Slider>().value *100)} %";

        textoInput = codigos.GetComponent<InputField>().text;

        Debug.Log(textoInput);
        

    }

}
