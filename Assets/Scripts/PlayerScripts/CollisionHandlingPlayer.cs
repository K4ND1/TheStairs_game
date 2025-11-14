using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandlingPlayer : MonoBehaviour
{
    [SerializeField] private PlayerParentScript _parentScript;

    [SerializeField] private SpriteRenderer _interactSign;

    // State Flags
    internal bool onStairs;


    private void Awake()
    {
        if (_parentScript == null) _parentScript = GetComponent<PlayerParentScript>();
        if (_interactSign == null) _interactSign = gameObject.GetComponentInChildren<SpriteRenderer>();

    }// End of Awake

    private void Start()
    {
        _interactSign.enabled = false;

    }// End of Start

    // Method to get current platform collider
    internal Collider2D GetCurrentPlatformCollider()
    {
        // Create an array to hold contact points 
        ContactPoint2D[] contacts = new ContactPoint2D[16];

        // Get the number of contacts
        int count = _parentScript._playerRb.GetContacts(contacts);


        // If no contacts, return an empty array
        if (count == 0) return null;

        // Create an array to hold the colliders
        Collider2D[] result = new Collider2D[count];

        // Populate the result array with colliders from contact points
        for (int i = 0; i < count; i++)
        {
            result[i] = contacts[i].collider;
        }

        Collider2D colliderToReturn = null;

        // Update current platform collider
        for (int i = 0; i < result.Length; i++)
        {
            if (result[i].CompareTag("Platform"))
            {
                colliderToReturn = result[i];
                break;
            }
        }

        return colliderToReturn;

    }// End of GetCurrentContactColliders

    internal bool CheckIfNotInPlatform()
    {
        bool result = true;
        Collider2D[] curr = Physics2D.OverlapBoxAll(_parentScript._playerCollider.bounds.center, _parentScript._playerCollider.bounds.size, 0f);

        for (int i = 0; i < curr.Length; i++)
        {
            if (curr[i].CompareTag("Platform"))
            {
                result = false;
            }
        }

        return result;

    }// End of CheckIfNotInPlatform

    // Trigger Methods
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Doors"))
        {
            _parentScript._inputScript.canOpenDoors = true;
            _parentScript._currentDoorId = other.name;

            _interactSign.enabled = true;
        }
    }// End of OnTriggerEnter2D

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
            _parentScript._playerRb.velocity = new Vector2(_parentScript._playerRb.velocity.x, 0f);
            onStairs = false;  // Reset the flag when the player exits the stairs
        }
        
        if (other.CompareTag("Doors"))
        {
            _parentScript._inputScript.canOpenDoors = false;
            _parentScript._currentDoorId = null;

            _interactSign.enabled = false;
        }

    }// End of OnTriggerExit2D


}// End of CollisionHandlingPlayer class
