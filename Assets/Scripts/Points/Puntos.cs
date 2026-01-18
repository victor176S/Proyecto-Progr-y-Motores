using UnityEngine;

public class Puntos : MonoBehaviour
{

    public static Puntos instance;

    GameObject gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        instance = this;

        gameManager = GameObject.Find("GameManager");
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

            Debug.Log("entrada trigger");
        
        gameManager.GetComponent<GameManager>().puntos += 1;

        Destroy(this.gameObject);

        }

    }
}
