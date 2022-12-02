using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using Enums;
using Signals;
using UnityEngine;
using UnityTemplateProjects.Signals;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerParentMovement playerParentMovement;
        [SerializeField] private PlayerPhysicController playerPhysicController;
        
        private GameStates _currentState;
       
        private void Start()
        {
          playerParentMovement.StartMove();
        }
        
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
            CoreGameSignals.Instance.onFail += OnFail;
          
            InputSignals.Instance.onInputTaken += OnInputTaken;
            InputSignals.Instance.onInputRelease += OnInputRelease;
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
            CoreGameSignals.Instance.onFail -= OnFail;

            InputSignals.Instance.onInputTaken -= OnInputTaken;
            InputSignals.Instance.onInputRelease -= OnInputRelease;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void OnPlay()
        {
            if (_currentState == GameStates.Playing)
            {
                playerParentMovement.MoveUp();
            }
        }
        
        private void OnFail()
        {
            playerParentMovement.StopMove();
        }
        
        private void OnInputTaken(bool _isMouseHold)
        {
            playerPhysicController.SetMouseState(_isMouseHold);
            playerPhysicController.ScaleDownPlayer(playerPhysicController.GetTargetRadius());
        }

        private void OnInputRelease(bool _isMouseHold)
        {
            playerPhysicController.SetMouseState(_isMouseHold);
            playerPhysicController.ScaleUpPlayer();
        }

        private void OnReset()
        {
            
        }

    }
}