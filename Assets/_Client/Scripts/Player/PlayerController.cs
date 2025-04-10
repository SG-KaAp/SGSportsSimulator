using System;
using _Client.System;
using DG.Tweening;
using UnityEditor.Animations;
using UnityEngine;

namespace _Client.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed = 5f;
        [SerializeField] private int playerId = 1;
        [SerializeField] private Animator _animController;
        [SerializeField] private bool pause = true;
        [SerializeField] private GameObject grabText;
        [SerializeField] private GameObject ballPoint;

        private void Awake()
        {
            InputHandler.Initialize();
            print("Abobas");
        }

        private void Update()
        {
            if (pause) return;
            if (playerId == 1)
            {
                PlayerMove(
                    InputHandler.FootballActions.MovementVector.ReadValue<Vector2>().x * Vector3.right +
                    InputHandler.FootballActions.MovementVector.ReadValue<Vector2>().y * Vector3.forward, speed);
                if (InputHandler.FootballActions.MovementVector.ReadValue<Vector2>().x +
                    InputHandler.FootballActions.MovementVector.ReadValue<Vector2>().y != 0)
                {
                    _animController.Play("Run");
                }
                if (InputHandler.FootballActions.MovementVector.ReadValue<Vector2>() == Vector2.left) transform.eulerAngles = new Vector3(0, -90, 0);
                if (InputHandler.FootballActions.MovementVector.ReadValue<Vector2>() == Vector2.right) transform.eulerAngles = new Vector3(0, 90, 0);
                if (InputHandler.FootballActions.MovementVector.ReadValue<Vector2>() == Vector2.up) transform.eulerAngles = new Vector3(0, 0, 0);
                if (InputHandler.FootballActions.MovementVector.ReadValue<Vector2>() == Vector2.down) transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                PlayerMove(
                    InputHandler.FootballAltActions.MovementVector.ReadValue<Vector2>().x * Vector3.right +
                    InputHandler.FootballAltActions.MovementVector.ReadValue<Vector2>().y * Vector3.forward, speed);
                if (InputHandler.FootballAltActions.MovementVector.ReadValue<Vector2>().x +
                    InputHandler.FootballAltActions.MovementVector.ReadValue<Vector2>().y != 0)
                {
                    _animController.Play("Run");
                }
                if (InputHandler.FootballAltActions.MovementVector.ReadValue<Vector2>() == Vector2.left) transform.eulerAngles = new Vector3(0, -90, 0);
                if (InputHandler.FootballAltActions.MovementVector.ReadValue<Vector2>() == Vector2.right) transform.eulerAngles = new Vector3(0, 90, 0);
                if (InputHandler.FootballAltActions.MovementVector.ReadValue<Vector2>() == Vector2.up) transform.eulerAngles = new Vector3(0, 0, 0);
                if (InputHandler.FootballAltActions.MovementVector.ReadValue<Vector2>() == Vector2.down) transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        private void PlayerMove(Vector3 direction, float moveSpeed)
        {
            rb.linearVelocity = direction * moveSpeed + rb.linearVelocity.y * transform.up;
        }
        public void yaycoEnter(Collider other)
        {
            grabText.SetActive(true);
            if (playerId == 1)
            {
                if (!InputHandler.FootballActions.Jump.triggered) return;
                other.transform.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.SetParent(ballPoint.transform);
                print("ab");
            }
            if (playerId == 2)
            {
                if (!InputHandler.FootballAltActions.Jump.triggered) return;
                other.transform.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.SetParent(ballPoint.transform);
                print("ab2");
            }
        }

        public void yaycoExit(Collider other)
        {
            grabText.SetActive(false);
        }

        public void SetPause(bool value)
        {
            pause = value;
        }
    }
}