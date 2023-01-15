using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plusheart : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float plushearts;
    //public bool value_heart = false;
   // public float CurrentHealth { get; private set; }


    [SerializeField] private AudioClip heart_Sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //value_heart= true;
            SoundManager.instance.PlaySound(heart_Sound);
            //TakeDamage(plushearts);
            collision.GetComponent<heartsystem>().TakeDamage(plushearts);
            Destroy(gameObject);
            //value_heart = false;
        }
       
    }
   


}

