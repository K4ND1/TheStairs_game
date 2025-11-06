using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;

    private Transform _playerTransform;

    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        if (_playerTransform == null) _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = _playerTransform.position + offset;
        targetPosition.z = transform.position.z; // Keep original z position

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);
    }
}
