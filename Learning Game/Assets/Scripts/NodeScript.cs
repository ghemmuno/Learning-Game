using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public NodeScript down;
    public NodeScript up;
    public NodeScript left;
    public NodeScript right;

    public Items item;

    public InteractableEvents interactEvent;

    public bool isStartingNode = false;
    public bool isEndingNode = false;
    protected bool visitable = true;

    // Start is called before the first frame update
    void Start()
    {
        if (hasInteractEvent())
        {
            setVisit(false);
        }
        if (isInvalid())
        {
            item = null;
            interactEvent = null;
            setVisit(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isInvalid()
    {
        if(hasItem() && hasInteractEvent())
        {
            Debug.Log("INVALID NODE: HAS BOTH ITEM AND EVENT.");
            return true;
        }
        return false;
    }

    public bool hasItem()
    {
        return item != null; 
    }

    public bool hasInteractEvent()
    {
        return interactEvent != null;
    }

    public bool canVisit()
    {
        return visitable;
    }
    public void setVisit(bool set)
    {
        visitable = set;
    }

    public NodeScript checkForEvent()
    {
        if (up != null && up.hasInteractEvent())
        {
            return up;
        }
        else if (down!= null && down.hasInteractEvent())
        {
            return down;
        }
        else if (left != null && left.hasInteractEvent())
        {
            return left;
        }
        else if (right != null && right.hasInteractEvent())
        {
            return right;
        }
        else
        {
            return null;
        }
    }
}
