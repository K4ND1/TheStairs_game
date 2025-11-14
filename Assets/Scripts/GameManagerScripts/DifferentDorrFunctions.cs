using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifferentDorrFunctions : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private string[] DOOR_SCENE_NAMES = new string[] {"0_2", "1_1"};

    private void Awake()
    {
        if (_gameManager == null) GetComponent<GameManager>();

    }

    // E key --> open the door
    // Q key --> look through the peep hole

    internal void OpenDoor_02(string input_E_Q) // Dont consider input_E_Q for this door
    {
        SceneManager.LoadScene(DOOR_SCENE_NAMES[0], LoadSceneMode.Single);
    }

    internal void OpenDoor_11(string input_E_Q) // Consider input_E_Q for this door
    {
        SceneManager.LoadScene(DOOR_SCENE_NAMES[1] + input_E_Q, LoadSceneMode.Single);
    }

    internal void OpenDoor_12(string input_E_Q)
    {
        Debug.Log("Door 1_2 is now open.");
    }

    internal void OpenDoor_23(string input_E_Q)
    {
        Debug.Log("Door 2_3 is now open.");
    }

    internal void OpenDoor_31(string input_E_Q)
    {
        Debug.Log("Door 3_1 is now open.");
    }

    internal void OpenDoor_52(string input_E_Q)
    {
        Debug.Log("Door 5_2 is now open.");
    }
    
    internal void OpenDoor_53(string input_E_Q)
    {
        Debug.Log("Door 5_3 is now open.");
    }
    
    internal void OpenDoor_71(string input_E_Q)
    {
        Debug.Log("Door 7_1 is now open.");
    }

    internal void OpenDoor_73(string input_E_Q)
    {
        Debug.Log("Door 7_3 is now open.");
    }

    internal void OpenDoor_93(string input_E_Q)
    {
        Debug.Log("Door 9_3 is now open.");
    }


}// End of DifferentDorrFunctions class
