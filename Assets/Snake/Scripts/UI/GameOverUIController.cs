using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour {
    [SerializeField] GameObject panel;
    [SerializeField] Button resetButton;
    ISession session;
	void Start () {
        session = GameController.Instance.GetService<ISession>();
        session.OnGameOver += ()=>panel.SetActive(true);
        resetButton.onClick.AddListener(ResetButtonClicked);
	}

    private void ResetButtonClicked()
    {
        session.ResetGame();
        panel.SetActive(false);
    }
}
