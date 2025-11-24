using System.Collections;
using UnityEngine;

public class ArrowsAnim : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator TopToBottomArrowsAnim()
    {
        GameManager.instance.TopToBottomArrows.transform.position += new Vector3 (0,- 0.5f, 0);

        GameManager.instance.porcentajeSaltoText.transform.position += new Vector3 (-15, 2.5f, 0);

        GameManager.instance.DashCharge.transform.position += new Vector3 (0, 5, 0);

        yield return new WaitForSeconds (0.02f);
    }
}
