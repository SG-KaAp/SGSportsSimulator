using System;
using _Client.System;
using DG.Tweening;
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
        [SerializeField] private bool _withBall;
        private Collider ball;
        private FootballBall yayco;

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
                if (rb.linearVelocity.z > 0) transform.eulerAngles = new Vector3(0, 0, 0);
                if (rb.linearVelocity.z < 0) transform.eulerAngles = new Vector3(0, 180, 0);
                if (rb.linearVelocity.x > 0) transform.eulerAngles = new Vector3(0, 90, 0);
                if (rb.linearVelocity.x < 0) transform.eulerAngles = new Vector3(0, -90, 0);
                if (_withBall && InputHandler.FootballActions.Jump.triggered)
                {
                    print("aeee");
                    BallExit();
                    /*if (transform.eulerAngles == new Vector3(0, 90, 0))
                    {
                        ball.GetComponent<Rigidbody>().AddForce(transform.forward * 750f);
                    }
                    if (transform.eulerAngles == new Vector3(0, -90, 0))
                    {
                        ball.GetComponent<Rigidbody>().AddForce(transform.forward * -1 * 750f);
                    }
                    if (transform.eulerAngles == new Vector3(0, 0, 0))
                    {
                        ball.GetComponent<Rigidbody>().AddForce(transform.right * 750f);
                    }
                    if (transform.eulerAngles == new Vector3(0, 180, 0))
                    {
                        ball.GetComponent<Rigidbody>().AddForce(transform.forward * -1 * 750f);
                    }*/
                    ball.GetComponent<Rigidbody>().AddForce(transform.forward * 750f);
                }
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
                if (InputHandler.FootballAltActions.MovementVector.ReadValue<Vector2>().x != 0)
                {
                    _animController.Play("Run");
                }
                if (InputHandler.FootballAltActions.MovementVector.ReadValue<Vector2>().y != 0)
                {
                    _animController.Play("Run");
                }
                if (rb.linearVelocity.z > 0) transform.eulerAngles = new Vector3(0, 0, 0);
                if (rb.linearVelocity.z < 0) transform.eulerAngles = new Vector3(0, 180, 0);
                if (rb.linearVelocity.x > 0) transform.eulerAngles = new Vector3(0, 90, 0);
                if (rb.linearVelocity.x < 0) transform.eulerAngles = new Vector3(0, -90, 0);
                if (_withBall && InputHandler.FootballAltActions.Jump.triggered)
                {
                    print("aeee");
                    BallExit();
                    /*if (transform.eulerAngles == new Vector3(0, 90, 0))
                    {
                        ball.GetComponent<Rigidbody>().AddForce(transform.forward * 750f);
                    }
                    if (transform.eulerAngles == new Vector3(0, -90, 0))
                    {
                        ball.GetComponent<Rigidbody>().AddForce(transform.forward * -1 * 750f);
                    }
                    if (transform.eulerAngles == new Vector3(0, 0, 0))
                    {
                        ball.GetComponent<Rigidbody>().AddForce(transform.right * 750f);
                    }
                    if (transform.eulerAngles == new Vector3(0, 180, 0))
                    {
                        ball.GetComponent<Rigidbody>().AddForce(transform.forward * -1 * 750f);
                    }*/
                    ball.GetComponent<Rigidbody>().AddForce(transform.forward * 750f);
                }
            }
        }
        private void PlayerMove(Vector3 direction, float moveSpeed)
        {
            rb.linearVelocity = direction * moveSpeed + rb.linearVelocity.y * transform.up;
        }
        public void BallEnter(Collider other, FootballBall sender)
        {
            if (other.CompareTag("Ball"))
            {
                other.transform.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.SetParent(ballPoint.transform);
                _withBall = true;
                ball = other;
                yayco = sender;
            }
        }

        public void BallExit()
        {
            if (ball == null) return;
            ball.transform.GetComponent<Rigidbody>().isKinematic = false;
            ball.transform.SetParent(null);
            _withBall = false;
            yayco.afterdark();
            //ball = null;
            //yayco = null;
        }
        public void SetPause(bool value)
        {
            pause = value;
            rb.linearVelocity = Vector3.zero;
        }
    }
}