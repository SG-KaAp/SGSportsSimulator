using _Client.System;
using UnityEngine;

namespace _Client.Player
{
    public class RacketController : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private int playerId = 1;
        private void Update()
        {
            //print(InputHandler.TennisActions.MovementVector.ReadValue<float>());
            if (playerId == 1)
            {
                PlayerMove(InputHandler.TennisActions.MovementVector.ReadValue<float>() * transform.forward, speed);
            }
            else
            {
                PlayerMove(InputHandler.TennisAltActions.MovementVector.ReadValue<float>() * transform.forward, speed);
            }
        }

        private void PlayerMove(Vector3 direction, float moveSpeed)
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}