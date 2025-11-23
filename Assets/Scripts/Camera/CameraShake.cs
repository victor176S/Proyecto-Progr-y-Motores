using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public GameObject cameraObject; // set this via inspector
    public float shake = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

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
        
        ShakeLogic();

    }

    public void ShakeLogic()
    {
            
        if (shake > 0) 
        {
            cameraObject.transform.localPosition = Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;

        }

        else
        {
            shake = 0.0f;
        }
    }
}

