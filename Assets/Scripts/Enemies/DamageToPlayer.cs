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



    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

                if (gameObject.CompareTag("Pincho"))
                {
                    Debug.Log("entra a el if del tag");

                    StartCoroutine(Sounds.instance.PlaySound(3,1));

                    other.gameObject.GetComponent<PlayerMovement>().jugadorPinchado = true;
                    
                    StartCoroutine(QuitarJugadorPinchado(other.gameObject));
                }

                else
                {
                    StartCoroutine(Sounds.instance.PlaySound(2,1));
                }
 
                StartCoroutine(PlayerImpulseOnHurt());

                AnimationsPlayer.instance.animator.SetTrigger("HurtToFall");


                
            }

            if (hurtCoolDownTimer <= 0f && fallingObject)
            {
                
                if (enCaida)
                {

                    StartCoroutine(HurtPlayer());

                    StartCoroutine(Sounds.instance.PlaySound(2,1));

                    var gameManager = GameObject.Find("GameManager");

                    if (gameManager.GetComponent<GameManager>().vidasJugador == 0)
                    {
                        SceneManager.LoadScene("EscenaMuerte2");
                    }  

                    Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), PlayerEventTrigger.instance.GetComponent<Collider>()); 

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
        GameManager.instance.DecreasePlayerLives();
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
        AnimationsPlayer.instance.animator.SetBool("Hurted", true);
        AnimationsPlayer.instance.animator.SetTrigger("CaidaInesperada");
        
        for (int i = 0; i <= (veces * 4); i++)
        {
            
            GameManager.instance.player.gameObject.transform.position += valorDeIncremento * Time.deltaTime * 50;

            PlayerMovement.instance.rb.linearVelocity = Vector2.zero;
            PlayerMovement.instance.rb.gravityScale = 0f;

            yield return new WaitForSeconds (0.001f);
        }

        PlayerMovement.instance.rb.linearVelocity = Vector2.zero;
        PlayerMovement.instance.rb.gravityScale = 4f;

        AnimationsPlayer.instance.animator.SetBool("Hurted", false);
        

        yield return new WaitForSeconds (0.001f);

    }
}
