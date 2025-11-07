using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentDorrFunctions : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private void Awake()
    {
        if (_gameManager == null) GetComponent<GameManager>();

    }

    internal void OpenDoor_02()
    {
        Debug.Log("Door 0_2 is now open.");
    }

    internal void OpenDoor_11()
    {
        Debug.Log("Door 1_1 is now open.");
    }

    internal void OpenDoor_12()
    {
        Debug.Log("Door 1_2 is now open.");
    }

    internal void OpenDoor_23()
    {
        Debug.Log("Door 2_3 is now open.");
    }

    internal void OpenDoor_31()
    {
        Debug.Log("Door 3_1 is now open.");
    }

    internal void OpenDoor_52()
    {
        Debug.Log("Door 5_2 is now open.");
    }
    
    internal void OpenDoor_53()
    {
        Debug.Log("Door 5_3 is now open.");
    }
    
    internal void OpenDoor_71()
    {
        Debug.Log("Door 7_1 is now open.");
    }

    internal void OpenDoor_73()
    {
        Debug.Log("Door 7_3 is now open.");
    }

    internal void OpenDoor_93()
    {
        Debug.Log("Door 9_3 is now open.");
    }
}// End of DifferentDorrFunctions class
