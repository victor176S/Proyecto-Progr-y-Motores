using UnityEngine;

public class CameraAutoScroll2D : MonoBehaviour
{

    public static CameraAutoScroll2D instance;

    [Header("Jugador a seguir en Y")]
    [SerializeField] private Transform player;
    [SerializeField] private float yOffset = 0f;

    [Header("Scroll automático en X")]
    [SerializeField] private float speedX = 2f;   // velocidad del scroll
    public bool scrollActivo = true;             // por si quieres activarlo/desactivarlo

    // Para suavizar la Y (opcional)
    [SerializeField] private float smoothTimeY = 0.1f;
    private float velY;

    [Header("Jugador a seguir en Y")]

    public GameObject puntoDeControl;

    //"instance = this" en awake me deja usar valores de este script en otros
    private void Awake()
    {
        instance = this;
    }


    private void LateUpdate()
    {
        Vector3 pos = transform.position;

        // X: auto-scroll si está activo
        if (scrollActivo)
        {
            pos.x += speedX * Time.deltaTime;
        }

        // Y: sigue al jugador
        if (player != null)
        {
            float targetY = player.position.y + CameraMovement.instance.camYextra + yOffset;
            pos.y = Mathf.SmoothDamp(pos.y, targetY, ref velY, smoothTimeY);
        }

        // Z lo dejamos como esté (normalmente -10)
        transform.position = pos;
    }
}