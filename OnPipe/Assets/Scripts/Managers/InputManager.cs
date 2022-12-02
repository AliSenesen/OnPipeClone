using System;
using Controllers;
using DG.Tweening;
using UnityEngine;
using UnityTemplateProjects.Signals;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        private void Update()
        {
            CheckInputs();
        }

        private void CheckInputs()
        {
            if (Input.GetMouseButtonDown(0))
            {
                InputSignals.Instance.onInputTaken?.Invoke(true);
            }
            if (Input.GetMouseButtonUp(0))
            {
                InputSignals.Instance.onInputRelease?.Invoke(false);
            }
        }
       
    }
}