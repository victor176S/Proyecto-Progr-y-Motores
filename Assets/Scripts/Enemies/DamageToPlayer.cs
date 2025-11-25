using System.Collections;
using System.Net;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{
    public static DamageToPlayer instance;
    public float hurtCoolDownTimer = 0f;

    public bool fallingObject = false;
    public Vector3 valorDeIncremento = new Vector3(0.2f, 0.1f, 0);

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
        if (other.collider.CompareTag("Player"))
        {

            Debug.Log("Colision con jugador confirmada");

            if (hurtCoolDownTimer <= 0f)

                StartCoroutine(HurtPlayer());

                if (!fallingObject)
                {
                    StartCoroutine(PlayerImpulseOnHurt());
                }
        }
    }

    private IEnumerator HurtPlayer()
    {   
        Debug.Log($"Hurt Cooldown Timer HurtPlayer (entrada): {hurtCoolDownTimer}");
        //esto falla
        GameManager.instance.DecreasePlayerLives();
        Debug.Log($"Hurt Cooldown Timer HurtPlayer (salida): {hurtCoolDownTimer}");
        hurtCoolDownTimer = 2f;
        yield return new WaitForSeconds(0.2f);
       
    }

    private IEnumerator PlayerImpulseOnHurt()
    {
        
        
        for (int i = 0; i <= (veces*5); i++)
        {
            
            GameManager.instance.player.gameObject.transform.position += valorDeIncremento * Time.deltaTime * 200;

            PlayerMovement.instance.rb.linearVelocity = Vector2.zero;
            PlayerMovement.instance.rb.gravityScale = 0f;

            yield return new WaitForSeconds (0.001f);
        }

        PlayerMovement.instance.rb.linearVelocity = Vector2.zero;
        PlayerMovement.instance.rb.gravityScale = 4f;

        yield return new WaitForSeconds (0.001f);

    }
}
