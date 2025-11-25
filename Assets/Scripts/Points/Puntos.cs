using UnityEngine;

public class Puntos : MonoBehaviour
{

    public static Puntos instance;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        
        GameManager.instance.puntos += 1;

        Destroy(gameObject);

        }

    }
}
