using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using MadeYellow.InputBuffer.Abstractions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{   

    public GameManager gameManager;

    public static PlayerMovement instance;


    //variables salto
    [Header("Salto")][SerializeField] private float fuerzaSalto = 28f;
    private float fuerzaSaltoOriginal;
    public float tiempoSalto;
    public bool comesFromJumping;
    public float porcentajesalto = 0f;
    public bool enSuelo = false;
    public bool maxJumpCapacity;
    float fuerzaSaltoMaxima = 60f;


    [Header("Movimiento")] [SerializeField]
    public float velocidadMovimiento = 18f;
    public float velocidadMovimientoOriginal = 18f;
    public float y;

    [Header("Rigidbody")]
    public Rigidbody2D rb;

    [Header("Input System")]
    private bool botonSaltoMantenido;
    private Vector2 entradaMovimiento;
    public UnityEvent OnHold;
    public bool botonSaltoPresionado;

    public bool inputBuffer;

    public float inputBufferCooldown = 0.3f;



    [Header("Sprite")]
    private SpriteRenderer sprite;
    public bool mirandoDerecha = true;

    [Header("Valores de tiempo")]
    public float tiempo;


    [Header("Sonidos")] 
    [SerializeField] private AudioSource sonidoSalto;
    [SerializeField] private AudioSource sonidoAndar;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;

    }

    void Start()
    {

        GameObject datosObject = GameObject.Find("GameManager");

        gameManager = datosObject.GetComponent<GameManager>();

        RestaurarPosicion();

        if (enSuelo)
        {
            fuerzaSaltoOriginal = fuerzaSalto;
        }
        rb = GetComponent<Rigidbody2D>();
        if (!sprite)
            sprite = GetComponent<SpriteRenderer>();
    }

    private void RestaurarPosicion()
    {
        GameData datosLeidos = gameManager.CargarDatosJuego();

        rb.linearVelocity = Vector2.zero;

        rb.MovePosition(new Vector3(datosLeidos.x, datosLeidos.y));
    }


    public bool EnSuelo()
    {
        return enSuelo;
    }

    public void OnJump(InputValue valor)
    {

        inputBuffer = true;

        Invoke("QuitarBuffer", inputBufferCooldown);

        comesFromJumping = true;

            if (!enSuelo)
                return;

            var v = rb.linearVelocity;
            v.y = 0f;
            rb.linearVelocity = v;
        rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        
    }

    public void QuitarBuffer()
    {
        inputBuffer = false;
    }
    

    public void OnMove(InputValue valor)
    {
        entradaMovimiento = valor.Get<Vector2>();
        if (entradaMovimiento.x > 0 && !mirandoDerecha)
            Girar(false);
        else if (entradaMovimiento.x < 0 && mirandoDerecha)
            Girar(true);

            
    }

    private void GuardarPosicion()
    {
        GameData datosAGuardar = new GameData();

        datosAGuardar.x = rb.position.x;

        datosAGuardar.y = rb.position.y;

        gameManager.GuardarDatos(datosAGuardar);
    }

    private void OnDestroy()
    {

        GuardarPosicion();
        
    }


    private void FixedUpdate()
    {

        var v = rb.linearVelocity;
        v.x = entradaMovimiento.x * velocidadMovimiento;
        rb.linearVelocity = v;

        if (botonSaltoMantenido && enSuelo && fuerzaSalto < fuerzaSaltoMaxima)
        {
            velocidadMovimiento = velocidadMovimiento /1.02f;

            porcentajesalto = (fuerzaSalto / fuerzaSaltoMaxima) * 100;

            if (porcentajesalto >= 99f)
            {
                porcentajesalto = 100f;
            }

        }

        else
        {

            if (fuerzaSalto >= fuerzaSaltoMaxima)
            {
                
            }
            else
            {
                velocidadMovimiento = velocidadMovimientoOriginal;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        DetectarTecla();
        
    }

    IEnumerator EsperarSegundos(float segundos)
    {
        yield return new WaitForSeconds(segundos);
    }

    void DetectarTecla()
    {
        {
            // Detectar si se presiona la tecla "flecha arriba"
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                botonSaltoPresionado = true;
                botonSaltoMantenido = true;

                Debug.Log($"Pulsado = {botonSaltoPresionado}");
                // Aquí puedes agregar la lógica que deseas ejecutar
            }
            else
            {

                botonSaltoPresionado = false;
                Debug.Log($"Pulsado = {botonSaltoPresionado}");

            }


            // Detectar si se mantiene presionada la tecla "E"
            if (Input.GetKey(KeyCode.UpArrow))
            {
                botonSaltoMantenido = true;

                Debug.Log($"Mantenido = {botonSaltoMantenido}");
            }

            else
            {

                botonSaltoMantenido = false;
                Debug.Log($"Mantenido = {botonSaltoMantenido}");

            }
        }

        
            if (botonSaltoMantenido == true && !comesFromJumping)
            {
                    tiempoSalto += Time.deltaTime;

                    fuerzaSalto += (tiempoSalto / 15);

                    if (fuerzaSalto >= fuerzaSaltoMaxima)
                    {
                        fuerzaSalto = fuerzaSaltoMaxima;

                    }

            }

            else
            {
                    tiempoSalto = 0f;
                    fuerzaSalto = fuerzaSaltoOriginal;
                    porcentajesalto = 0f;
            }
        }

    

            


    private void Girar(bool aIzquierda)
    {
        mirandoDerecha = !mirandoDerecha;
        if (sprite)
            sprite.flipX = aIzquierda;
    }

    private void OnCollisionExit2D(Collision2D other)
    {

        //arreglo de bug salto infinito al chocar con paredes con el dash
        var v = rb.linearVelocity;
        if (other.gameObject.CompareTag("Suelo") && v.y > 1 || other.gameObject.CompareTag("Suelo") && v.x > 1)
        {
            enSuelo = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        

        //arreglo de bug salto infinito al chocar con paredes con el dash
        var v = rb.linearVelocity;
        if (other.gameObject.CompareTag("Suelo") && v.y < 1 || other.gameObject.CompareTag("Suelo") && v.x < 1)
        {

            //input buffer jump logicdd
            if (inputBuffer)
            {
                rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            }
            enSuelo = true; 
        }

        comesFromJumping = false;

        if (other.gameObject.CompareTag("Enemy"))
        {
            for(int i = 0; i < 20; i++)
            {
                
            }
            

        }
        
    }

    public void EnemyBumpOnHit()
    {
        gameObject.transform.position += 2f * Vector3.right;

        gameObject.transform.position += 0.05f * Vector3.up;
    }
}
