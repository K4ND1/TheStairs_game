using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerParentScript : MonoBehaviour
{
    // GameObject Script references
    [SerializeField] internal InputHandlingPlayer _inputScript;
    [SerializeField] internal MovementPlayer _movementScript;
    
    // References
    internal Rigidbody2D _playerRb;
    internal Collider2D _playerCollider;
    internal Collider2D currentPlatformCollider;

    // State Flags
    internal bool onStairs;


    private void Awake()
    {
        // Initialize component references
        if (_inputScript == null) _inputScript = GetComponent<InputHandlingPlayer>();
        if (_movementScript == null) _movementScript = GetComponent<MovementPlayer>();

        // Initialize Rigidbody2D and Collider2D
        _playerRb = GetComponent<Rigidbody2D>();
        _playerCollider = GetComponent<Collider2D>();

    }// End of Awake

    // Loop Methods
    private void Update()
    {
        // Handle input and flags
        _inputScript.InputAndFlagControll();


        // Update current platform collider
        for (int i = 0; i < GetCurrentContactColliders().Length; i++)
        {
            if (GetCurrentContactColliders()[i].CompareTag("Platform"))
            {
                currentPlatformCollider = GetCurrentContactColliders()[i];
            }
        }

    }// End of Update

    private void FixedUpdate()
    {
        // Handle movement
        _movementScript.MovementControll();

    }// End of FixedUpdate


    // Trigger and collision methods
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Stairs"))
        {
            onStairs = true; // Set the flag to indicate the player is on stairs
        }

    }// End of OnTriggerStay2D

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Stairs"))
        {
            // Reset vertical velocity when exiting stairs
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, 0f);
            onStairs = false;  // Reset the flag when the player exits the stairs
        }

    }// End of OnTriggerExit2D

    public Collider2D[] GetCurrentContactColliders()
    {
        // Create an array to hold contact points 
        ContactPoint2D[] contacts = new ContactPoint2D[16];

        // Get the number of contacts
        int count = _playerRb.GetContacts(contacts);
        

        // If no contacts, return an empty array
        if (count == 0) return System.Array.Empty<Collider2D>();

        // Create an array to hold the colliders
        Collider2D[] result = new Collider2D[count];

        // Populate the result array with colliders from contact points
        for (int i = 0; i < count; i++)
        {
            result[i] = contacts[i].collider;
        }

        return result;

    }// End of GetCurrentContactColliders

    public bool CheckIfNotInPlatform()
    {
        bool result = true;
        Collider2D[] curr = Physics2D.OverlapBoxAll(_playerCollider.bounds.center, _playerCollider.bounds.size, 0f);
        
        for (int i = 0; i < curr.Length; i++)
        {
            if (curr[i].CompareTag("Platform"))
            {
                result = false;
            }
        }

        return result;

    }// End of CheckIfNotInPlatform


}// End of PlayerParentScript class
