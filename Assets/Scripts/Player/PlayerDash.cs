using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public static PlayerDash instance;
    public bool botonDashPresionado;

    public GameObject player;
    public bool botonDashMantenido;

    public bool dashEnCurso;

    public bool puedeDashear = false;

    public float timerDashDuracion = 0.7f;

    public float tiempoCooldownDash = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
       
        if (timerDashDuracion > 0f)
        {
            timerDashDuracion -= Time.deltaTime;
        }

    }

    void FixedUpdate()
    {


        DetectarTecla();

        if (tiempoCooldownDash > 0f)
        {
            tiempoCooldownDash -= Time.deltaTime;
        }

        if (tiempoCooldownDash <= 0f)
        {
            DashLogic();
        }
        
    }

    public void DashLogic()
    {

        Debug.Log($"Debug DashLogic {timerDashDuracion}, {tiempoCooldownDash}");

            if ((timerDashDuracion + tiempoCooldownDash) > 0f)
            {

            Debug.Log("Entrada al if de gravedad");
            //player.gameObject.GetComponent<PlayerMovement>().rb.gravityScale = 0;

            //congela la rotacion y la posicion en Y
            player.gameObject.GetComponent<PlayerMovement>().rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            player.gameObject.GetComponent<PlayerMovement>().rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            
            player.gameObject.GetComponent<PlayerMovement>().velocidadMovimiento += 24f;

            puedeDashear = false;

            }
            
        

        else
        {   
            player.gameObject.GetComponent<PlayerMovement>().rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (player.gameObject.GetComponent<PlayerMovement>().enSuelo == true && tiempoCooldownDash <= 0f)
            {
                puedeDashear = true;
            }
        }

        

    }

    

    void DetectarTecla()
    {
        if (puedeDashear)
        {
            // Detectar si se presiona la tecla "flecha arriba"
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                tiempoCooldownDash = 2f;

                botonDashPresionado = true;

                Debug.Log($"Dash Pulsado = {botonDashPresionado}");
                // Aquí puedes agregar la lógica que deseas ejecutar
            }

            else
            {
                botonDashPresionado = false;

                Debug.Log($"Dash Pulsado = {botonDashPresionado}");
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {

                botonDashMantenido = true;

                timerDashDuracion = 0.7f;

                Debug.Log($"Dash Pulsado = {botonDashPresionado}");
                // Aquí puedes agregar la lógica que deseas ejecutar
            }

            else
            {
                botonDashMantenido = false;

                Debug.Log($"Dash Pulsado = {botonDashPresionado}");
            }
        
        }
    }
}
