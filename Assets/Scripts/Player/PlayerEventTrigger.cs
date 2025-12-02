using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEventTrigger : MonoBehaviour
{
   public static PlayerEventTrigger instance;

    public List<GameObject> puntosDeControl;

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
        switch (i)
        {

            case 0:

                AnimationsPlayer.instance.animator.SetTrigger("CaidaGrande");

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
                    StartCoroutine(CameraShake.instance.ShakeLogic());

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

            default:

            break;
        }

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
