using System.Collections;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    public static PlatformMovement instance;

    public Vector3 valorDeIncremento = new Vector3(0,1,0);

    public int veces = 400;
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

        for (int i = 0; i <= veces; i++)
        {
            gameObject.transform.localPosition += valorDeIncremento * Time.deltaTime * 100;

            GameManager.instance.player.GetComponent<Transform>().position += valorDeIncremento * Time.deltaTime * 100;

            yield return new WaitForSeconds (0.05f);
        }
        
    }
}
