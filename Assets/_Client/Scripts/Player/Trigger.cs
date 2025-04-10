using System;
using _Client.Player;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            player.yaycoEnter(other);
        }
    }
}
