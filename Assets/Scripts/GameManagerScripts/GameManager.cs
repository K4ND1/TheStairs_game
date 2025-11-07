using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] internal DifferentDorrFunctions _doorsFuncs;

    private void Awake()
    {
        if (_doorsFuncs == null) _doorsFuncs = GetComponent<DifferentDorrFunctions>();

    }// End of Awake

    public void TakeTriggerInput(string doorsId)
    {
        Debug.Log("Triggered door with ID: " + doorsId);

        switch (doorsId)
        {
            case "0-2":
                _doorsFuncs.OpenDoor_02();
                break;

            case "1-1":
                _doorsFuncs.OpenDoor_11();
                break;

            case "1-2":
                _doorsFuncs.OpenDoor_12();
                break;

            case "2-3":
                _doorsFuncs.OpenDoor_23();
                break;

            case "3-1":
                _doorsFuncs.OpenDoor_31();
                break;

            case "5-2":
                _doorsFuncs.OpenDoor_52();
                break;

            case "5-3":
                _doorsFuncs.OpenDoor_53();
                break;

            case "7-1":
                _doorsFuncs.OpenDoor_71();
                break;

            case "7-3":
                _doorsFuncs.OpenDoor_73();
                break;

             case "9-3":
                _doorsFuncs.OpenDoor_93();
                break;
             
            default:
                Debug.LogWarning("No door function found for ID: " + doorsId);
                break;

        }// End of switch


    }// End of TakeTriggerInput


}// End of GameManager class
