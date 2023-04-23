using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Items : MonoBehaviour
{
    //VARIABLES
    //Distinguish item type, used to determine if an item can interact with an event
    public string itemName;
    public GameObject simpleKey;
    //Keep track of the interactions of an item
    public bool onGrid;
    public bool isHeld;
    public bool isUsed;


    //FUNCTIONS
    //Use the item on an event
    abstract public bool useItem(NodeScript currentNode);

    //Debug: the current progress of the item according to onGrid, isHeld, isUsed;
    public string progress()
    {
        if(onGrid) { return "grid"; }
        if(isHeld) { return "held"; }
        if(isUsed) { return "used"; }
        else { return "error"; }
    }

    public void resetItem()
    {
        onGrid = true;
        isHeld = false;
        isUsed = false;
    }
}
