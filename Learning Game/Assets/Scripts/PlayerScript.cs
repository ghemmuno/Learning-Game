using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

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
        //wasd debugging movement
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
        }
        */
        Visuals();
    }

    public int directionX = 1;
    public int directionZ = 0;
    private void setDirXZ(int x, int z)
    {
        directionX = x;
        directionZ = z;
    }

    //rotation
    private void Visuals()
    {
        float rotSpeed = 5f;
        Vector3 lookAt = currentNode.transform.position;
        lookAt.x += directionX;
        lookAt.z += directionZ;
        Vector3 dir = lookAt - transform.position;
        Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rotSpeed * Time.deltaTime);
        rot.x = 0;
        rot.z = 0;
        transform.rotation = rot;
    }


    public bool holdingItem()
    {
        return heldItem != null ? true : false;
    }

    //will be gradual movement
    //public IEnumerator goToCurrent()
    //yield return 
    public IEnumerator goToCurrent()
    {
        Debug.Log("Moving from " + gameObject.transform.position + " to " + currentNode.transform.position);
        yield return StartCoroutine(MoveObject(gameObject.transform.position, currentNode.transform.position, 0.5f));
    }

    float lerpDuration = 0.5f;
    bool rotating = false;
    private IEnumerator Rotate90()
    {
        rotating = true;
        float timeElapsed = 0;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, 90, 0);
        while (timeElapsed < lerpDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;
        rotating = false;
    }

    IEnumerator MoveObject(Vector3 source, Vector3 target, float overTime)
    {
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            transform.position = Vector3.Lerp(source, target, (Time.time - startTime) / overTime);
            yield return null;
        }
        transform.position = target;
    }

    public IEnumerator MoveR()
    {
        setDirXZ(0, -1);
        if (!atEnd)
        {
            if (currentNode.right != null && !currentNode.isEndingNode && currentNode.right.canVisit())
            {
                currentNode = currentNode.right;
                yield return StartCoroutine(this.goToCurrent());
            }
            else
            {
                Debug.Log("Node right does not exist for current position." + " At end? " + currentNode.isEndingNode);
            }
        }
    }
    public IEnumerator MoveR(int times)
    {
        //yield return StartCoroutine(Rotate90());
        for (int i = 0; i < times; i++)
        {
            yield return StartCoroutine(MoveR());
        }
    }

    public IEnumerator MoveL()
    {
        setDirXZ(0, 1);
        if (!atEnd)
        {
            if (currentNode.left != null && !currentNode.isEndingNode && currentNode.left.canVisit())
            {
                currentNode = currentNode.left;
                yield return StartCoroutine(this.goToCurrent());
            }
            else
            {
                Debug.Log("Node left does not exist for current position." + " At end? " + currentNode.isEndingNode);
            }
        }
    }
    public IEnumerator MoveL(int times)
    {
        //yield return StartCoroutine(Rotate90());
        for (int i = 0; i < times; i++)
        {
            yield return StartCoroutine(MoveL());
        }
    }

    public IEnumerator MoveU()
    {
        setDirXZ(1, 0);
        if (!atEnd)
        {
            //Debug.Log((currentNode.up != null) + " " + (!currentNode.isEndingNode) + " " + (currentNode.up.canVisit()));
            if (currentNode.up != null && !currentNode.isEndingNode && currentNode.up.canVisit())
            {
                currentNode = currentNode.up;
                yield return StartCoroutine(this.goToCurrent());
            }
            else
            {
                Debug.Log("Node up does not exist for current position." + " At end? " + currentNode.isEndingNode);
            }
        }
    }
    public IEnumerator MoveU(int times)
    {
        //yield return StartCoroutine(Rotate90());
        for (int i = 0; i < times; i++)
        {
            yield return StartCoroutine(MoveU());
        }
    }

    public IEnumerator MoveD()
    {
        setDirXZ(-1, 0);
        if (!atEnd)
        {
            //yield return StartCoroutine(LookAt());
            if (currentNode.down != null && !currentNode.isEndingNode && currentNode.down.canVisit())
            {
                currentNode = currentNode.down;
                yield return StartCoroutine(this.goToCurrent());
            }
            else
            {
                Debug.Log("Node down does not exist for current position." + " At end? " + currentNode.isEndingNode);
            }
        }
    }
    public IEnumerator MoveD(int times)
    {
        //yield return StartCoroutine(Rotate90());
        for (int i = 0; i < times; i++)
        {
            yield return StartCoroutine(MoveD());
        }
    }

    public IEnumerator GrabItem()
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
        yield return new WaitForSeconds(0.1f);
    }

    public IEnumerator UseItem()
    {
        NodeScript eNode = currentNode.checkForEvent();
        Debug.Log(eNode == null);
        if (holdingItem() && eNode != null)
        {
            Debug.Log("Player is holding item and event is nearby");
            eNode.interactEvent.interact(heldItem.itemName);
            eNode.setVisit(true);
        }
        else
        {
            Debug.Log("Player not holding item or event is not nearby");
        }
        yield return new WaitForSeconds(0.1f);
    }

    public IEnumerator Say(string words)
    {
        Debug.Log("Say is called: " + words);
        NodeScript eNode = currentNode.checkForEvent();

        if (eNode != null)
        {
            Debug.Log("Player is holding item and event is nearby");
            eNode.interactEvent.interact(words);
            eNode.setVisit(true);
        }
        else if (eNode == null)
        {
            Debug.Log("No event is nearby");
            eNode.interactEvent.DoorMenu();
        }
        else
        {
            Debug.Log("Password was incorrect");
        }
        yield return new WaitForSeconds(0.1f);
    }



















    //ORIGINAL, TELEPORTATION IMPLEMENTATION
    public void goToInstantly()
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
                this.goToInstantly();
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
                this.goToInstantly();
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
                this.goToInstantly();
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
                this.goToInstantly();
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
            heldItem.simpleKey.SetActive(false);
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
        //Debug.Log(eNode == null);
        if (holdingItem() && eNode != null)
        {
            Debug.Log("Player is holding item and event is nearby");
            eNode.interactEvent.interact(heldItem.itemName);
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
        NodeScript eNode = currentNode.checkForEvent();
        
        if (eNode != null)
        {
            Debug.Log("Player is holding item and event is nearby");
            eNode.interactEvent.interact(words);
            eNode.setVisit(true);
        }
        else if (eNode == null)
        {
            Debug.Log("No event is nearby");
            eNode.interactEvent.DoorMenu();
        }
        else
        {
            Debug.Log("Password was incorrect");
        }
    }
}
