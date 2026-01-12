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

                camara.transform.position = new Vector3 (camara.transform.position.x, -545, camara.transform.position.z);
                
                StartCoroutine(MoverCamaraY(90));

                StartCoroutine(Shake1());

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
            yield return new WaitForSeconds(0.018f);

            camara.transform.position -= new Vector3 (0, 0.055f, 0);
        }

        camara.GetComponent<CameraAutoScroll2D>().enabled = true;

        camara.GetComponent<CameraAutoScroll2D>().scrollActivo = true;

        camara.GetComponent<CameraAutoScroll2D>().speedX = 13;

    }

    IEnumerator Shake1()
    {
        Debug.Log("entrada Shake1");

        yield return new WaitForSecondsRealtime(25f);

        Debug.Log("accion Shake1");
        
        StartCoroutine(camara.GetComponent<CameraShake>().ShakeLogic(15, 1, 0.02f));
    }
}
