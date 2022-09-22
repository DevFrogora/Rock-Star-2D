using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image victoryImage;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        GameManager.instance.scoreUpdate += Instance_scoreUpdate;
        GameManager.instance.gameStart += Instance_gameStart;
        GameManager.instance.gameEnd += Instance_gameEnd;
    }

    private void Instance_gameEnd()
    {
        victoryImage.gameObject.SetActive(true);
    }

    private void Instance_gameStart()
    {
        victoryImage.gameObject.SetActive(false);
    }

    private void Instance_scoreUpdate(int obj)
    {
        scoreText.text = "Score : " + obj.ToString();
    }

    private void OnDestroy()
    {
        GameManager.instance.gameStart -= Instance_gameStart;
        GameManager.instance.gameEnd -= Instance_gameEnd;
        GameManager.instance.scoreUpdate -= Instance_scoreUpdate;
    }
}
