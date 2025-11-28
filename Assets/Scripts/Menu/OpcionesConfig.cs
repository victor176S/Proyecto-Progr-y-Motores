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

    public GameObject codigos;

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
        
        volumenMusicaText.text = $"{Mathf.CeilToInt(volumenMusica.GetComponent<Slider>().value *100)} %";

        volumenSFX_Text.text = $"{Mathf.CeilToInt(volumenSFX.GetComponent<Slider>().value *100)} %";

        if(codigos.GetComponent<TextMeshProUGUI>().text != null)
        {
            Debug.Log(codigos.GetComponent<TextMeshProUGUI>().text);
        }

        

    }


}
