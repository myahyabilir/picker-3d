using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject tapToPlay;
    [SerializeField] private GameObject fail;
    [SerializeField] private GameObject success;
    
    [Header("Top Hud")]
    [SerializeField] private TextMeshProUGUI levelText;

    private void OnEnable()
    {
        Events.onLevelFailed += ExpandFailPanel;
        Events.onLevelFinished += ExpandSuccessScreen;
        SceneManager.sceneLoaded += AdjustLevelText;
    }

    private void OnDisable()
    {
        Events.onLevelFailed -= ExpandFailPanel;
        Events.onLevelFinished -= ExpandSuccessScreen;
        SceneManager.sceneLoaded -= AdjustLevelText;
    }

    private void AdjustLevelText(Scene arg0, LoadSceneMode arg1)
    {
        levelText.text = "Level 2";
    }


    public void StartTheGame()
    {
        Events.onLevelStarted?.Invoke();
    }
    public void ShrinkTapToPlayAndStart()
    {
        tapToPlay.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() => Events.onLevelStarted?.Invoke());
    }

    public void ExpandSuccessScreen()
    {
        success.transform.DOScale(new Vector3(1.01f, 1.01f, 1f), 0.5f);
    }
    
    public void ShrinkSuccessScreenAndProceedToNextLevel()
    {
        success.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() => Events.onProceedToNextLevel?.Invoke());
    }

    public void ExpandFailPanel()
    {
        fail.transform.DOScale(new Vector3(1.01f, 1.01f, 1f), 0.5f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
