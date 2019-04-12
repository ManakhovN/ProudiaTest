using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : BaseInput, IInput {
    Vector2 inputAxis;
    Vector2 delta = Vector2.zero;

    bool fingerReleased = false;
    public override void Update () {
        if (Input.touchCount > 0)
        {
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    delta = Vector2.zero;
                    break;
                case TouchPhase.Ended:
                    InputAxis = delta;
                    delta = Vector2.zero;
                    fingerReleased = true;
                    break;
                case TouchPhase.Moved:
                    delta += Input.GetTouch(0).deltaPosition;
                    break;
            }
        }

        if (fingerReleased)
        {
            delta = InputAxis = Vector2.zero;
            fingerReleased = false;
        }
        
	}

    public override void Reset()
    {
        base.Reset();
        delta = Vector2.zero;
    }
}
