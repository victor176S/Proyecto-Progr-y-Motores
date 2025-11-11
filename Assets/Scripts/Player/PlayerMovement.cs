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

    [Header("Salto")] [SerializeField] private float fuerzaSalto = 7f;

    public bool enSuelo = true;

    public UnityEvent OnHold;
    bool OnPressed;
    public float y;

    public float tiempo;


    [Header("Sonidos")] [SerializeField] private AudioSource sonidoSalto;
    [SerializeField] private AudioSource sonidoAndar;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        if (valor.isPressed)
        {

            fuerzaSalto += tiempo;
        }

        tiempo = 0f;

        if (!enSuelo)
            return;


        var v = rb.linearVelocity;
        v.y = 0f;
        rb.linearVelocity = v;

        

        rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);

        tiempo = 0f;
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
    }

    public void OnPointerDown( PointerEventData eventData )
    {
        OnPressed = true;
    }

    public void OnPointerUp( PointerEventData eventData )
    {
        OnPressed = false;
    }
}
