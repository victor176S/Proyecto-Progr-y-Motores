using System;
using System.IO.Compression;
using Unity.Mathematics;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public bool activateClockwise;

    public bool activateCounterClockwise;

    public bool tiltAnimation;

    public bool tiltToTheLeft = false;

    public bool tiltToTheRight = true;

    public float maxTiltRight = -20f;

    public float maxTiltLeft = 20f;
    //wip, no se si lo voy a usar
    public int intervalosCamaraAnimation;

    float r;

    public float target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            // de 20 hacia 15 (->)
        
        if (tiltToTheRight && target <= maxTiltLeft && target > 15f)
            {
                target -= 0.10f;
            }

            //de 15 hacia 10 (->)

            if (tiltToTheRight && target <= 15f && target > 10f)
            {
                target -= 0.15f;
            }

            // de 10 hacia -10 (->)

            if (tiltToTheRight && target <= 10f && target >= -10f)
            {
                target -= 0.20f;
            }

            //de -10 hacia -15 (->)

            if (tiltToTheRight && target < -10 && target >= -15f)
            {
                target -= 0.15f;
            }

            //de -15 hacia -20 (->)

            if (tiltToTheRight && target < -15f && target >= maxTiltRight)
            {
                target -= 0.10f;
            }
            //se acaba arriba la animacion hacia la derecha


            //de -20 hacia -15 (<-)

            if (tiltToTheLeft && target >= maxTiltRight && target < -15f)
            {
                target += 0.10f;
            }

            //de -15 hacia -10 (<-)

            if (tiltToTheLeft && target >= -15f && target < -10f)
            {
                target += 0.15f;
            }

            // de -10 hacia 10 (<-)

            if (tiltToTheLeft && target >= -10f && target < 10f)
            {
                target += 0.20f;
            }

            // de 10 hacia 15 (<-)

            if (tiltToTheLeft && target >= 10f && target < 15f)
            {
                target += 0.15f;
            }

            //de 15 hacia 20 (<-)

            if (tiltToTheLeft && target >= 15f && target <= maxTiltLeft)
            {
                target += 0.10f;
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
