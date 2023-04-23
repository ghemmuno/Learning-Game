using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleKey : Items
{
    

    // Start is called before the first frame update
    void Start()
    {
        itemName = "simple_key";       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //FUNCTIONS
    //Use the item on an event
    public override bool useItem(NodeScript currentNode)
    {
        //attempt to use item on an interactable event
        //use currentNode's direction nodes to determine whether any of them contain an event
        //using the InteractableEvents' method matchItemAnd

        //unsuccessful
        return false;
    }
}
