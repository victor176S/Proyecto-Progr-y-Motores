using System.IO.Compression;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public bool activateClockwise;

    public bool activateCounterClockwise;

    public float cameraClockwiseRotation;

    public float cameraCounterClockwiseRotation;

    public float velocidadRotacion = 1f;

    private float x;
    private float y;

    private float z;
    private Vector3 rotateValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        /*mover con el raton xd

        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        Debug.Log(x + ":" + y);
        rotateValue = new Vector3(x, y * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;
        */
        z = 0.05f;
        y = 0f;
        x = 0f;
        Debug.Log(x + ":" + y);
        rotateValue = new Vector3(x, y * -1, z);
        transform.eulerAngles = transform.eulerAngles - rotateValue;

    }
}
