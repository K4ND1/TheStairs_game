using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerParentScript : MonoBehaviour
{
    // GameObject Script references
    [SerializeField] internal InputHandlingPlayer _inputScript;
    [SerializeField] internal MovementPlayer _movementScript;
    [SerializeField] internal CollisionHandlingPlayer _collisionScript;

    // Game Manager reference
    [SerializeField] internal GameManager _gameManager;

    // References
    internal Rigidbody2D _playerRb;
    internal Collider2D _playerCollider;
    internal Collider2D _currentPlatformCollider;


    private void Awake()
    {
        // Initialize component references
        if (_inputScript == null) _inputScript = GetComponent<InputHandlingPlayer>();
        if (_movementScript == null) _movementScript = GetComponent<MovementPlayer>();
        if (_collisionScript == null) _collisionScript = GetComponent<CollisionHandlingPlayer>();

        if (_gameManager == null) _gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();  

        // Initialize Rigidbody2D and Collider2D
        _playerRb = GetComponent<Rigidbody2D>();
        _playerCollider = GetComponent<Collider2D>();

    }// End of Awake

    // Loop Methods
    private void Update()
    {
        // Handle input and flags
        _inputScript.InputAndFlagControll();
        _currentPlatformCollider = _collisionScript.GetCurrentPlatformCollider();


    }// End of Update

    private void FixedUpdate()
    {
        // Handle movement
        _movementScript.MovementControll();

    }// End of FixedUpdate


}// End of PlayerParentScript class
