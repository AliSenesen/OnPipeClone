using System;
using DG.Tweening;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class PlayerPhysicController : MonoBehaviour
    {
        [SerializeField] private GameObject player;

        private float targetRadius = 1;
        private bool isMouseHold;

        public float GetTargetRadius()
        {
            return targetRadius;
        }
        
        public void SetTargetRadius(float _targetRadius)
        {
            targetRadius = _targetRadius;

            if (isMouseHold)
            {
                // DOTween.Kill(transform);
                ScaleDownPlayer(targetRadius);
            }
        }

        public void SetMouseState(bool _isMouseHold)
        {
            isMouseHold = _isMouseHold;
        }

        public void ScaleUpPlayer()
        {
            player.transform.DOScaleX(1, 0.3f);
            player.transform.DOScaleZ(1, 0.3f);
        }

        public void ScaleDownPlayer(float scaleRadius)
        {
            player.transform.DOScaleX(scaleRadius, 0.3f);
            player.transform.DOScaleZ(scaleRadius, 0.3f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Pipe pipe))
            {
                SetTargetRadius(pipe.GetRadius());
            }
            
            if (other.TryGetComponent(out Corn corn))
            {
                corn.PlayCornFall();
            }
            
            if (other.CompareTag("PipeDestroyer"))
            {
                CoreGameSignals.Instance.onFail?.Invoke();
                Debug.Log("FAIL");
            }
        }
    }
}