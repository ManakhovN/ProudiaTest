using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

    Text text;
	void Start () {
        text = GetComponent<Text>();
        ISession session =  GameController.Instance.GetService<ISession>();
        session.OnScoreChanged += ChangeText;
        ChangeText(0);
	}

    private void ChangeText(int score)
    {
        text.text = score.ToString();
    }
}
