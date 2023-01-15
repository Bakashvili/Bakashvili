using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Globalization;
public class Hurt : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRend;
    [SerializeField] private AudioClip injury_Sound;
    [SerializeField] private AudioClip death_Sound;
    [Header ("Heath")]
    [SerializeField] private float StartHealth;
    [SerializeField] public float CurrentHealth;
    public bool dead = false;
    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int NumberOfFlashes;
    [SerializeField] private GameObject sword_active_true;
   // [SerializeField] private GameObject heart_true;
    //[SerializeField] private GameObject sword_active_false;
    private void Awake()
    {
        CurrentHealth = StartHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _damage, 0, StartHealth);

        if (CurrentHealth > 0)
        {
            SoundManager.instance.PlaySound(injury_Sound);
           // spriteRend.color = new Color(1, 0, 0, 0.5f);
            StartCoroutine(Invunerability());
           
        }
        else if(!dead)
        {
            
                SoundManager.instance.PlaySound(death_Sound);
                anim.SetTrigger("enemydeath");
                GetComponent<Enemy>().enabled = false;
                dead = true;
                
                Destroy(gameObject);
               // heart_true.SetActive(true);
               // Instantiate(heart_true);

        }
        else 
        { 
           //spriteRend.color = new Color(1, 0, 0, 0f);
        }
    }


    private IEnumerator Invunerability()
    {
        sword_active_true.SetActive(true);
        Physics2D.IgnoreLayerCollision(3,6,true);
        spriteRend.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(1);
        spriteRend.color = Color.white;
       // yield return new WaitForSeconds(iFramesDuration / (NumberOfFlashes));
        Physics2D.IgnoreLayerCollision(3, 6, false);
        sword_active_true.SetActive(false);
    }

}