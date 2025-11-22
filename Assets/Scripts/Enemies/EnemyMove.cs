using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public static EnemyMove instance;

    [Header("Scroll automático en X")]
    [SerializeField] private float speedX = 2f;

    [SerializeField] private bool scrollActivo = false;

    public bool cameraDependent = true;
    // velocidad del scroll

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (cameraDependent)
        {
            scrollActivo = CameraAutoScroll2D.instance.scrollActivo;
        }

        else
        {
            scrollActivo = false;
        }

        

        if (scrollActivo)
        {

        Vector3 pos = transform.position;

        pos.x += speedX * Time.deltaTime;

        transform.position = pos;

        }

    }
}
