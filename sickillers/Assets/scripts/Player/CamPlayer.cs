using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPlayer : MonoBehaviour
{
    public Transform characterBody;
    public Transform characterHead;

    float rotationX = 0;
    float rotationY = 0;
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
        float verticalDelta = Input.GetAxisRaw("Mouse Y");
        float horizonalDelta = Input.GetAxisRaw("Mouse X");

        rotationX += horizonalDelta;
        rotationY += verticalDelta;

        characterBody.localEulerAngles = new Vector3(0, rotationX, 0);  
        transform.localEulerAngles = new Vector3(0,rotationX, 0);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

    }
}
