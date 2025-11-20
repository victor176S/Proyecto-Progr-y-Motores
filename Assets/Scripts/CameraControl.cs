using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public GameObject camara;

    public GameObject puntoEjemplo;

    [SerializeField] private float velocidad = 6f;

    public List<GameObject> puntosControl;

    public List<Transform> puntosControlTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //scroll de camara ahh bloque
       Vector3 moveCam = new Vector3 (0,0,0);

       moveCam.x = + 2f;

       camara.gameObject.transform.position += moveCam * velocidad * Time.deltaTime;
        
        

    }

    private void OnCollisionExit2D(Collision2D other)
    {
       
        /*if (other.gameObject.CompareTag("Player") && )
        {
            
        }*/
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        /*var v = rb.linearVelocity;
        if (other.gameObject.CompareTag("Suelo") && v.y < 1)
        {
            enSuelo = true;
        }*/
    }
}
