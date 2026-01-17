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
        
        if (collision.transform.CompareTag("Suelo") && gameObject.name == "CristalRebote")
        {
            StartCoroutine(QuitarColliderCristal());
        }

        if (collision.transform.CompareTag("Suelo") && gameObject.name != "CristalRebote")
        {
            StartCoroutine(QuitarOtrosColliders());
        }
        
    }

    IEnumerator QuitarColliderCristal()
    {
        yield return new WaitForSeconds(6f);

        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }

    IEnumerator QuitarOtrosColliders()
    {
        yield return new WaitForSeconds(6f);

         gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
