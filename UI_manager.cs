using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_manager : MonoBehaviour
{
    [SerializeField] GameObject value_1_hero;
    [SerializeField] GameObject value_2_sound;
    [SerializeField] GameObject value_3_enemy;
    [SerializeField] GameObject value_4_dragon;
    [SerializeField] GameObject value_5_platform_ice;
    [SerializeField] GameObject value_6_dragon_hot;
    [SerializeField] GameObject value_7_panel;
    [SerializeField] GameObject value_7_button;
    public void ButtonStart()
    {
        
        value_1_hero.SetActive(true);
        value_2_sound.SetActive(true);
        value_3_enemy.SetActive(true);
        value_4_dragon.SetActive(true);
        value_5_platform_ice.SetActive(true);
        value_6_dragon_hot.SetActive(true);
        value_7_panel.SetActive(false);
        Destroy(value_7_button); 
    }

    
}
