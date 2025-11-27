using System.Collections;
using UnityEngine;

public class SpikesSpriteRandomizer : MonoBehaviour
{

    public Sprite sprite1;

    public Sprite sprite2;

    public Sprite sprite3;

    private int random;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        random = Random.Range(0,3);

        SpriteRendererRandomizer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpriteRendererRandomizer()
    {

        Debug.Log($"SpriteRandom {random}");

        switch (random)
        {
            case 0:

                gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;

                break;

            case 1:

                gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;

                break;

            case 2:

                gameObject.GetComponent<SpriteRenderer>().sprite = sprite3;

                break;
        }

    }

}
