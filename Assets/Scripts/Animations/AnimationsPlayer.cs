using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsPlayer : MonoBehaviour
{

    public static AnimationsPlayer instance;

    public Animator animator;

    private bool cargandoSalto;

    GameObject gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        instance = this;
        
        gameManager = GameObject.Find("GameManager");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (this.gameObject.GetComponent<PlayerMovement>().botonSaltoMantenido && this.gameObject.GetComponent<PlayerMovement>().enSuelo)
        {
            cargandoSalto = true;
            if (this.gameObject.GetComponent<PlayerMovement>().velocidadMovimientoActual > 0 || this.gameObject.GetComponent<PlayerMovement>().velocidadMovimientoActual < 0)
            {
                animator.SetTrigger("CargarSaltoAndar");
            }
            else
            {
                animator.SetTrigger("CargarSaltoQuieto");
            }
        }

        else
        {
            cargandoSalto = false;
        }

        animator.SetFloat("X", gameManager.GetComponent<GameManager>().player.GetComponent<PlayerMovement>().rb.linearVelocityX);

        animator.SetFloat("Y", gameManager.GetComponent<GameManager>().player.GetComponent<PlayerMovement>().rb.linearVelocityY);

        animator.SetTrigger("Saltar");

        animator.SetBool("enSuelo", this.gameObject.GetComponent<PlayerMovement>().enSuelo);

        animator.SetBool("OnDash", this.gameObject.GetComponent<PlayerDash>().dashEnCurso);

        animator.SetBool("CargandoSalto", cargandoSalto);

        animator.SetTrigger("Still");
        
    }

    public IEnumerator TriggerRecompostura()
    {

        yield return new WaitForSeconds(5f);

        animator.SetTrigger("Recompostura");

    }
}
