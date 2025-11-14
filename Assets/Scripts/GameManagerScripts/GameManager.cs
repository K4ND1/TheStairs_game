using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] internal DifferentDorrFunctions _doorsFuncs; // Reference to DifferentDorrFunctions script

    private bool isInDoorScene = false; // Flag to check if the player is in a door scene
    private string currentDoorSceneName = ""; // Store the current door scene name

    private void Awake()
    {
        if (_doorsFuncs == null) _doorsFuncs = GetComponent<DifferentDorrFunctions>();

    }// End of Awake

    public void TakeTriggerInput(string doorsId, bool keyE_Q) // Strign doorsId --> Id of the door to open, bool keyE_Q --> If true, open door with E key, if false, open door with Q key
    {
        // E key --> open the door
        // Q key --> look through the peep hole

        isInDoorScene = true; // Set the flag to true as we are in a door scene

        string inputKey = keyE_Q ? "E" : "Q"; // Determine the input key based on the boolean value

        // Switch case to call the appropriate door function based on the doorsId
        switch (doorsId)
        {
            case "0-2":
                _doorsFuncs.OpenDoor_02(inputKey);
                break;

            case "1-1":
                _doorsFuncs.OpenDoor_11(inputKey);
                break;

            case "1-2":
                _doorsFuncs.OpenDoor_12(inputKey);
                break;

            case "2-3":
                _doorsFuncs.OpenDoor_23(inputKey);
                break;

            case "3-1":
                _doorsFuncs.OpenDoor_31(inputKey);
                break;

            case "5-2":
                _doorsFuncs.OpenDoor_52(inputKey);
                break;

            case "5-3":
                _doorsFuncs.OpenDoor_53(inputKey);
                break;

            case "7-1":
                _doorsFuncs.OpenDoor_71(inputKey);
                break;

            case "7-3":
                _doorsFuncs.OpenDoor_73(inputKey);
                break;

             case "9-3":
                _doorsFuncs.OpenDoor_93(inputKey);
                break;
             
            default:
                Debug.LogWarning("No door function found for ID: " + doorsId);
                break;

        }// End of switch


    }// End of TakeTriggerInput


}// End of GameManager class
