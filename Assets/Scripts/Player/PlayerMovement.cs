using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")] [SerializeField]
    private float velocidadMovimiento = 6f;

    private Vector2 entradaMovimiento;

    public Rigidbody2D rb;

    private SpriteRenderer sprite;

    public bool mirandoDerecha = true;

    [Header("Salto")][SerializeField] private float fuerzaSalto = 7f;

    private float fuerzaSaltoOriginal;

    public bool enSuelo = true;

    public UnityEvent OnHold;
    public float y;

    public float tiempo;

    public bool botonSaltoPresionado;

    public bool comesFromJumping;

    [Header("Sonidos")] [SerializeField] private AudioSource sonidoSalto;
    [SerializeField] private AudioSource sonidoAndar;
    private bool botonSaltoMantenido;


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

            comesFromJumping = true;
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
    }

    // Update is called once per frame
    void Update()
    {

        DetectarTecla();
        
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
            tiempo += Time.deltaTime;

            fuerzaSalto += (tiempo / 60);
        }

        else
        {
            tiempo = 0f;
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
