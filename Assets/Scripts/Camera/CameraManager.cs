using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    public GameObject camara;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camara.gameObject.GetComponent<Camera>().fieldOfView = 70;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
