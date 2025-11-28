using UnityEngine;

public class DatosPersistentes : MonoBehaviour
{
    public static DatosPersistentes instance;

    public float volumenMusica;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {  
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
