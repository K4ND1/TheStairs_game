using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerParentScript : MonoBehaviour
{
    // Movement Variables
    public float movement_speed = 10f;
    
    // Input Variables
    private float x_input_axis;
    private float y_input_axis;

    // References
    private Rigidbody2D _playerRb;
    private Collider2D _playerCollider;
    private Collider2D currentPlatformCollider;

    // State Flags
    private bool onStairs;
    private bool platformCollisionDisabled = true;



    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        InputAndFlagControll();

        for (int i = 0; i < GetCurrentContactColliders().Length; i++)
        {
            if (GetCurrentContactColliders()[i].CompareTag("Platform"))
            {
                currentPlatformCollider = GetCurrentContactColliders()[i];
            }
             
        }

        
    }

    private void FixedUpdate()
    {
        MovementControll();

    }

    private void InputAndFlagControll()
    {
        // Get horizontal input
        x_input_axis = Input.GetAxisRaw("Horizontal");
        // Get vertical input
        y_input_axis = Input.GetAxisRaw("Vertical");

        if (currentPlatformCollider != null && y_input_axis < 0 && !platformCollisionDisabled)
        {
            Physics2D.IgnoreCollision(_playerCollider, currentPlatformCollider, true);
            platformCollisionDisabled = true;

        }
        else if (currentPlatformCollider != null && CheckIfNotInPlatform() && platformCollisionDisabled)
        {
            Physics2D.IgnoreCollision(_playerCollider, currentPlatformCollider, false);
            platformCollisionDisabled = false;
        }


    }

    private void MovementControll()
    {
        // Handle vertical movement on stairs
        if (onStairs)
        {
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, y_input_axis * movement_speed * 0.5f);
            _playerRb.gravityScale = 0f; // Disable gravity on stairs
        }
        else
        {
            _playerRb.gravityScale = 1f; // Enable gravity when not on stairs

        }


        // Move the player based on input
        _playerRb.velocity = new Vector2(x_input_axis * movement_speed, _playerRb.velocity.y);

    }

    // Trigger and collision methods
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Stairs"))
        {
            onStairs = true; // Set the flag to indicate the player is on stairs
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Stairs"))
        {
            // Reset vertical velocity when exiting stairs
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, 0f);
            onStairs = false;  // Reset the flag when the player exits the stairs
        }
    }

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
    }

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
    }

}
