using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskScipt : MonoBehaviour
{
    // Start is called before the first frame update
    public LibraryStoryline isTableAttached;

    public void FirstTask()
    {
        if (isTableAttached == true)
        {
            Debug.Log("asdasdsadsa");   
        }
    }
    
}
