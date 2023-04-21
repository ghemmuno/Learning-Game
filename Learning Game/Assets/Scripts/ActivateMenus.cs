using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMenus : MonoBehaviour
{
    public GameObject hints;
    public GameObject lesson;
    public GameObject locked;

    public void setActive()
    {
        gameObject.SetActive(true);
    }

    public void setInactive()
    {
        gameObject.SetActive(false);
    }

    public void setMenuActive(string menu)
    {
        if (menu.Equals("hints"))
        {
            hints.SetActive(true);
        }
        if (menu.Equals("lesson"))
        {
            lesson.SetActive(true);
        }
        if (menu.Equals("locked"))
        {
            locked.SetActive(true);
        }
    }

    public void setMenuInactive(string menu)
    {
        if (menu.Equals("hints"))
        {
            hints.SetActive(false);
        }
        if (menu.Equals("lesson"))
        {
            lesson.SetActive(false);
        }
        if (menu.Equals("locked"))
        {
            locked.SetActive(false);
        }
    }
}
