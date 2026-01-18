using System.Collections;
using UnityEngine;

public class IgnoreCollisionAfterCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if ((collision.transform.CompareTag("Suelo") || collision.transform.CompareTag("Enemy")) && gameObject.name.Contains("CristalRebote"))
        {
            StartCoroutine(QuitarColliderCristal());

            gameObject.GetComponent<DamageToPlayer>().enCaida = false;
        }

        if ((collision.transform.CompareTag("Suelo") || collision.transform.CompareTag("Enemy")) && !gameObject.name.Contains("CristalRebote"))
        {
            StartCoroutine(QuitarOtrosColliders());

            gameObject.GetComponent<DamageToPlayer>().enCaida = false;
        }
        
    }

    IEnumerator QuitarColliderCristal()
    {
        yield return new WaitForSeconds(0.2f);

        gameObject.GetComponent<CircleCollider2D>().enabled = false;

        gameObject.GetComponent<SpriteRenderer>().sortingOrder = -10;
    }

    IEnumerator QuitarOtrosColliders()
    {
        yield return new WaitForSeconds(0.2f);

         gameObject.GetComponent<BoxCollider2D>().enabled = false;

         gameObject.GetComponent<SpriteRenderer>().sortingOrder = -10;
    }
}
