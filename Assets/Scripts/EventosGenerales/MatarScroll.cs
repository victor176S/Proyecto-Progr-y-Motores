using UnityEngine;
using UnityEngine.SceneManagement;

public class MatarScroll : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        Debug.Log("Trigger scroll");


        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log("Trigger scroll player");

            SceneManager.LoadScene(4);
        }
    }
}
