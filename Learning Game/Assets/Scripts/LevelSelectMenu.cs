using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{
    //total num of levels
    public int totalLevel = 0;

    //how many levels have been unlocked
    public int unlockedLevel = 1;

    private LevelButton[] levelButtons;

    //pages of levels available where total pages = total worlds
    private int totalPage = 0;
    private int page;
    private int pageItem = 6;

    public GameObject nextButton;
    public GameObject backButton;

    private void OnEnable()
    {
        levelButtons = GetComponentsInChildren<LevelButton>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    //page navigation
    public void ClickNext()
    {
        page++;
        Refresh();
    }
    public void ClickBack()
    {
        page--;
        Refresh();
    }

    public void Refresh()
    {
        totalPage = (totalLevel / pageItem);
        if(totalLevel % pageItem == 0)
        {
            totalPage--;
        }
        int index = page * pageItem;
        for(int i=0; i<levelButtons.Length; i++)
        {
            int level = index + i + 1;

            if(level <= totalLevel)
            {
                levelButtons[i].gameObject.SetActive(true);
                levelButtons[i].Setup(level, level <= unlockedLevel);
            }
            else
            {
                levelButtons[i].gameObject.SetActive(false);
            }
        }

        CheckButton();
    }

    private void CheckButton()
    {
        backButton.SetActive(page > 0);
        nextButton.SetActive(page < totalPage);
    }

    
}
