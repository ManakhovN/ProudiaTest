using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMouth : BasicTracker {

    [SerializeField] Transform mouth;
    public void Awake()
    {
        if (mouth == null)
            mouth = transform;
    }

    public override void Refresh()
    {
        if (Target == null)
            return; 
        float size = (Target.position - mouth.position).magnitude;
        size = Mathf.Clamp01(1- size)*2;
        mouth.transform.localScale = new Vector3(size,size, size);
    }
}
