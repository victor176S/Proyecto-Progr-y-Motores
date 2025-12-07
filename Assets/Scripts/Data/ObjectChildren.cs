using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectChildren : MonoBehaviour
{

    public static ObjectChildren instance;
    public GameObject padre;
    public List<GameObject> hijosRawImage;
    public List<GameObject> hijosTextMesh;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ApplyAlphaToChildren();
    }

    public void ApplyAlphaToChildren()
    {
        ApplyAlphaToChildrenRawImage();

        ApplyAlphaToChildrenTextMesh();
    }

    public void ApplyAlphaToChildrenRawImage()
    {
        foreach (GameObject objeto in hijosRawImage)
        {
            objeto.gameObject.GetComponent<RawImage>().color = new Color (255f,255f,255f,padre.gameObject.GetComponent<AlphaChangerPanelImage>().alpha/2);
        }
    }

    public void ApplyAlphaToChildrenTextMesh()
    {
         foreach (GameObject objeto in hijosTextMesh)
        {
            objeto.gameObject.GetComponent<TextMeshProUGUI>().color = new Color (255f,255f,255f,padre.gameObject.GetComponent<AlphaChangerPanelImage>().alpha/2);
        }
    }
}
