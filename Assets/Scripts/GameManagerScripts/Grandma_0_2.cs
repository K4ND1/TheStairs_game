using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Grandma_0_2 : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager; // Reference to GameManager script

    internal bool inThisScene = false; // Flag to check if this scene is loaded


    private void Awake()
    {
        if (_gameManager == null) GetComponent<GameManager>();
 
    }// End of Awake

    private void Update()
    {
        if (!inThisScene) return;


    }// End of Update



}
