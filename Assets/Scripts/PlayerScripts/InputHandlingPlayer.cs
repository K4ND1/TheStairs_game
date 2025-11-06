using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandlingPlayer : MonoBehaviour
{
    [SerializeField] private PlayerParentScript _parentScript;

    // Input Variables
    internal float x_input_axis;
    internal float y_input_axis;

    private void Awake()
    {
        if (_parentScript == null) _parentScript = GetComponent<PlayerParentScript>();

    }

    internal void InputAndFlagControll()
    {
        // Get horizontal input
        x_input_axis = Input.GetAxisRaw("Horizontal");
        // Get vertical input
        y_input_axis = Input.GetAxisRaw("Vertical");

        if (_parentScript.currentPlatformCollider != null && y_input_axis < 0)
        {
            Physics2D.IgnoreCollision(_parentScript._playerCollider, _parentScript.currentPlatformCollider, true);

        }
        else if (_parentScript.currentPlatformCollider != null && _parentScript.CheckIfNotInPlatform())
        {
            Physics2D.IgnoreCollision(_parentScript._playerCollider, _parentScript.currentPlatformCollider, false);
        }


    }

}
