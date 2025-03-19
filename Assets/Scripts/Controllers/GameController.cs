using Assets.Scripts.Constants;
using Assets.Scripts.Interactables;
using Assets.Scripts.Managers;
using Assets.Scripts.Pickables;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private float _maxDistance = 5f;

        private Interactable _target = default!;

        private RaycastHit _hitInfo = default!;
        private Ray _ray = new();

        // TODO : Verification is Required
        private Ray LookRay
        {
            get
            {
                _ray.origin = transform.position;
                _ray.direction = transform.forward;

                return _ray;
            }
        }

        private bool _isPressing = false;
        private float _currentPressTime = 0f;

        private void Awake()
        {
            StartCoroutine(
                NetworkManager.UpdateInventoryStatus(
                    new()
                    {
                        Type = FindObjectOfType<Pickable>().Type,
                        IsSet = false
                    }));
        }

        private void Update()
        {
            if (InputConstants.SelectPressed)
            {
                _isPressing = true;
                _currentPressTime = InputConstants.LongPress;
            }

            if (Physics.Raycast(
                    LookRay,
                    out _hitInfo,
                    maxDistance: _maxDistance))
            {
                if (_hitInfo.collider
                    .TryGetComponent<Interactable>(out var interactable))
                {
                    _target = interactable;
                    Debug.Log($"Pressed the Interactable {_target.name}");
                }
            }
        }
    }
}