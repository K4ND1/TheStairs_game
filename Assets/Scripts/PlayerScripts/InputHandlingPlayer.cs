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

    // Input flags
    internal bool canOpenDoors = false;
    


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

        // Check for door opening input
        if (canOpenDoors)
        {
            if (Input.GetKey(KeyCode.E))
            {
                canOpenDoors = false;
                _parentScript._gameManager.TakeTriggerInput(_parentScript._currentDoorId, true);
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                canOpenDoors = false;
                _parentScript._gameManager.TakeTriggerInput(_parentScript._currentDoorId, false);
            }
        }




    }// End of InputAndFlagControll


}// End of InputHandlingPlayer class
