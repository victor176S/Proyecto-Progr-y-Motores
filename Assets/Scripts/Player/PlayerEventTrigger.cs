using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEventTrigger : MonoBehaviour
{

    public GameObject simpleDialogs;

    public static PlayerEventTrigger instance;

    public List<GameObject> puntosDeControl;

    private GameObject globalCanvas;

    [SerializeField] private float speedY = -18f;

    private int i;

    public bool enCaida = false;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        simpleDialogs = GameObject.Find("SimpleDialogs");

        globalCanvas = GameObject.Find("GlobalCanvas");
    }

    // Update is called once per frame
    void Update()
    {
            if(enCaida)
            {
        
                Vector3 pos = transform.position;

                pos.y += speedY * Time.deltaTime;

                transform.position = pos;

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

        if (other.gameObject.CompareTag("playerTrigger"))
        {
            Debug.Log("player colision");

            i = puntosDeControl.IndexOf(other.gameObject);

            TriggerPuntoDeControl(i);
        }
            
    }

    public void TriggerPuntoDeControl(int i)
    {

        var nombreEscena = SceneManager.GetActiveScene().name;

        Debug.Log($"Nombre escena: {nombreEscena}");

        if (nombreEscena == "Nivel 1")
        {

            switch (i)
            {

            case 0:

                AnimationsPlayer.instance.animator.SetTrigger("CaidaInesperada");

                StartCoroutine(AnimationsPlayer.instance.TriggerRecompostura());

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

                break;

            case 1:

                CameraRotation.instance.tiltAnimation = false;
                CameraRotation.instance.target = 0f;
                CameraRotation.instance.tiltToTheRight = true;
                puntosDeControl[i].gameObject.SetActive(false);

                break;

            case 2:

                
                    CameraMovement.instance.Movement(1);
                    StartCoroutine(CameraShake.instance.ShakeLogic(15, 1, 0.3f));
                    AnimationsPlayer.instance.animator.SetTrigger("Landing");

                    PlayerMovement.instance.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    puntosDeControl[i].gameObject.SetActive(false);
                    
                   
                
                
                break;

            case 3:

                StartCoroutine(PlatformMovement.instance.PlatformGoingUp());

                puntosDeControl[i].gameObject.SetActive(false);

                break;

            case 4:

                

                StartCoroutine(ReOrganizeUI.instance.UIFromRightToTop());

                puntosDeControl[i].gameObject.SetActive(false);

                
                break;

            case 5:

                CameraAutoScroll2D.instance.scrollActivo = false;
                CameraMovement.instance.Movement(0);

                puntosDeControl[i].gameObject.SetActive(false);
                break;

            case 6:

                CameraMovement.instance.Movement(1);

                puntosDeControl[i].gameObject.SetActive(false);

                break;

            case 7:

                Debug.Log("se activo el trigger del prefab");

                FallingObjectSpawn.instance.SpawnFallingGlass(0,8f);

                //avisos de objetos en caida de izq a derecha
                StartCoroutine(WarningsAnimation.instance.WarningAnimationUP(false, false, false, false, false));
                StartCoroutine(WarningsAnimation.instance.WarningAnimationUP(false, true, false, false, false));
                StartCoroutine(WarningsAnimation.instance.WarningAnimationUP(false, false, true, false, false));
                StartCoroutine(WarningsAnimation.instance.WarningAnimationUP(false, false, false, true, false));
                StartCoroutine(WarningsAnimation.instance.WarningAnimationUP(false, false, false, false, false));


                //StartCoroutine(DeleteFallingProp(objeto));

                break;

            case 8:

                SceneManager.LoadScene("EscenaMuerte");

                break;

            case 9:
                    
                    StartCoroutine(DialogosSimples("Por cierto, pueden haber algunos cristales desperdigados, intenta no tocarlos"));

                    break;

            case 10:

                SceneManager.LoadScene("EscenaMuerte");

                break;

            case 11:

                var camara = GameObject.Find("Main Camera");

                StartCoroutine(camara.GetComponent<CameraShake>().ShakeLogic(15, 1, 0.02f));

                break;

            case 12:

                puntosDeControl[13].gameObject.SetActive(false);

                var finalPosition = GameObject.Find("FinalPlace");

                var finalCanvas = GameObject.Find("SecondaryCanvasFinal");

                Debug.Log($"nombre del objeto {finalCanvas.gameObject.name}");

                gameObject.transform.position = finalPosition.transform.position;

                finalCanvas.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Image>().color += new Color (0,0,0,1);

                finalCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color += new Color (0,0,0,1);

                finalCanvas.transform.GetChild(0).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().color += new Color (0,0,0,1);

                finalCanvas.transform.GetChild(0).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().color += new Color (0,0,0,1);

                finalCanvas.transform.GetChild(0).GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().color += new Color (0,0,0,1);

                var gameManager = GameObject.Find("GameManager");

                var datosPersistentes = GameObject.Find("DatosPersistentes");

                datosPersistentes.GetComponent<DatosPersistentes>().puntos += gameManager.GetComponent<GameManager>().puntos;

                finalCanvas.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = datosPersistentes.GetComponent<DatosPersistentes>().puntos.ToString();
                
                StartCoroutine(LoadSceneLate());
                
                    break;

                case 13:

                    SceneManager.LoadScene("EscenaMuerteScroll");

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

                SceneManager.LoadScene("EscenaMuerte1");

                break;

            case 1:

                SceneManager.LoadScene("EscenaMuerte2");

                break;

            case 2:

                Debug.Log("entrada al control");

                    StartCoroutine(InstantiateFallingObjectNormalSection(0,0,0));
                    
                    break;

            case 3:
            
                    StartCoroutine(InstantiateFallingObjectNormalSection(1,0,1));

                    break;

            default:

                break;

            }
        }

        if (nombreEscena == "Nivel 3")
        {
            
        }

    } 

    IEnumerator InstantiateFallingObjectNormalSection(int hijo1, int hijo2, int objeto)
    {

        if (objeto == 0)
        {
            var caja = GameObject.Find("cajadamage");

            var posicionAparicion = globalCanvas.transform.GetChild(1).GetChild(hijo1).GetChild(hijo2).gameObject.transform.position;

            GameObject cajaInvocada = Instantiate(caja, posicionAparicion, quaternion.identity);

            cajaInvocada.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

            GameObject cajaInvocada1 = Instantiate(caja, posicionAparicion - new Vector3(3, 0, 0), quaternion.identity);

            cajaInvocada1.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

            GameObject cajaInvocada2 = Instantiate(caja, posicionAparicion - new Vector3(-3, 0, 0), quaternion.identity);

            cajaInvocada2.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

            GameObject cajaInvocada3 = Instantiate(caja, posicionAparicion - new Vector3(3, 3, 0), quaternion.identity);

            cajaInvocada3.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

            GameObject cajaInvocada4 = Instantiate(caja, posicionAparicion - new Vector3(-3, 3, 0), quaternion.identity);

            cajaInvocada4.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(1f);  

                if (cajaInvocada4.GetComponent<DamageToPlayer>().enCaida == false)
                globalCanvas.transform.GetChild(1).GetChild(hijo1).gameObject.SetActive(false);
            }

           

           
        }

        if (objeto == 1)
        {
            var vigas = GameObject.Find("Vigas");

            var posicionAparicion = globalCanvas.transform.GetChild(1).GetChild(hijo1).GetChild(hijo2).gameObject.transform.position;

            GameObject vigaInvocada = Instantiate(vigas, posicionAparicion, quaternion.identity);

            vigaInvocada.GetComponent<Rigidbody2D>().AddTorque(5, ForceMode2D.Impulse);

            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(1f);  

                if (vigaInvocada.GetComponent<DamageToPlayer>().enCaida == false)
                globalCanvas.transform.GetChild(1).GetChild(hijo1).gameObject.SetActive(false);
            }
        }
    }

    

    IEnumerator LoadSceneLate()
    {
        yield return new WaitForSecondsRealtime (18f);

        SceneManager.LoadScene("Nivel 2");
    }

    IEnumerator DialogosSimples(string dialogo)
    {

        simpleDialogs.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = dialogo;

        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.02f);

            simpleDialogs.gameObject.transform.position -= new Vector3(0,5,0);
        }

        yield return new WaitForSeconds (3f);

        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.02f);

            simpleDialogs.gameObject.transform.position += new Vector3(0,5,0);
        }

        simpleDialogs.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "";
    }


}

/*Para poner overloads a una funcion, hay que hacer la misma dos o más veces pero con diferentes cantidades
de parametros

    public void Funcion(int i, int j)
    {
        
    }
    
    public void Funcion(int i, int j, int k)
    {
        
    }

    */
