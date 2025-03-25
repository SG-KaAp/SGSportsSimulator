using System;
using UnityEngine;

namespace SGSports.System
{
    public class InputManager : Manager
    {
        private MainInput input;
        private void Awake()
        {
            input = new MainInput();
        }
        private void OnEnable()
        {
            input.Enable();
        }
        private void OnDisable()
        {
            input.Disable();
        }

        public Vector2 GetPlayerMovementVector()
        {
            return input.Player.MovementVector.ReadValue<Vector2>();
        }
    }
}