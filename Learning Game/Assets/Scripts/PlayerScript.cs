using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public NodeScript currentNode;
    private bool atEnd = false;
    public Items heldItem;
    public GameObject successMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        successMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNode.isEndingNode && atEnd == false)
        {
            Debug.Log("Successfully completed level!");
            atEnd = true;
            successMenu.SetActive(true);
        }

        /*
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveUp();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            moveDown();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            moveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            moveRight();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            grabItem();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            useItem();
        }*/
    }

    public bool holdingItem()
    {
        return heldItem != null ? true : false;
    }

    //NEEDS TO BE GRADUAL MOVEMENTS, NOT INSTANTANEOUS
    public void goToCurrent()
    {
        Debug.Log("Moving from " + this.gameObject.transform.position + " to " + this.currentNode.transform.position);
        this.gameObject.transform.position = this.currentNode.transform.position;
    }

    public void moveRight()
    {
        if (!atEnd)
        {
            if (currentNode.right != null && !currentNode.isEndingNode && currentNode.right.canVisit())
            {
                currentNode = currentNode.right;
                this.goToCurrent();
            }
            else
            {
                Debug.Log("Node right does not exist for current position." + " At end? " + currentNode.isEndingNode);
            }
        }
    }
    public void moveRight(int times)
    {
        for(int i = 0; i < times; i++)
        {
            moveRight();
        }
    }

    public void moveLeft()
    {
        if (!atEnd)
        {
            if (currentNode.left != null && !currentNode.isEndingNode && currentNode.left.canVisit())
            {
                currentNode = currentNode.left;
                this.goToCurrent();
            }
            else
            {
                Debug.Log("Node left does not exist for current position." + " At end? " + currentNode.isEndingNode);
            }
        }
    }
    public void moveLeft(int times)
    {
        for (int i = 0; i < times; i++)
        {
            moveLeft();
        }
    }

    public void moveUp()
    {
        if (!atEnd)
        {
            //Debug.Log((currentNode.up != null) + " " + (!currentNode.isEndingNode) + " " + (currentNode.up.canVisit()));
            if (currentNode.up != null && !currentNode.isEndingNode && currentNode.up.canVisit())
            {
                currentNode = currentNode.up;
                this.goToCurrent();
            }
            else
            {
                Debug.Log("Node up does not exist for current position." + " At end? " + currentNode.isEndingNode);
            }
        }
    }
    public void moveUp(int times)
    {
        for (int i = 0; i < times; i++)
        {
            moveUp();
        }
    }

    public void moveDown() 
    {
        if (!atEnd)
        {
            if (currentNode.down != null && !currentNode.isEndingNode && currentNode.down.canVisit())
            {
                currentNode = currentNode.down;
                this.goToCurrent();
            }
            else
            {
                Debug.Log("Node down does not exist for current position." + " At end? " + currentNode.isEndingNode);
            }
        }
    }
    public void moveDown(int times)
    {
        for (int i = 0; i < times; i++)
        {
            moveDown();
        }
    }


    public void grabItem()
    {
        if (currentNode.hasItem())
        {
            heldItem = currentNode.item;
            heldItem.onGrid = false;
            heldItem.isHeld = true;
            Debug.Log("You pick up the " + heldItem.itemName);
        }
        else
        {
            Debug.Log("There is no item to pick up.");
        }
    }

    public void useItem()
    {
        NodeScript eNode = currentNode.checkForEvent();
        Debug.Log(eNode == null);
        if (holdingItem() && eNode != null)
        {
            Debug.Log("Player is holding item and event is nearby");
            eNode.interactEvent.interact(heldItem);
            eNode.setVisit(true);
        } 
        else if(!holdingItem() && eNode != null)
        {
            Debug.Log("Player is not holding item and event is nearby");
            eNode.interactEvent.DoorMenu();
        }
        else
        {
            Debug.Log("Player not holding item or event is not nearby");
        }
    }

    public void say(string words)
    {
        Debug.Log("Say is called: " + words);
    }
}
