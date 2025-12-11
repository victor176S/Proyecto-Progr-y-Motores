using UnityEngine;

public class AnimacionesMegafono : MonoBehaviour
{

    public Animator animator;    

    public bool activeAnim; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       animator.SetBool("Animacion", activeAnim); 
    }
}
