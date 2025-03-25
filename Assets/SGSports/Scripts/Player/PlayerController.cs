using SGSports.System;
using UnityEngine;

namespace SGSPorts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed = 5f;
        [SerializeField] private int playerId = 1;
        private InputManager input;

        private void Awake()
        {
            input = FindAnyObjectByType<InputManager>();
        }

        private void Update()
        {
            PlayerMove(input.GetPlayerMovementVector(playerId).x * transform.right + input.GetPlayerMovementVector(playerId).y * transform.forward, speed);
        }

        private void PlayerMove(Vector3 direction, float moveSpeed)
        {
            rb.linearVelocity = direction * moveSpeed + rb.linearVelocity.y * transform.up;
        }
    }
}