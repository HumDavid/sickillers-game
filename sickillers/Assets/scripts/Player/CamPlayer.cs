using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPlayer : MonoBehaviour
{
    public Transform characterBody;
    public Transform characterHead;

    float rotationX = 0;
    public float rotationY = 0;

    float sensitivityX = 2;
    float sensitivityY = 2;

    float angleYmin = -90;
    float angleYmax = 90;

    float smoothRotx = 0;
    float smoothRoty = 0;

    float smoothCoefx = 0.005f;
    float smoothCoefy = 0.005f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = characterHead.position;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY;
        float horizonalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;

        smoothRotx= Mathf.Lerp(smoothRotx, horizonalDelta, smoothCoefx);
        smoothRoty= Mathf.Lerp(smoothRoty, verticalDelta, smoothCoefy);

        rotationX += horizonalDelta;
        rotationY += verticalDelta;

        

        rotationY = Mathf.Clamp(rotationY, angleYmin, angleYmax);
        characterBody.localEulerAngles = new Vector3(0, rotationX, 0);  
        transform.localEulerAngles = new Vector3(0,rotationX, 0);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

    }
}
