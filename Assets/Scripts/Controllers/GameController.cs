using Assets.Scripts.Constants;
using Assets.Scripts.Interactables;
using Assets.Scripts.Pickables;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private float _maxDistance = 5f;

        [SerializeField] private float _releaseForce = 100f;
        [SerializeField] private Transform _targetPosition = default!;


        private RaycastHit _hitInfo = default!;

        public Pickable Target { get; private set; } = default!;

        public bool IsPressing { get; private set; } = false;

        private void Update()
        {
            if (InputConstants.SelectPressed)
            {
                IsPressing = true;
                ProbeInteractables();
            }

            if (InputConstants.SelectReleased)
            {
                IsPressing = false;
                ProbeInteractables();
            }

            HandleTarget();
        }

        private void ProbeInteractables()
        {
            if (Physics.Raycast(
                    Camera.main.ScreenPointToRay(Input.mousePosition),
                    out _hitInfo,
                    maxDistance: _maxDistance))
            {
                if (_hitInfo.collider
                    .TryGetComponent<Interactable>(out var interactable))
                {
                    interactable.Interact(this);

                    var message = IsPressing ?
                        $"Pressed the Interactable {interactable.name}"
                        : $"Released on Interactable {interactable.name}";
                    Debug.Log(message);
                }
            }
        }

        private void HandleTarget()
        {
            if (Target == null)
            {
                return;
            }
        }

        public void SetTarget(Pickable pickable)
        {
            ReleaseTarget();
            Target = pickable;
        }

        private void ReleaseTarget()
        {
            if (Target != null)
            {
                Target.transform.SetParent(null);
                Target.Rigidbody
                    .AddForce(transform.forward * _releaseForce);

                Target = null;
            }
        }
    }
}