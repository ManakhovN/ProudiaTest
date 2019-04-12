using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTracker : MonoBehaviour, ITracker {
    protected Transform target;
    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }

    public virtual void Refresh()
    {
        throw new System.NotImplementedException();
    }
}
