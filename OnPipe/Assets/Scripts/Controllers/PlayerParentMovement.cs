using System;
using Enums;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class PlayerParentMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        private GameStates _currentState;
        private bool canMove;

       

        private void Update()
        {
            if (canMove)
            {
                MoveUp();
            }
        }

        public void StartMove()
        {
            canMove = true;
        }

        public void MoveUp()
        {
            transform.position = Vector3.Lerp(transform.position,transform.position+Vector3.up,Time.deltaTime*speed);
        }

        public void StopMove()
        {
            canMove = false;
        }
    }
}