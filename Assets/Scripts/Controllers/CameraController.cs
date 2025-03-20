using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _boundaryThreshold = 0.1f;
        [SerializeField] private float _sensitivity = 1f;

        [Range(0f, 90f)]
        [SerializeField] private float _maxVerticalAngle = 90f;

        private Vector2 _cameraDimensions = Vector2.zero;

        private Vector3 _cameraRotation = Vector3.zero;

        private void Awake()
        {
            _cameraRotation = transform.eulerAngles;
            _cameraDimensions = new(Camera.main.pixelWidth, Camera.main.pixelHeight);
        }
        private void Update()
        {
            CheckBoundaries();
        }

        private void CheckBoundaries()
        {
            var boundaries = CalculateBoundaries();
            Debug.Log($"{boundaries}, {Input.mousePosition}, {_cameraDimensions}");

            if (boundaries.magnitude > 0)
            {
                _cameraRotation += _sensitivity * new Vector3(-boundaries.y, boundaries.x, 0f);
                transform.eulerAngles = _cameraRotation;
            }
        }

        private Vector2 CalculateBoundaries()
        {
            var mousePosition = Input.mousePosition;

            var percentages = new Vector2(
                mousePosition.x / _cameraDimensions.x,
                mousePosition.y / _cameraDimensions.y);

            return new Vector2
            {
                x = Mathf.Max(
                    1f - Mathf.Clamp01(percentages.x / _boundaryThreshold),
                    1f - Mathf.Clamp01((1f - percentages.x) / _boundaryThreshold)),
                y = Mathf.Max(
                    1f - Mathf.Clamp01(percentages.y / _boundaryThreshold),
                    1f - Mathf.Clamp01((1f - percentages.y) / _boundaryThreshold))
            };
        }
    }
}
