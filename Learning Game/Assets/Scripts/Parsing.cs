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

    public string getUserInput()
    {
        return userInput.text;
    }

    public void showUserInputDebug()
    {
        //Debug.Log("User input: \n" + getUserInput());
        parse();
    }

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
        if (x.Equals("")) { }
        else if (x.Contains("moveLeft"))
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
        //new code from Mus
        else if (x.Contains("for"))
        {
            int loopNum = getIntParameters(parseParentheses(x));
            Debug.Log("Executing " + loopNum + " times");
            if (x.Contains("moveLeft"))
            {
                num = getIntParameters(parseParentheses(x));
                Debug.Log("Move Left " + num + " spaces");
                player.moveLeft(loopNum);
            }
            else if (x.Contains("moveRight"))
            {
                num = getIntParameters(parseParentheses(x));
                Debug.Log("Move Right " + num + " spaces");
                player.moveRight(loopNum);
            }
            else if (x.Contains("moveUp"))
            {
                num = getIntParameters(parseParentheses(x));
                Debug.Log("Move Up " + num + " spaces");
                player.moveUp(loopNum);

            }
            else if (x.Contains("moveDown"))
            {
                num = getIntParameters(parseParentheses(x));
                Debug.Log("Move Down " + num + " spaces");
                player.moveDown(loopNum);
            }

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






    //IENUMERATOR FOR GRADUAL MOVEMENT
    public void FunExeInput()
    {
        //Debug.Log("User input: \n" + getUserInput());
        StartCoroutine(FunParse());
    }
    IEnumerator FunParse()
    {
        nodeParent.resetPlayer();
        string input = getUserInput();
        string[] arr = input.Split('\n');
        parseParentheses(arr[0]);
        foreach (string line in arr)
        {
            Debug.Log("Parsing " + line);
            yield return StartCoroutine(FunMatch(line));
        }
    }

    IEnumerator FunMatch(string x)
    {
        int num = 1;
        string str = "";
        if (x.Equals("")) { }
        else if (x.Contains("moveLeft"))
        {
            num = getIntParameters(parseParentheses(x));
            Debug.Log("Move Left " + num + " spaces");
            yield return StartCoroutine(player.MoveL(num));
        }
        else if (x.Contains("moveRight"))
        {
            num = getIntParameters(parseParentheses(x));
            Debug.Log("Move Right " + num + " spaces");
            yield return StartCoroutine(player.MoveR(num));
        }
        else if (x.Contains("moveUp"))
        {
            num = getIntParameters(parseParentheses(x));
            Debug.Log("Move Up " + num + " spaces");
            yield return StartCoroutine(player.MoveU(num));
        }
        else if (x.Contains("moveDown"))
        {
            num = getIntParameters(parseParentheses(x));
            Debug.Log("Move Down " + num + " spaces");
            yield return StartCoroutine(player.MoveD(num));
        }
        else if (x.Contains("grabItem()"))
        {
            yield return StartCoroutine(player.GrabItem());
        }
        else if (x.Contains("useItem()"))
        {
            yield return StartCoroutine(player.UseItem());
        }
        else if (x.Contains("say"))
        {
            str = getStrParameters(parseParentheses(x));
            yield return StartCoroutine(player.Say(str));
        }
        //new code from Mus
        /*
        else if (x.Contains("for"))
        {
            int loopNum = getIntParameters(parseParentheses(x));
            Debug.Log("Executing " + loopNum + " times");
            if (x.Contains("moveLeft"))
            {
                num = getIntParameters(parseParentheses(x));
                Debug.Log("Move Left " + num + " spaces");
                player.moveLeft(loopNum);
            }
            else if (x.Contains("moveRight"))
            {
                num = getIntParameters(parseParentheses(x));
                Debug.Log("Move Right " + num + " spaces");
                player.moveRight(loopNum);
            }
            else if (x.Contains("moveUp"))
            {
                num = getIntParameters(parseParentheses(x));
                Debug.Log("Move Up " + num + " spaces");
                player.moveUp(loopNum);

            }
            else if (x.Contains("moveDown"))
            {
                num = getIntParameters(parseParentheses(x));
                Debug.Log("Move Down " + num + " spaces");
                player.moveDown(loopNum);
            }

        }*/
    }
}
