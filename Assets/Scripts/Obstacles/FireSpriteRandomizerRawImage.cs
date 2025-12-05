using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FireSpriteRandomizerRawImage : MonoBehaviour
{

    public Texture2D imagen1;

    public Texture2D imagen2;

    public Texture2D imagen3;

    private int random;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FireImageRendererRandomizer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public IEnumerator FireImageRendererRandomizer()
    {

        while (true)
        {
        random = Random.Range(0,3);

        switch (random)
            {
            case 0:

                yield return new WaitForSeconds(0.1f);

                gameObject.GetComponent<RawImage>().texture = imagen1;

                break;

            case 1:

                yield return new WaitForSeconds(0.1f);

                gameObject.GetComponent<RawImage>().texture = imagen2;

                break;

            case 2:

                yield return new WaitForSeconds(0.1f);

                gameObject.GetComponent<RawImage>().texture = imagen3;

                break;
            }
        }

    }

}
