using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Queue<KeyCode> inputBuffer;

    [Header("Movimiento")] [SerializeField]
    public float velocidadMovimiento = 12f;

    public float velocidadMovimientoOriginal = 12f;
    private Vector2 entradaMovimiento;

    public Rigidbody2D rb;

    private SpriteRenderer sprite;

    public bool mirandoDerecha = true;

    [Header("Salto")][SerializeField] private float fuerzaSalto = 28f;

    private float fuerzaSaltoOriginal;

    public bool enSuelo = true;

    public UnityEvent OnHold;
    public float y;

    public float tiempoSalto;

    public float tiempo;

    public bool botonSaltoPresionado;

    public bool comesFromJumping;

    private bool botonSaltoMantenido;
    public bool maxJumpCapacity;

    [Header("Sonidos")] [SerializeField] private AudioSource sonidoSalto;
    [SerializeField] private AudioSource sonidoAndar;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        if (enSuelo)
        {
            fuerzaSaltoOriginal = fuerzaSalto;
        }
        // rb = GetComponent<Rigidbody2D>();
        if (!sprite)
            sprite = GetComponent<SpriteRenderer>();
    }


    public bool EnSuelo()
    {
        return enSuelo;
    }

    public void OnJump(InputValue valor)
    {
        comesFromJumping = true;

            if (!enSuelo)
                return;

            
            var v = rb.linearVelocity;
            v.y = 0f;
            rb.linearVelocity = v;
        rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        
    }
        
    

    public void OnMove(InputValue valor)
    {
        entradaMovimiento = valor.Get<Vector2>();
        if (entradaMovimiento.x > 0 && !mirandoDerecha)
            Girar(false);
        else if (entradaMovimiento.x < 0 && mirandoDerecha)
            Girar(true);

            
    }


    private void FixedUpdate()
    {
        var v = rb.linearVelocity;
        v.x = entradaMovimiento.x * velocidadMovimiento;
        rb.linearVelocity = v;

        if (botonSaltoMantenido && enSuelo && fuerzaSalto < 60)
        {
            velocidadMovimiento = velocidadMovimiento /1.02f;
        }

        else
        {

            if (fuerzaSalto >= 60)
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

        if (comesFromJumping)
        {
            
        }
        
    }

    IEnumerator EsperarSegundos(float segundos)
    {
        yield return new WaitForSeconds(segundos);
    }

    void DetectarTecla()
    {
        {
            // Detectar si se presiona la tecla "E"
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

                    if (fuerzaSalto >= 60f)
                    {
                        fuerzaSalto = 60;

                    }

            }

            else
            {
                    tiempoSalto = 0f;
                    fuerzaSalto = fuerzaSaltoOriginal;
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

        
        var v = rb.linearVelocity;
        if (other.gameObject.CompareTag("Suelo") && v.y > 1)
        {
            enSuelo = false;
        }

        
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var v = rb.linearVelocity;
        if (other.gameObject.CompareTag("Suelo") && v.y < 1)
        {
            enSuelo = true;
        }

        comesFromJumping = false;
    }
}
