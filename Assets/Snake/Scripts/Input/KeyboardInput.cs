using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : BaseInput {
   
    public override void Update()
    {
        InputAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
