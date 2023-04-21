using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Parsing : MonoBehaviour
{
    public TMP_Text userInput;
    public PlayerScript player;
    public NodeParentScript nodeParent;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showUserInputDebug()
    {
        //Debug.Log("User input: \n" + getUserInput());
        parse();
    }

    public string getUserInput()
    {
        return userInput.text;
    }

    //so

    void parse()
    {
        nodeParent.resetPlayer();
        string input = getUserInput();
        string[] arr = input.Split('\n');
        parseParentheses(arr[0]);
        foreach(string line in arr)
        {
            Debug.Log("Parsing " + line);
            funMatch(line);
        }
    }

    void funMatch(string x)
    {
        int num = 1;
        string str = "";
        if (x.Contains("moveLeft"))
        {
            num = getIntParameters(parseParentheses(x));
            Debug.Log("Move Left " + num + " spaces");
            player.moveLeft(num);
        }
        else if (x.Contains("moveRight"))
        {
            num = getIntParameters(parseParentheses(x));
            Debug.Log("Move Right " + num + " spaces");
            player.moveRight(num);
        }
        else if (x.Contains("moveUp"))
        {
            num = getIntParameters(parseParentheses(x));
            Debug.Log("Move Up " + num + " spaces");
            player.moveUp(num);
        }
        else if (x.Contains("moveDown"))
        {
            num = getIntParameters(parseParentheses(x));
            Debug.Log("Move Down " + num + " spaces");
            player.moveDown(num);
        }
        else if (x.Contains("grabItem()"))
        {
            player.grabItem();
        }
        else if (x.Contains("useItem()"))
        {
            player.useItem();
        }
        else if (x.Contains("say"))
        {
            str = getStrParameters(parseParentheses(x));
            player.say(str);
        }
    }

    string parseParentheses(string x)
    {
        //get parameter inside parentheses, make sure there are parentheses
        if(x.Contains("("))
        {
            x = x.Split('(', ')')[1];
            Debug.Log(x);
            return x;
        }
        return "";
    }

    int getIntParameters(string x)
    {
        if(x.Length > 0)
        {
            Debug.Log(x);
            return int.Parse(x);
        }
        return 1;
    }
    string getStrParameters(string x)
    {
        if(x.Length != 0)
        {
            if (x.StartsWith("\"") && x.EndsWith("\""))
            {
                x = x.Split('\"', '\"')[1];
                Debug.Log(x);
                return x;
            }
            return "";
        }
        return "";
    }
}
