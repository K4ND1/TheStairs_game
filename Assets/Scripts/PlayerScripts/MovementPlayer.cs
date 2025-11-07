using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    // GameObject Script references
    [SerializeField] private PlayerParentScript _parentScript;

    // Movement Variables
    public float movement_speed = 7f;


    private void Awake()
    {
        if (_parentScript == null) _parentScript = GetComponent<PlayerParentScript>();

    }// End of Awake

    internal void MovementControll()
    {
        // Handle vertical movement on stairs
        if (_parentScript._collisionScript.onStairs)
        {
            _parentScript._playerRb.velocity = new Vector2(_parentScript._playerRb.velocity.x, _parentScript._inputScript.y_input_axis * movement_speed * 0.5f);
            _parentScript._playerRb.gravityScale = 0f; // Disable gravity on stairs
        }
        else
        {
            _parentScript._playerRb.gravityScale = 1f; // Enable gravity when not on stairs

        }

        // Move the player based on input
        _parentScript._playerRb.velocity = new Vector2(_parentScript._inputScript.x_input_axis * movement_speed, _parentScript._playerRb.velocity.y);

    }// End of MovementControll


}// End of MovementPlayer class
