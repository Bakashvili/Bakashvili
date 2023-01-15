using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Globalization;

public class CoinCounter : MonoBehaviour
{
     public TMP_Text coincounterField;
    public static int coin;
    [SerializeField] private AudioClip coin_Sound;
    //public float coin = 0;
    //public string bonusName;
    //public TMP_Text coinCount;
    //void Awake()
    //{
    //    coinCount.text = PlayerPrefs.GetInt("Coin").ToString();
    //}
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        switch (bonusName)
    //        {
    //            case "Coin":
    //                int coins = PlayerPrefs.GetInt("Coin");
    //                PlayerPrefs.SetInt("Coin", coins + 1);
    //                coinCount.text = (coins + 1).ToString("0");
    //                Destroy(gameObject);
    //                break;
    //        }


    //    }


    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            coin++;
            SoundManager.instance.PlaySound(coin_Sound);
            coincounterField.text = coin.ToString("0");

            Destroy(gameObject);

        }


    }

    //private void OnColliderEnter2D(Collision2D coll)
    //{
    //    if (coll.gameObject.tag == "Coin")
    //    {
    //        coin++;
    //        coincounterField.text = coin.ToString("0.00");
    //        Destroy(coll.gameObject);
    //    }


    //}


}

