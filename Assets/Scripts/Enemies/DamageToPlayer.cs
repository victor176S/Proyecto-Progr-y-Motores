using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageToPlayer : MonoBehaviour
{
    public static DamageToPlayer instance;
    public float hurtCoolDownTimer = 0f;
    public bool enCaida = false;
    public bool fallingObject = false;
    public Vector3 valorDeIncremento = new Vector3(0.05f, 0.1f, 0);

    public int veces = 40;

    GameObject gameManager;

    GameObject player;



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        gameManager = GameObject.Find("GameManager");

        player = GameObject.Find("Player");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log($"Hurt Cooldown Timer FixedUpdate: {hurtCoolDownTimer}");
        if (hurtCoolDownTimer > 0f)
        {   
            hurtCoolDownTimer -= Time.fixedDeltaTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        Debug.Log($"Hurt Cooldown Timer Collision: {hurtCoolDownTimer}");
        Debug.Log("Colision con jugador");

        if (other.collider.CompareTag("Suelo") && enCaida && fallingObject)
        {
            enCaida = false;
        }

        if (other.collider.CompareTag("Player"))
        {

            Debug.Log("Colision con jugador confirmada");

            if (hurtCoolDownTimer <= 0f && !fallingObject)
            {
                StartCoroutine(HurtPlayer());

                if (this.gameObject.CompareTag("Pincho"))
                {
                    Debug.Log("entra a el if del tag");

                    StartCoroutine(player.GetComponent<Sounds>().PlaySound(3,1));

                    other.gameObject.GetComponent<PlayerMovement>().jugadorPinchado = true;
                    
                    StartCoroutine(QuitarJugadorPinchado(other.gameObject));
                }

                else
                {
                    StartCoroutine(player.GetComponent<Sounds>().PlaySound(2,1));

                    StartCoroutine(QuitarJugadorGolpeado(other.gameObject));
                }
 
                StartCoroutine(PlayerImpulseOnHurt());

                player.GetComponent<AnimationsPlayer>().animator.SetTrigger("HurtToFall");


                
            }

            if (hurtCoolDownTimer <= 0f && fallingObject)
            {
                
                if (enCaida)
                {

                    StartCoroutine(HurtPlayer());

                    StartCoroutine(player.GetComponent<Sounds>().PlaySound(2,1));

                    var gameManager = GameObject.Find("GameManager");

                    if (gameManager.GetComponent<GameManager>().vidasJugador == 0 && SceneManager.GetActiveScene().name == "Nivel 2")
                    {
                        SceneManager.LoadScene("EscenaMuerte2");
                    }

                    if (gameManager.GetComponent<GameManager>().vidasJugador == 0 && SceneManager.GetActiveScene().name == "Nivel 3")
                    {
                        SceneManager.LoadScene("EscenaMuerteGolpeado");
                    }  

                    Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), player.GetComponent<PlayerEventTrigger>().GetComponent<Collider>()); 

                }

            }

               
                
        }
    }

    private IEnumerator HurtPlayer()
    {   

        if (hurtCoolDownTimer <= 0)
        {

        Debug.Log($"Hurt Cooldown Timer HurtPlayer (entrada): {hurtCoolDownTimer}");
        //esto falla
        gameManager.GetComponent<GameManager>().DecreasePlayerLives();
        Debug.Log($"Hurt Cooldown Timer HurtPlayer (salida): {hurtCoolDownTimer}");
        hurtCoolDownTimer = 2f;
        
        yield return new WaitForSeconds(0.2f);

        }
    }

    private IEnumerator QuitarJugadorPinchado(GameObject other)
    {
        yield return new WaitForSeconds(0.5f);

        other.gameObject.GetComponent<PlayerMovement>().jugadorPinchado = false;
    }

    private IEnumerator QuitarJugadorGolpeado(GameObject other)
    {
        yield return new WaitForSeconds(0.5f);

        other.GetComponent<GameManager>().jugadorGolpeado = false;
    }

    private IEnumerator PlayerImpulseOnHurt()
    {
        player.GetComponent<AnimationsPlayer>().animator.SetBool("Hurted", true);
        player.GetComponent<AnimationsPlayer>().animator.SetTrigger("CaidaInesperada");
        
        for (int i = 0; i <= (veces * 4); i++)
        {
            
            gameManager.GetComponent<GameManager>().player.gameObject.transform.position += valorDeIncremento * Time.deltaTime * 50;

            player.GetComponent<PlayerMovement>().rb.linearVelocity = Vector2.zero;
            player.GetComponent<PlayerMovement>().rb.gravityScale = 0f;

            yield return new WaitForSeconds (0.001f);
        }

        player.GetComponent<PlayerMovement>().rb.linearVelocity = Vector2.zero;
        player.GetComponent<PlayerMovement>().rb.gravityScale = 4f;

        player.GetComponent<AnimationsPlayer>().animator.SetBool("Hurted", false);
        

        yield return new WaitForSeconds (0.001f);

    }
}
