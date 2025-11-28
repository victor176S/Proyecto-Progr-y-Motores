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

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }


}
