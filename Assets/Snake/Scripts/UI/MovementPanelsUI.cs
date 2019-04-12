using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPanelsUI : MonoBehaviour {

    public void Start()
    {
        GameController gameController = GameController.Instance;
        gameController.GetService<IInput>().OnInputChange+= (Vector3 move)=> { gameObject.SetActive(false);  };
    }
}
