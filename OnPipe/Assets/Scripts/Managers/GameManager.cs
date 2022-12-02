using System;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private GameStates _currentState;
        
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onInit += OnInit;
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
        }
        
        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onInit -= OnInit;
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void OnInit()
        {
            _currentState = GameStates.Init;
            CoreGameSignals.Instance.onInit?.Invoke();
        }

        private void OnPlay()
        {
            _currentState = GameStates.Playing;
            CoreGameSignals.Instance.onPlay?.Invoke();
        }

        private void OnReset()
        {
            _currentState = GameStates.Init;
            CoreGameSignals.Instance.onReset?.Invoke();
        }
    }
}