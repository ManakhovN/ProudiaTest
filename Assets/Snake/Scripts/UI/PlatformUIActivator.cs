using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUIActivator : MonoBehaviour {
    [SerializeField] GameObject touch;
    [SerializeField] GameObject keyBoard;
    public void Start()
    {
        var session = GameController.Instance.GetService<ISession>();
        session.OnGameReset += ShowPanel;
        ShowPanel();
    }

    private void ShowPanel()
    {
        if (Input.touchSupported)
            touch.SetActive(true);
        else
            keyBoard.SetActive(true);
    }
}
