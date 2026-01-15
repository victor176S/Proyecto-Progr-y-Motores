using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraEventTrigger : MonoBehaviour
{

    public static CameraEventTrigger instance;

    public List<GameObject> puntosDeControl;

    private int i;

    private GameObject camara;

    private bool autoScroll;

    private GameObject player;

    private GameObject canvasMegafono;

    private GameObject spawners;

    [Header("Jugador")]

    private bool enCaida;

    [SerializeField] private float speedY = -18f;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camara = GameObject.Find("Main Camera");

        player = GameObject.Find("Player");

        canvasMegafono = GameObject.Find("CanvasMegafono");

        spawners = canvasMegafono.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        

        if(enCaida)
        {

            Debug.Log("Jugador en caida");
        
                Vector3 pos = player.transform.position;

                pos.y += speedY * Time.deltaTime;

                player.transform.position = pos;

                if (PlayerMovement.instance.enSuelo)
                {
                    PlayerMovement.instance.rb.linearVelocity = Vector2.zero;
                    PlayerMovement.instance.rb.gravityScale = 4f;

                    enCaida = false;
                }

        }
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
         var nombreEscena = SceneManager.GetActiveScene().name;

        if (nombreEscena == "Nivel 1")
        {
            switch (i)
            {

            case 0:

                camara.GetComponent<CameraAutoScroll2D>().scrollActivo = false;

                camara.GetComponent<CameraAutoScroll2D>().enabled = false;

                camara.transform.position = new Vector3 (camara.transform.position.x, -545, camara.transform.position.z);
                
                StartCoroutine(MoverCamaraY(90, 1, 0));

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
        
        if (nombreEscena == "Nivel 2")
        {
            switch (i)
            {

            case 0:

                camara.GetComponent<CameraAutoScroll2D>().scrollActivo = false;

                camara.GetComponent<CameraAutoScroll2D>().enabled = false;
                
                StartCoroutine(MoverCamaraY(20, 1.5f, 0));

                puntosDeControl[i].gameObject.SetActive(false);

                break;

            case 1:

                camara.GetComponent<CameraAutoScroll2D>().scrollActivo = false;

                camara.GetComponent<CameraAutoScroll2D>().enabled = false;
                
                StartCoroutine(MoverCamaraY(40, -1.5f, 0));

                puntosDeControl[i].gameObject.SetActive(false);

                break;

            case 2:

                camara.GetComponent<CameraAutoScroll2D>().scrollActivo = false;

                camara.GetComponent<CameraAutoScroll2D>().enabled = false;
                
                StartCoroutine(MoverCamaraY(40, -1.5f, 0));

                puntosDeControl[i].gameObject.SetActive(false);

                break;

            case 3:

                    StartCoroutine(StartPlatformFall());

                    StartCoroutine(StartFall());

                    break;

            case 4:

                    StartCoroutine(InstantiateInFall(0, 0));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;
                
            case 5:

                    StartCoroutine(InstantiateInFall(1, 2));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

            case 6:

                    StartCoroutine(InstantiateInFall(0, 2));

                    StartCoroutine(InstantiateInFall(1, 3));

                    StartCoroutine(InstantiateInFall(1, 4));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

            case 7:

                    StartCoroutine(InstantiateInFall(0, 0));

                    StartCoroutine(InstantiateInFall(1, 1));

                    StartCoroutine(InstantiateInFall(0, 2));

                    puntosDeControl[i].gameObject.SetActive(false);

                    break;

            case 8:

                    break;

            case 9:

                    break;

            case 10:

                    break;

            case 11:

                    break;
            }

            

        } 

    IEnumerator MoverCamaraY(float cantidad, float multiplicador, float retardo)
    {
        for (int i = 0; i < cantidad * 15; i++)
        {
            yield return new WaitForSecondsRealtime(0.018f);

            camara.transform.position -= new Vector3 (0, 0.055f * multiplicador, 0);
        }

        yield return new WaitForSeconds(retardo);

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

    IEnumerator InstantiateInFall(int objeto, int lugar)
    {
        
        if (objeto == 0)
            {

                var caja = GameObject.Find("cajadamage");
                
                var caja1 = Instantiate(caja, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90) + new Vector3(0, 5, 0), quaternion.identity);

                var caja2 = Instantiate(caja, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90) + new Vector3(3, 5, 0), quaternion.identity);

                var caja3 = Instantiate(caja, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90) + new Vector3(-3, 5, 0), quaternion.identity);

                var caja4 = Instantiate(caja, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90) + new Vector3(3, 0, 0), quaternion.identity);

                var caja5 = Instantiate(caja, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90) + new Vector3(-3, 0, 0), quaternion.identity);

                caja1.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

                caja2.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

                caja3.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

                caja4.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

                caja5.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

                switch (lugar)
                {
                case 0:

                    StartCoroutine(WarningsAnimation.instance.WarningAnimationUP(true, false, false, false, false));

                    break;

                case 1:

                    StartCoroutine(WarningsAnimation.instance.WarningAnimationUP(false, true, false, false, false));

                    break;

                case 2:

                    StartCoroutine(WarningsAnimation.instance.WarningAnimationUP(false, false, true, false, false));

                    break;

                case 3:

                    StartCoroutine(WarningsAnimation.instance.WarningAnimationUP(false, false, false, true, false));

                    break;

                case 4:

                    StartCoroutine(WarningsAnimation.instance.WarningAnimationUP(false, false, false, false, true));

                    break;
                }

                

                yield return new WaitForSeconds (10f);

                Destroy(caja1);

                Destroy(caja2);

                Destroy(caja3);

                Destroy(caja4);

                Destroy(caja5);

            }
        
        if (objeto == 1)
            {
                var vigas = GameObject.Find("Vigas");
                
                var vigas1 = Instantiate(vigas, spawners.transform.GetChild(lugar).transform.position - new Vector3 (0,0,90), quaternion.identity);

                vigas1.GetComponent<Rigidbody2D>().AddTorque(20, ForceMode2D.Impulse);

                switch (lugar)
                {
                case 0:

                    StartCoroutine(WarningsAnimation.instance.WarningAnimationUP(true, false, false, false, false));

                    break;

                case 1:

                    StartCoroutine(WarningsAnimation.instance.WarningAnimationUP(false, true, false, false, false));

                    break;

                case 2:

                    StartCoroutine(WarningsAnimation.instance.WarningAnimationUP(false, false, true, false, false));

                    break;

                case 3:

                    StartCoroutine(WarningsAnimation.instance.WarningAnimationUP(false, false, false, true, false));

                    break;

                case 4:

                    StartCoroutine(WarningsAnimation.instance.WarningAnimationUP(false, false, false, false, true));

                    break;
                }

                yield return new WaitForSeconds (10f);

                Destroy(vigas1);
            }

        if (objeto == 2)
            {
                
            }
    }

    IEnumerator StartFall()
    {

        yield return new WaitForSeconds(1f);

            player.GetComponent<PlayerMovement>().enSuelo = false;

            AnimationsPlayer.instance.animator.SetTrigger("CaidaInesperada");

                //StartCoroutine(AnimationsPlayer.instance.TriggerRecompostura());

            CameraMovement.instance.Movement(2);
                //ESTO SI CAMBIA LA GRAVEDAD

            PlayerMovement.instance.rb.linearVelocity = Vector2.zero;
            PlayerMovement.instance.rb.gravityScale = 0f;
            PlayerMovement.instance.rb.constraints = RigidbodyConstraints2D.FreezePositionY;

            Debug.Log($"Gravedad: {PlayerMovement.instance.rb.gravityScale}");

            CameraRotation.instance.tiltAnimation = true;

            enCaida = true;

            StartCoroutine(ArrowsAnim.instance.TopToBottomArrowsAnim());

            StartCoroutine(Sounds.instance.PlaySound(0,2)); 

            puntosDeControl[i].gameObject.SetActive(false);

            


            
        }
    
        IEnumerator StartPlatformFall()
        {
            int rotation = 4;

            camara.GetComponent<CameraAutoScroll2D>().scrollActivo = false;

            var platformFall = GameObject.Find("PlatformFall");

            for (int i = 0; i < 800; i++)
            {
                platformFall.gameObject.transform.position -= new Vector3 (0, 5, 0);

                platformFall.gameObject.transform.rotation = Quaternion.Euler (0, 0, rotation);

                rotation += 4;

                yield return new WaitForSecondsRealtime(0.1f);
            }
        }

    }
}
