using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormFall : MonoBehaviour
{

    public float rotation = 4;

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
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlataformaCae());
        }
    }

    IEnumerator PlataformaCae()
    {
        for (int i = 0; i < 500; i++)
        {
            gameObject.transform.position -= new Vector3 (0, 2, 0);

            gameObject.transform.rotation = Quaternion.Euler (0, 0, rotation);

            rotation += 4;

            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
    
}
