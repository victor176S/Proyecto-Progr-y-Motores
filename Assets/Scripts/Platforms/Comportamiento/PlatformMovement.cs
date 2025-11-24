using System.Collections;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    public static PlatformMovement instance;

    public Vector3 valorDeIncremento = new Vector3(0,0.5f,0);

    public int veces = 400; //cambiar desde el inspector (duracion)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
      instance = this;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlatformGoingUp()
    {

        for (int i = 0; i <= veces*10; i++)
        {
            gameObject.transform.localPosition += valorDeIncremento * Time.deltaTime * 10;

            GameManager.instance.player.GetComponent<Transform>().position += valorDeIncremento * Time.deltaTime * 10;

            yield return new WaitForSeconds (0.001f);
        }
        
    }
}
