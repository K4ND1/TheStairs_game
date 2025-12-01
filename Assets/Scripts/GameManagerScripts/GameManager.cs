using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class  GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _MAIN_SCENE_ROOT;

    private string MAIN_SCENE_NAME = "mainGame_scene"; // Name of the main scene

    // Door scene script references
    [SerializeField] internal Grandma_0_2 _g02;

    // References to objects that position needs to be preserved
    private GameObject _player;
    private Vector3 _playerPosition;
    private GameObject _camera;
    private Vector3 _cameraPosition;

    internal bool isInDoorScene = false; // Flag to check if the player is in a door scene

    // Input handling variables
    internal bool canPressEsc = false;
    public string currentDoorsId_INSIDE = ""; // ID of the current door scene

    #region Basic Unity Methods
    private void Awake()
    {
        // Get references to door scene scripts
        if (_g02 == null) _g02 = GetComponent<Grandma_0_2>();

        if (_MAIN_SCENE_ROOT == null)
        {
            _MAIN_SCENE_ROOT = GameObject.Find("ROOT");
        }

    }// End of Awake

    private void Update()
    {
        InputController();

    }// End of Update

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }// End of OnEnable

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }// End of OnDisable
    #endregion Basic Unity Methods

    #region Scene Management Methods
    public void OpenGiven(string doorsId, bool keyE_Q) // Strign doorsId --> Id of the door to open, bool keyE_Q --> If true, open door with E key, if false, open door with Q key
    {
        Debug.Log("Opening door ID: " + doorsId);

        // E key --> open the door
        // Q key --> look through the peep hole
        string inputKey = keyE_Q ? "E" : "Q"; // Determine the input key based on the boolean value

        // Switch case to call the appropriate door function based on the doorsId
        switch (doorsId)
        {
            case "0_2":
                SceneManager.LoadScene("0_2", LoadSceneMode.Additive);
                break;

            default:
                Debug.LogWarning("Couldn't find the door by the ID: " + doorsId);
                break;

        }// End of switch


    }// End of OpenGiven

    private void OnSceneLoaded(Scene sceneLoaded, LoadSceneMode loadMode)
    {
        if (sceneLoaded.name == MAIN_SCENE_NAME)
        {
            _MAIN_SCENE_ROOT.SetActive(true);
            isInDoorScene = false;
        }
        else
        {
            _MAIN_SCENE_ROOT.SetActive(false);
            isInDoorScene = true;
            canPressEsc = true;
        }

    }// End of OnSceneLoaded

    private void CloseGiven(string doorsId)
    {
        isInDoorScene = false;
        _MAIN_SCENE_ROOT.SetActive(true);
        SceneManager.UnloadSceneAsync(doorsId);

    }// End of CloseGiven

    #endregion Scene Management Methods

    private void InputController()
    {
        // Handle input when in door scenes
        if (isInDoorScene)
        {
            if (canPressEsc && Input.GetKey(KeyCode.Escape))
            {
                canPressEsc = false;
                CloseGiven(currentDoorsId_INSIDE);
            }
        }

    }// End of InputController

}// End of GameManager class
