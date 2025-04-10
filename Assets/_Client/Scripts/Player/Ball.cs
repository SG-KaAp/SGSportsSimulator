using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Client.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float baseSpeed = 5f;
        [SerializeField] private float maxSpeed = Mathf.Infinity;
        public float CurrentSpeed { private get; set; }

        private void Awake()
        {
            AddStartingForce();
        }

        public void ResetPosition()
        {
            rb.linearVelocity = Vector2.zero;
            rb.position = Vector2.zero;
        }

        public void AddStartingForce()
        {
            // Flip a coin to determine if the ball starts left or right
            float x = Random.value < 0.5f ? -1f : 1f;

            // Flip a coin to determine if the ball goes up or down. Set the range
            // between 0.5 -> 1.0 to ensure it does not move completely horizontal.
            float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f)
                : Random.Range(0.5f, 1f);

            // Apply the initial force and set the current speed
            Vector2 direction = new Vector2(x, y).normalized;
            rb.AddForce(direction * baseSpeed, ForceMode.Impulse);
            CurrentSpeed = baseSpeed;
        }

        private void FixedUpdate()
        {
            // Clamp the velocity of the ball to the max speed
            Vector2 direction = rb.linearVelocity.normalized;
            CurrentSpeed = Mathf.Min(CurrentSpeed, maxSpeed);
            rb.linearVelocity = direction * CurrentSpeed;
        }

    }
}