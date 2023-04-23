using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeParentScript : MonoBehaviour
{
    public PlayerScript player;
    private NodeScript[] children;
    public NodeScript startNode;
    public NodeScript endNode;

    // Start is called before the first frame update
    void Start()
    {
        NodeScript[] children = this.gameObject.GetComponentsInChildren<NodeScript>();
        /* debug printing
        for (int i = 0; i < children.Length; i++)
        {
            NodeScript child = children[i];
            //Debug.Log(child.name);
        }*/

        startNode.isStartingNode = true;
        endNode.isEndingNode = true;

        player.currentNode = startNode;

        //leave as an instantaneous teleport
        player.goToInstantly();

        //example
        /*player.moveUp(2);
        player.grabItem();
        player.moveUp(2);
        player.moveRight(4);
        player.moveDown(4);
        player.useItem();
        player.moveDown(2);
        player.moveLeft(4);
        player.moveRight(3);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetPlayer()
    {
        player.currentNode = startNode;
        player.goToInstantly();
        if (player.holdingItem())
        {
            player.heldItem.simpleKey.SetActive(true);
            player.heldItem.resetItem();
            player.heldItem = null;
            NodeScript temp = null;
            foreach(NodeScript child in children)
            {
                if(child != null)
                {
                    temp = child.checkForEvent();
                    if (temp != null)
                    {
                        temp.interactEvent.Reset();
                    }
                }
            }
        }
    }

    public void move(string direction)
    {
        switch (direction)
        {
            case "left": return;
            case "right": return;
            case "up": return;
            case "down": return;
        }
    }

}
