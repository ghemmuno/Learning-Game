using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public Image lockSprite;

    public TMP_Text levelText;

    private int level = 0;

    private Button button;

    private Image image;

    void Start()
    {
        //lockSprite.gameObject.SetActive(false);
    }

        private void OnEnable()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();

    }

    public void Setup(int level, bool isUnlock)
    {
        this.level = level;
        levelText.text = "Level " + level.ToString();
        if (isUnlock)
        {
            lockSprite.gameObject.SetActive(false);
            button.enabled = true;
            levelText.gameObject.SetActive(true);
        }
        else
        {
            lockSprite.gameObject.SetActive(true);
            button.enabled = false;
            levelText.gameObject.SetActive(false);
        }
    }

    public void OnClick()
    {
        SceneManager.LoadScene(level + 1);
    }
}
