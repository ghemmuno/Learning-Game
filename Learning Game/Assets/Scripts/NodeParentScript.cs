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
        /*for (int i = 0; i < children.Length; i++)
        {
            NodeScript child = children[i];
            //Debug.Log(child.name);
        }*/

        startNode.isStartingNode = true;
        endNode.isEndingNode = true;

        player.currentNode = startNode;
        player.goToCurrent();
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
        player.goToCurrent();
        if (player.holdingItem())
        {
            player.heldItem.resetItem();
            player.heldItem = null;
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
