using System;
using System.IO.Compression;
using Unity.Mathematics;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public static CameraRotation instance;

    public bool activateClockwise;

    public bool activateCounterClockwise;

    public bool tiltAnimation;

    public bool tiltToTheLeft = false;

    public bool tiltToTheRight = true;

    public float maxTiltRight = -12.5f;

    public float maxTiltLeft = 12.5f;
    //wip, no se si lo voy a usar
    public int intervalosCamaraAnimation;

    float r;

    public float target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //"instance = this" en awake me deja usar valores de este script en otros
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        //manual activation
        if (activateClockwise)
        {
            target += 0.2f;
        }

        if (activateCounterClockwise)
        {
            target -= 0.2f;
        }
        /*mover con el raton xd

        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        Debug.Log(x + ":" + y);
        rotateValue = new Vector3(x, y * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;
        */

        float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, target, ref r, 0.1f);
        transform.rotation = Quaternion.Euler(0,0,Angle);

        

        if (target <= maxTiltRight)
            {
                
                tiltToTheRight = false;
                tiltToTheLeft = true;
                
            }

        if (target >= maxTiltLeft)
            {
            
                tiltToTheLeft = false;    
                tiltToTheRight = true;

            }

        //animacion tilt

        if (tiltAnimation)
        {
            
            CamTiltAdjustLogic();
    
            CamtiltAnimationLogic();

            float AngleAnimation = Mathf.SmoothDampAngle(transform.eulerAngles.z, target, ref r, 0.1f);
            transform.rotation = Quaternion.Euler(0,0,AngleAnimation);

        }

    }

    public void CamtiltAnimationLogic()
    {
            // de 12.5 hacia 10 (->)
        
        if (tiltToTheRight && target <= maxTiltLeft && target > 10f)
            {
                target -= 0.06f;
            }

            //de 10 hacia 7.5 (->)

            if (tiltToTheRight && target <= 10f && target > 7.5f)
            {
                target -= 0.085f;
            }

            // de 7.5 hacia -7.5 (->)

            if (tiltToTheRight && target <= 7.5f && target >= -7.5f)
            {
                target -= 0.1f;
            }

            //de -7.5 hacia -10(->)

            if (tiltToTheRight && target < -7.5 && target >= -10f)
            {
                target -= 0.085f;
            }

            //de -10 hacia -12.5 (->)

            if (tiltToTheRight && target < -10f && target >= maxTiltRight)
            {
                target -= 0.07f;
            }
            //se acaba arriba la animacion hacia la derecha


            //de -12.5 hacia -10 (<-)

            if (tiltToTheLeft && target >= maxTiltRight && target < -10f)
            {
                target += 0.07f;
            }

            //de -10 hacia -7.5 (<-)

            if (tiltToTheLeft && target >= -10f && target < -7.5f)
            {
                target += 0.085f;
            }

            // de -7.5 hacia 7.5 (<-)

            if (tiltToTheLeft && target >= -7.5f && target < 7.5f)
            {
                target += 0.1f;
            }

            // de 7.5 hacia 10 (<-)

            if (tiltToTheLeft && target >= 7.5f && target < 10f)
            {
                target += 0.085f;
            }

            //de 10 hacia 12.5 (<-)

            if (tiltToTheLeft && target >= 10f && target <= maxTiltLeft)
            {
                target += 0.07f;
            }
            //se acaba arriba la animacion hacia la izq

    }

    public void CamTiltAdjustLogic()
    {

        //Rectificacion de floats target

        if (target > maxTiltLeft)
        {
            target = maxTiltLeft;
        }

        if (target < maxTiltRight)
        {
            target = maxTiltRight;
        }
        
    }
}
