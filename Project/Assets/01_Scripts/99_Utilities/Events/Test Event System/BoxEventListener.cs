using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BoxEventListener : MonoBehaviour
{
}


public class BoxEventListener<T> : BoxEventListener where T : class
{
    public Action<T> OnEventInvoked;

    public void Invoke(T data)
    {
        OnEventInvoked?.Invoke(data);
    }
}
