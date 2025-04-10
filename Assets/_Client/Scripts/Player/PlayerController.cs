using _Client.System;
using UnityEngine;

namespace _Client.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed = 5f;
        [SerializeField] private int playerId = 1;

        private void Awake()
        {
            InputHandler.Initialize();
            print("Abobas");
        }

        private void Update()
        {
            if (playerId == 1)
            {
                PlayerMove(
                    InputHandler.FootballActions.MovementVector.ReadValue<Vector2>().x * transform.forward * -1 +
                    InputHandler.FootballActions.MovementVector.ReadValue<Vector2>().y * transform.right, speed);
            }
            else
            {
                PlayerMove(
                    InputHandler.FootballAltActions.MovementVector.ReadValue<Vector2>().x * transform.forward * -1 +
                    InputHandler.FootballAltActions.MovementVector.ReadValue<Vector2>().y * transform.right, speed);
            }
        }
        private void PlayerMove(Vector3 direction, float moveSpeed)
        {
            rb.linearVelocity = direction * moveSpeed + rb.linearVelocity.y * transform.up;
        }
    }
}