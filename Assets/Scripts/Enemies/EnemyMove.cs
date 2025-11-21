using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    [Header("Scroll automático en X")]
    [SerializeField] private float speedX = 2f;   // velocidad del scroll
    public bool scrollActivo = false;             // por si quieres activarlo/desactivarlo
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        // X: auto-scroll si está activo
        
  
            pos.x += speedX * Time.deltaTime;

    }
}
