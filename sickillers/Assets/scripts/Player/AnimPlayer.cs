using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    
    public Animator Anim;
    MovPlayer player;

    void Start()
    {
        player = GetComponent<MovPlayer>();
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
    }
}
