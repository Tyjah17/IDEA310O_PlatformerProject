using System.Collections.Generic;
using UnityEngine;

public class FanUpdraft : MonoBehaviour
{
    CharacterController controller;
    GameObject player;

    Vector3 some;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<CharacterController>();
    }

    void OnTriggerEnter()
    {
        some = new Vector3(player.transform.position.x, player.transform.position.y + 800, player.transform.position.z);
        controller.Move(some * Time.deltaTime);
    }
}