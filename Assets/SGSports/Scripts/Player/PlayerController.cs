using SGSports.System;
using UnityEngine;

namespace SGSPorts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed = 5f;
        [SerializeField] private int playerId = 1;
        private void Update()
        {
            if (playerId == 1)
            {
                PlayerMove(
                    InputHandler.FootballActions.MovementVector.ReadValue<Vector2>().x * transform.right +
                    InputHandler.FootballActions.MovementVector.ReadValue<Vector2>().y * transform.forward, speed);
            }
            else
            {
                PlayerMove(
                    InputHandler.FootballAltActions.MovementVector.ReadValue<Vector2>().x * transform.right +
                    InputHandler.FootballAltActions.MovementVector.ReadValue<Vector2>().y * transform.forward, speed);
            }
        }
        private void PlayerMove(Vector3 direction, float moveSpeed)
        {
            rb.linearVelocity = direction * moveSpeed + rb.linearVelocity.y * transform.up;
        }
    }
}