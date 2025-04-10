using System;
using _Client.System.Managers;
using UnityEngine;

namespace _Client.Player
{
    public class FootballGoal : MonoBehaviour
    {
        [SerializeField] private Round _roundManager;
        [SerializeField] private int _playerId = 1;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Ball")
            {
                _roundManager.Goal(_playerId);
            }
        }
    }
}