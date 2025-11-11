using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsUtilities : MonoBehaviour
{
    public static int sceneNumber;

    public GameObject options;

    public GameObject menuPrincipal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void ExitGame()
    {

        Application.Quit();

    }

    public void ChangeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void OptionsGenericOpen()
    {
        menuPrincipal.gameObject.SetActive(false);
        options.gameObject.SetActive(true);
       
    }
    
    public void OptionsGenericClose()
    {
        menuPrincipal.gameObject.SetActive(true);
        options.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
