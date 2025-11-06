using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private PlayerParentScript _parentScript;

    // Movement Variables
    public float movement_speed = 7f;

    private void Awake()
    {
        if (_parentScript == null) _parentScript = GetComponent<PlayerParentScript>();

    }

    internal void MovementControll()
    {
        // Handle vertical movement on stairs
        if (_parentScript.onStairs)
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

    }
}
