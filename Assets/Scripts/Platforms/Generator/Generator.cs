using UnityEngine;

public class Generator : MonoBehaviour
{

    public int random;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerarPlataformasRandom();
    }

    public void GenerarPlataformasRandom()
    {

        random = Random.Range(0, 10);

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
