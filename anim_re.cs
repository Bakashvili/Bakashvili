using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_re : MonoBehaviour
{
    
    private Animator anim; // для enemy и hero
   
    void Awake()
    {
        anim = GetComponent<Animator>();
        
    }
     void getanim()
    {
        if (GetComponent<Hurt>().CurrentHealth != 2 || GetComponent<Hurt_dragon>().CurrentHealth != 4)
        {
            anim.SetTrigger("re");
        }
    }
}
