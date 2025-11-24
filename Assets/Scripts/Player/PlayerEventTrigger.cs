using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEventTrigger : MonoBehaviour
{
   public static PlayerEventTrigger instance;

    public List<GameObject> puntosDeControl;

    [SerializeField] private float speedY = -18f;

    private int i;

    private bool alreadyActivated = false;

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
            
                
                //ESTO SI CAMBIA LA GRAVEDAD

                PlayerMovement.instance.rb.linearVelocity = Vector2.zero;
                PlayerMovement.instance.rb.gravityScale = 0f;

                Debug.Log($"Gravedad: {PlayerMovement.instance.rb.gravityScale}");

                CameraRotation.instance.tiltAnimation = true;

                enCaida = true;

                StartCoroutine(ArrowsAnim.instance.TopToBottomArrowsAnim());

                break;

            case 1:

                CameraRotation.instance.tiltAnimation = false;
                CameraRotation.instance.target = 0f;
                CameraRotation.instance.tiltToTheRight = true;

                break;

            case 2:

                if (!alreadyActivated)
                {
                    StartCoroutine(CameraShake.instance.ShakeLogic());
                    alreadyActivated = true;
                }
                
                break;

            case 3:

                StartCoroutine(PlatformMovement.instance.PlatformGoingUp());

                break;

            case 4:

                StartCoroutine(ReOrganizeUI.instance.UIFromRightToTop());
                StartCoroutine(ReOrganizeUI.instance.UIFromTopToLeft());
                StartCoroutine(ReOrganizeUI.instance.UIFromLeftToBottom());
                StartCoroutine(ReOrganizeUI.instance.UIFromBottomToRight());
                
                
                break;

            case 5:

                CameraAutoScroll2D.instance.scrollActivo = false;
                CameraMovement.instance.Movement(0);
                break;

            case 6:

                CameraMovement.instance.Movement(1);

                break;

            default:

            break;
        }

    } 
}
