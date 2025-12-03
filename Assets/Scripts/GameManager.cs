using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{

    
    public bool usarDatosExternos = false;
    private string file;

    public GameData datosJuego = new GameData();

    public static GameManager instance;

    [Header("UI")]

    public int vidasJugador = 3;

    public RawImage corazon1, corazon2, corazon3;

    public TextMeshProUGUI porcentajeSaltoText;

    public GameObject LivesUI;

     public TextMeshProUGUI DashCharge;

     public GameObject TopToBottomArrows;

    public GameObject BottomToTopArrows;

    public GameObject LeftToRightArrows;

    public TextMeshProUGUI textoPuntos;

    public GameObject panelDerrota;

    public int puntos;

    public Canvas avisos;

    [Header("Objetos")]

    public GameObject camara;

    public GameObject player;

    [Header("Valores")]

    private bool haPerdido;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {   //este bloque soluciona que una instancia no este asociada a un objeto al que se refiere,
        //en este caso como quiero llamar a una clase que cambia los valores de manera externa
        //(aunque el codigo del cambio esté en el mismo script) necesito usar esto aquí, yo que los cambios
        //en codigo los hago aqui
        instance = this;

        DatosPersistentes.instance.fueraDelMenu = true;

    }

    void Start()
    {
        //modificar usarDatosExternos en este script más arriba en caso de que se quiera usar
        if (usarDatosExternos)
        {
        file = Application.persistentDataPath + "/Gamedata.json";
        }

        porcentajeSaltoText.text = "Porcentaje de fuerza de salto: 0%";

    }

    //estructura para guardar datos persistentes entre partidas
    public void GuardarDatos(GameData datosJuego)
    {

        if (file != null)
        {

        string json = JsonUtility.ToJson(datosJuego);

        File.WriteAllText(file,json);
        
        }
        
    }

    //estructura para cargar los datos guardados
    public GameData CargarDatosJuego()
    {
        
        if (File.Exists(file))
        {

            string contenido = File.ReadAllText(file);
            datosJuego = JsonUtility.FromJson<GameData>(contenido);
            
        }

        else
        {
            
            datosJuego.x=0;
            datosJuego.y=0;

        }

        return datosJuego;

    }

    public void DecreasePlayerLives()
    {
        vidasJugador--;
    }

    void FixedUpdate()
    {

        LogicVidas();
        
        SaltoText();
        
        DashText();
        
        PuntosText();

        if (vidasJugador == 0)
        {

            haPerdido = true;
            
        }

        if (haPerdido)
        {
            StartCoroutine(OnDeath(1));
        }

    }

    

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log($"Datos: {DatosPersistentes.instance.codigoLyrics}");

        Debug.Log($"Datos: {DatosPersistentes.instance.volumenMusica}");

        Debug.Log($"Datos: {DatosPersistentes.instance.volumenSFX}");

    }

    void LogicVidas()
    {
        Debug.Log($"Vidas jugador (Fixed update): {vidasJugador}");
        if (vidasJugador >= 3)
        {
            Debug.Log($"Vidas jugador (primer if): {vidasJugador}");
        }
        else if (vidasJugador == 2)
        {

            Debug.Log($"Vidas jugador (segundo if): {vidasJugador}");
            
            corazon1.gameObject.SetActive(false);

        }
        else if (vidasJugador == 1)
        {

            Debug.Log($"Vidas jugador: {vidasJugador}");
            corazon2.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log($"Vidas jugador: {vidasJugador}");
            corazon3.gameObject.SetActive(false);
        }
    }

    void SaltoText()
    {
        Debug.Log($"Porcentaje salto: {player.gameObject.GetComponent<PlayerMovement>().porcentajesalto}%");
        porcentajeSaltoText.text = $"Porcentaje de fuerza de salto: {player.gameObject.GetComponent<PlayerMovement>().porcentajesalto}%";
    }

    void DashText()
    {
       if (PlayerDash.instance.tiempoCooldownDash < 0f)
        {
            DashCharge.text = $"Dash disponible";
        }

        else
        {
            DashCharge.text = $"Dash cargandose";
        } 
    }

    void PuntosText()
    {

        Debug.Log(puntos);
        
        textoPuntos.text = $"Tienes {puntos} puntos";

    }

    IEnumerator OnDeath(int i)
    {
        switch (i)
        {

            case 0:

            

            yield return new WaitForSeconds(0.1f);

                break;

            case 1:

            panelDerrota.SetActive(true);

            yield return new WaitForSeconds(0.1f);

                break;

            case 2:

            SceneManager.LoadScene("Nivel 1");

                break;
        }

        
        

        
    }

    public void Reiniciar()
    {
       SceneManager.LoadScene("TestCamp"); 
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
