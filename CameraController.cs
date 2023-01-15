using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Globalization;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    [SerializeField] private float Cameraspeed;
    [SerializeField] private float aheadDistance;
    [SerializeField]  private Transform player;
    private Vector3 velocity = Vector3.zero;
    private float currentPosX;
    private float lookAhead;
    void Start()
    {
        transform.position = new Vector3((float)-12.59, (float)1.07, -10);
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * Cameraspeed);
    }
    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
