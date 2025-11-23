using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;

public class CameraShake : MonoBehaviour
{
    public GameObject cameraObject; // set this via inspector

    public int timesShake = 15;
    public float duration = 0.2f;
    public float magnitude = 1f;

    public float shakeSpeed = 0.02f; //cuanto más pequeño, más rapidos son los cambios de posicion

    public float shakeX;

    public float shakeY;

    public static CameraShake instance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

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
        
        
    }

    public IEnumerator ShakeLogic()
    {
        
        for (int i = 0; i <= timesShake; i++)
        {

            Debug.Log("Shake: esto deberia echar mensajes por un segundo");

            shakeX = Random.Range(-magnitude, magnitude);

            shakeY = Random.Range(-magnitude, magnitude);

            //operacion simple para cambiar la posicion de algo
            //Vector3 (valorX,valorY,valorZ) son los valores que se sumaran a la posicion del objeto

            cameraObject.gameObject.transform.position += new Vector3 (shakeX,shakeY,0);

            //tiempo entre cambios de posicion de camara
            yield return new WaitForSeconds(shakeSpeed);

        }    

    }
}

