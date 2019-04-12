using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEye : BasicTracker {
    [SerializeField] Transform eyeBallHandler;
    public override void Refresh()
    {
        if (Target == null)
            return;
        eyeBallHandler.up = Target.position - transform.position; 
    }
}
