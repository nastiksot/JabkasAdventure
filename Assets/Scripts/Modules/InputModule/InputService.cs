﻿using System;
using Modules.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Modules.InputModule
{
    public class InputService : MonoBehaviour, IInputService
    {
        private PlayerInput playerInput;

        public event Action OnJump;
        public event Action OnMoveStopped;
        public event Action<float> OnMoveStarted; 

        private void Awake()
        {
            playerInput = new PlayerInput();
        }

        private void Start()
        {
            playerInput.ButtonInput.Move.started += OnMovePerformed; 
            playerInput.ButtonInput.Move.canceled += OnMoveCanceled; 
            playerInput.ButtonInput.Jump.performed += OnJumpPerformed;
        }

        private void OnMoveCanceled(InputAction.CallbackContext obj)
        { 
            OnMoveStopped?.Invoke();
        }

        private void OnJumpPerformed(InputAction.CallbackContext context)
        {
            OnJump?.Invoke();
        }

        private void OnMovePerformed(InputAction.CallbackContext context)
        { 
            OnMoveStarted?.Invoke(context.ReadValue<float>());
        }

        private void OnEnable()
        {
            playerInput.Enable();
        }

        private void OnDisable()
        {
            playerInput.Disable();
        }
    }
}