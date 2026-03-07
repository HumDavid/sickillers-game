using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    
    public Animator Anim;
    public GameObject Cam;
    public Transform Head, Arms;
    MovPlayer player;
    CamPlayer camScript;

    void Start()
    {
        player = GetComponent<MovPlayer>();
        camScript = Cam.GetComponent<CamPlayer>();
    }

    void Update()
    {
        if(player.forwardInput > 0 || player.strafeInput != 0)
        {
            Anim.SetBool("walking", true);
        }
        else
        {
            Anim.SetBool("walking", false);
        }

        Arms.localEulerAngles = new Vector3(-camScript.rotationY, 0, 0);
    }

}
