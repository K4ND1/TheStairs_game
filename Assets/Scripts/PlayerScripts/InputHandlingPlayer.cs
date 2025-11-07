using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandlingPlayer : MonoBehaviour
{
    // GameObject Script references
    [SerializeField] private PlayerParentScript _parentScript;

    // Input Variables
    internal float x_input_axis;
    internal float y_input_axis;


    private void Awake()
    {
        if (_parentScript == null) _parentScript = GetComponent<PlayerParentScript>();

    }// End of Awake

    internal void InputAndFlagControll()
    {
        // Get horizontal input
        x_input_axis = Input.GetAxisRaw("Horizontal");
        // Get vertical input
        y_input_axis = Input.GetAxisRaw("Vertical");

        if (_parentScript._currentPlatformCollider != null && y_input_axis < 0)
        {
            Physics2D.IgnoreCollision(_parentScript._playerCollider, _parentScript._currentPlatformCollider, true);

        }
        else if (_parentScript._currentPlatformCollider != null && _parentScript._collisionScript.CheckIfNotInPlatform())
        {
            Physics2D.IgnoreCollision(_parentScript._playerCollider, _parentScript._currentPlatformCollider, false);
        }

    }// End of InputAndFlagControll


}// End of InputHandlingPlayer class
