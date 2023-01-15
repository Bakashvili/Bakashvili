using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Panelheartsystem : MonoBehaviour
{
    [SerializeField] private heartsystem playerHealth;
    [SerializeField] private plusheart playerHealthplus;

    [SerializeField] private Image totalhealthbar;

    [SerializeField] private Image currenthealthbar;
    // Start is called before the first frame update
    void Start()
    {
       
        totalhealthbar.fillAmount = playerHealth.CurrentHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currenthealthbar.fillAmount = playerHealth.CurrentHealth / 10;
    }
}
