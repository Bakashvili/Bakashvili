using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour
{
    [SerializeField] private float AttackCooldowm;
    private Animator anim;
   // [SerializeField] private float damage;
    private Hero move;
    [SerializeField] private AudioClip attack_sword_Sound;
    [SerializeField] private Transform swordpoint;
    [SerializeField] private GameObject[] boom;
    private float cooldownTimer = Mathf.Infinity;
   
    private void Awake()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<Hero>();    
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && cooldownTimer > AttackCooldowm && move.canAttack()) 
        {
            Attackhero();
            cooldownTimer += Time.deltaTime;
            
            //Debug.Log("1");
        }
    }
    private void Attackhero()
    {
        SoundManager.instance.PlaySound(attack_sword_Sound);
        cooldownTimer = 0;
        anim.SetTrigger("attack");// для гл.героя
       // anim.SetTrigger("attack_dragon");
       boom[0].transform.position = swordpoint.position;
       boom[0].GetComponent<boom>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    
}
