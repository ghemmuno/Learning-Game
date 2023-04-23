using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableEvents : MonoBehaviour
{
    //VARIABLES
    //Distinguish event type, used to determine if an item can interact with an event
    public string eventName;

    //Define the correct item name required to interact with the event
    public string correctItem;

    //Keep track of the interactions with an event
    public bool isClosed = true;

    public GameObject doorMenu;

    public void Reset()
    {
        isClosed = true;
    }

    //FUNCTIONS
    //Use the input item on this event, make sure the item is the correct one
    public void interact(string key)
    {
        if(matchItemAndEvent(key) && isClosed)
        {
            isClosed = true;
            Debug.Log("The door opens.");
        }
        else if (!isClosed)
        {
            Debug.Log("Door is already open.");
        }
        else if(isClosed) 
        {
            doorMenu.SetActive(true);
        }
    }
    
    public void DoorMenu(){
        doorMenu.SetActive(true);
    }

    //Match the item intended to be used on an event
    public bool matchItemAndEvent(string key)
    {
        if(key.Equals(correctItem))
        {
            Debug.Log("Key matches door.");
            return true;
        }
        Debug.Log("Key does not match door.");
        return false;
    }

    //Debug: the current state of the event according to isClosed
    public string state()
    {
        if (isClosed)
        {
            return "closed";
        }
        else
        {
            return "open";
        }
    }
}
