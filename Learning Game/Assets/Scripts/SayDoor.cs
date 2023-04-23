using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayDoor : InteractableEvents
{
    void Start()
    {
        eventName = "password_door";
        correctItem = "password";
    }
}
