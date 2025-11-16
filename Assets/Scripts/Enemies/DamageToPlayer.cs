using System.Collections;
using System.Net;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{
    public static DamageToPlayer instance;
    public float hurtCoolDownTimer =0f;

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
}
