using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Globalization;
public class heartsystem : MonoBehaviour
{
    [SerializeField] private float StartHealth;
    public bool dead = false;
     private Animator anim;
    //private Enemy injury;
    [SerializeField] private AudioClip injury_Sound;
    [SerializeField] private AudioClip death_Sound;
    //private float time_health;
    public float CurrentHealth { get; private set; }
    private void Awake()
    {
        CurrentHealth = StartHealth;
        //injury = GetComponent<Enemy>();
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
   {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _damage, 0, StartHealth);
        //time_health = CurrentHealth;
      if (_damage > 0) 
      { 
        if(CurrentHealth > 0 )
        {
            SoundManager.instance.PlaySound(injury_Sound);
            anim.SetTrigger("injury");

        }
        else 
        {
            if (!dead)
            {
                SoundManager.instance.PlaySound(death_Sound);
                anim.SetTrigger("death");
                GetComponent<Hero>().enabled = false;
                dead = true;
                
            }
            
        }
      }

   }
    

   public bool dead_hero()
    {
        return dead;
    }
    
}
