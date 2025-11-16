using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int vidasJugador = 3;

    public RawImage corazon1, corazon2, corazon3;

    public TextMeshProUGUI porcentajeSaltoText;

    [SerializeField] public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        porcentajeSaltoText.text = "Porcentaje de fuerza de salto: 0%";

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
