using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Vector3 offset; // Offset from the player's position
    [SerializeField] private float damping; // Damping factor for smooth movement

    private Transform _playerTransform; // Reference to the player's transform

    private Vector3 velocity = Vector3.zero; // Velocity reference for SmoothDamp

    private void Awake()
    {
        if (_playerTransform == null) _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
  
    }// End of Awake

    private void FixedUpdate()
    {
        // Calculate the target position with offset
        Vector3 targetPosition = _playerTransform.position + offset;
        targetPosition.z = transform.position.z; // Keep original z position

        // Smoothly move the camera towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);

    }// End of FixedUpdate


}// End of CameraScript class
