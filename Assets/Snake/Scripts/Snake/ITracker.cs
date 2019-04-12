using UnityEngine;

internal interface ITracker: IRefreshable
{
    Transform Target
    {
        set;
        get;
    }

}