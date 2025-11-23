using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEventTrigger : MonoBehaviour
{

    public static CameraEventTrigger instance;

    public List<GameObject> puntosDeControl;

    private int i;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //el objeto al que le afecta el trigger, tiene que tener un rigidbody
    //si quieres que su comportamiento original no cambie (en este caso, la camara)
    //pon gravedad 0 en el rigidbody
    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.CompareTag("cameraTrigger"))
        {
            Debug.Log("camara colision");

            i = puntosDeControl.IndexOf(other.gameObject);

            TriggerPuntoDeControl(i);
        }
            
    }

    public void TriggerPuntoDeControl(int i)
    { 
        switch (i)
        {

            case 0:

                CameraAutoScroll2D.instance.scrollActivo = false;
                
                break;

            case 1:

                //CameraRotation.instance.target = 0f;

                break;

            case 2:

                puntosDeControl[i].gameObject.SetActive(false);

                break;

            case 3:

                puntosDeControl[i].gameObject.SetActive(false);

                break;

            case 4:

                puntosDeControl[i].gameObject.SetActive(false);

                break;
            
            default:

            break;
        }

    } 
}
