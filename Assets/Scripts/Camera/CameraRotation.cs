using System;
using System.IO.Compression;
using Unity.Mathematics;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public bool activateClockwise;

    public bool activateCounterClockwise;

    public bool TiltAnimation;

    public bool TiltRight;

    public bool TiltLeft;

    public float TiltRightTime = 1f;

    public float TiltLeftTime;

    public float z;

    [SerializeField] private float zOffset = 0f;

    [SerializeField] private float smoothTimeZ = 0.1f;

    float r;

    public float Target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {

        if (activateClockwise)
        {
            Target += 0.2f;
        }

        if (activateCounterClockwise)
        {
            Target -= 0.2f;
        }
        /*mover con el raton xd

        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        Debug.Log(x + ":" + y);
        rotateValue = new Vector3(x, y * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;
        */

        float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, Target, ref r, 0.1f);
        transform.rotation = Quaternion.Euler(0,0,Angle);

        //animacion tilt

        if (TiltAnimation)
        {

            if (TiltRightTime > 0)
            {

            Target -= 0.2f;
            TiltRightTime -= 0.05f * Time.deltaTime;

            }

            if (TiltRightTime <= 0)
            {
                
                TiltLeftTime = 1f;

            }
            //se acaba arriba la animacion hacia la der
            if (TiltLeftTime > 0)
            {
                
            Target += 0.2f;
            TiltLeftTime -= 0.05f * Time.deltaTime;


            }

            if (TiltLeftTime <= 0)
            {
                
                TiltRightTime = 1f;

            }

            //se acaba arriba la animacion hacia la izq

        float AngleAnimation = Mathf.SmoothDampAngle(transform.eulerAngles.z, Target, ref r, 0.1f);
        transform.rotation = Quaternion.Euler(0,0,AngleAnimation);

        }

    }
}
