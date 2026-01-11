using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEventTrigger : MonoBehaviour
{

    public static CameraEventTrigger instance;

    public List<GameObject> puntosDeControl;

    private int i;

    private GameObject camara;

    private bool autoScroll;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camara = GameObject.Find("Main Camera");
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

                camara.GetComponent<CameraAutoScroll2D>().scrollActivo = false;

                camara.GetComponent<CameraAutoScroll2D>().enabled = false;
                
                StartCoroutine(MoverCamaraY(100));



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

    IEnumerator MoverCamaraY(float cantidad)
    {
        for (int i = 0; i < cantidad * 15; i++)
        {
            yield return new WaitForSeconds(0.02f);

            camara.transform.position -= new Vector3 (0, 0.075f, 0);
        }

        camara.GetComponent<CameraAutoScroll2D>().enabled = true;
    }
}
