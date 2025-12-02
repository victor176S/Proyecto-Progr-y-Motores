using UnityEngine;

public class AnimationsPlayer : MonoBehaviour
{

    public static AnimationsPlayer instance;

    public Animator animator;

    private bool cargandoSalto;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (PlayerMovement.instance.botonSaltoMantenido && PlayerMovement.instance.enSuelo)
        {
            cargandoSalto = true;
        }

        else
        {
            cargandoSalto = false;
        }

        animator.SetFloat("X", GameManager.instance.player.GetComponent<PlayerMovement>().rb.linearVelocityX);

        animator.SetFloat("Y", GameManager.instance.player.GetComponent<PlayerMovement>().rb.linearVelocityY);

        animator.SetTrigger("Saltar");

        animator.SetBool("enSuelo", PlayerMovement.instance.enSuelo);

        animator.SetBool("OnDash", PlayerDash.instance.dashEnCurso);

        animator.SetBool("CargandoSalto", cargandoSalto);
        
    }
}
