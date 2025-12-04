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

    public bool activateTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        instance =this;
    }
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {

        
       
    }

    void FixedUpdate()
    {

        DetectarTecla();

        if (player.gameObject.GetComponent<PlayerMovement>().enSuelo == true && tiempoCooldownDash <= 0f)
        {
                puedeDashear = true;
        }

        if (timerDashDuracion <= 0)
        {
            dashEnCurso = false;
        }

        if (tiempoCooldownDash > 0f)
        {
            tiempoCooldownDash -= Time.deltaTime;
        }

        if (botonDashPresionado && tiempoCooldownDash <= 0f)
        {
            StartCoroutine(DashLogic());
        }

        if (activateTimer && timerDashDuracion > 0f)
        {
            timerDashDuracion -= Time.deltaTime;
        }

        if (!dashEnCurso)
        {
            timerDashDuracion = 0.7f;
        }
        
    }

    public IEnumerator DashLogic()
    {
        

            if (timerDashDuracion > 0.01f)
                {
                    dashEnCurso = true;
                }



            if (tiempoCooldownDash <= 0f)
            {

            Debug.Log("Entrada al if de gravedad");
            //player.gameObject.GetComponent<PlayerMovement>().rb.gravityScale = 0;

            //congela la rotacion y la posicion en Y

                while (timerDashDuracion >= 0f)
                    {

                    activateTimer = true;
                    

                    player.gameObject.GetComponent<PlayerMovement>().rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                    player.gameObject.GetComponent<PlayerMovement>().rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            
                    player.gameObject.GetComponent<PlayerMovement>().velocidadMovimiento = 40f;
                    AnimationsPlayer.instance.animator.SetTrigger("Dashear");
                    yield return new WaitForSeconds(0.01f);

                    }

                    puedeDashear = false;
                    tiempoCooldownDash = 1f;
                    timerDashDuracion = 0.7f;
                    botonDashPresionado = false;



                }
            
        

        if (timerDashDuracion <= 0.3f)
        {   
            player.gameObject.GetComponent<PlayerMovement>().rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        yield return new WaitForSeconds(0.01f);

    }

    

    void DetectarTecla()
    {
        if (puedeDashear)
        {
            // Detectar si se presiona la tecla "flecha arriba"
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

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
