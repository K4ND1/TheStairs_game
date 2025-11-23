using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    private string MAIN_SCENE_NAME = "mainGame_scene"; // Name of the main scene

    // Door scene script references
    [SerializeField] internal Grandma_0_2 _g02;


    internal string currentDoorsId = ""; // Store the current door id ( by game object name )
    internal bool isInDoorScene = false; // Flag to check if the player is in a door scene

    // Input handling variables
    internal bool canPressEsc = false;

    private void Awake()
    {
        // Get references to door scene scripts
        if (_g02 == null) _g02 = GetComponent<Grandma_0_2>();

    }// End of Awake

    private void Update()
    {
        InputController();

    }// End of Update

    public void OpenGiven(string doorsId, bool keyE_Q) // Strign doorsId --> Id of the door to open, bool keyE_Q --> If true, open door with E key, if false, open door with Q key
    {
        Debug.Log("Opening door ID: " + doorsId);

        // E key --> open the door
        // Q key --> look through the peep hole
        string inputKey = keyE_Q ? "E" : "Q"; // Determine the input key based on the boolean value

        // Switch case to call the appropriate door function based on the doorsId
        switch (doorsId)
        {
            case "0-2":
                _g02.inThisScene = true;
                SceneManager.LoadScene("0_2", LoadSceneMode.Single);
                break;

            default:
                Debug.LogWarning("Couldn't find the door by the ID: " + doorsId);
                break;

        }// End of switch


    }// End of TakeTriggerInput

    private void CloseGiven(string doorsId)
    {
        isInDoorScene = false;
        currentDoorsId = "";

        switch (doorsId)
        {
            case "0-2":
                _g02.inThisScene = false;
                SceneManager.LoadScene(MAIN_SCENE_NAME, LoadSceneMode.Single);
                break;

            default:
                Debug.LogWarning("Couldn't find the door by the ID: " + doorsId);
                break;

        }// End of switch
    }

    private void InputController()
    {
        // Handle input when in door scenes
        if (isInDoorScene)
        {
            if (canPressEsc && Input.GetKey(KeyCode.Escape))
            {
                canPressEsc = false;
                CloseGiven(currentDoorsId);
            }
        }

    }// End of InputController

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene sceneLoaded, LoadSceneMode loadMode)
    {
        if (sceneLoaded.name == MAIN_SCENE_NAME)
        {
            // Reset door scene flags when returning to the main scene
            isInDoorScene = false;
            currentDoorsId = "";
        }
        else
        {
            isInDoorScene = true;
            canPressEsc = true;
            currentDoorsId = "0-2";
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}// End of GameManager class
