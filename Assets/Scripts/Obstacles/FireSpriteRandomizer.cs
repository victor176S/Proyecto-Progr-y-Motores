using System.Collections;
using UnityEngine;

public class FireSpriteRandomizer : MonoBehaviour
{

    public Sprite sprite1;

    public Sprite sprite2;

    public Sprite sprite3;

    private int random;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FireSpriteRendererRandomizer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public IEnumerator FireSpriteRendererRandomizer()
    {

        while (true)
        {
        random = Random.Range(0,3);

        switch (random)
            {
            case 0:

                yield return new WaitForSeconds(0.1f);

                gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;

                break;

            case 1:

                yield return new WaitForSeconds(0.1f);

                gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;

                break;

            case 2:

                yield return new WaitForSeconds(0.1f);

                gameObject.GetComponent<SpriteRenderer>().sprite = sprite3;

                break;
            }
        }

    }

}
