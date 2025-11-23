using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public bool usarDatosExternos = false;
    private string file;

    public GameData datosJuego = new GameData();

    public static GameManager instance;

    public int vidasJugador = 3;

    public RawImage corazon1, corazon2, corazon3;

    public TextMeshProUGUI porcentajeSaltoText;

    public GameObject player;

    public GameObject LivesUI;

    public TextMeshProUGUI DashCharge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {   //este bloque soluciona que una instancia no este asociada a un objeto al que se refiere,
        //en este caso como quiero llamar a una clase que cambia los valores de manera externa
        //(aunque el codigo del cambio esté en el mismo script) necesito usar esto aquí, yo que los cambios
        //en codigo los hago aqui
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

        Debug.Log($"Porcentaje salto: {player.gameObject.GetComponent<PlayerMovement>().porcentajesalto}%");
        porcentajeSaltoText.text = $"Porcentaje de fuerza de salto: {player.gameObject.GetComponent<PlayerMovement>().porcentajesalto}%";
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
