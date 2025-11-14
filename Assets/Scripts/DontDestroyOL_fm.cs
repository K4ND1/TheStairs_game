using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOL_fm : MonoBehaviour
{
    // Script that can be used on multiple Game Objects to make them persistent across scenes

    private static GameObject[] persistentObjects = new GameObject[100]; // Array to hold references to persistent objects
    public int objectIndex; // Unique identifier for the object


    private void Awake()
    {
        if (persistentObjects[objectIndex] == null) // If no object is stored at this index, store this one
        {
            persistentObjects[objectIndex] = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (persistentObjects[objectIndex] != this.gameObject) // If another object is already stored, destroy this one
        {
            Destroy(this.gameObject);
        }

    }// End of Awake


}// End of DontDestroyOL_fm class
