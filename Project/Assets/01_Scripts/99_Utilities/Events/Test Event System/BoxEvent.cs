using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/BoxEvent")]
public class BoxEvent: ScriptableObject
{
    private readonly HashSet<BoxEventListener> _listeners = new HashSet<BoxEventListener>();

    public void Invoke<T>(T data) where T : class
    {
        foreach (BoxEventListener listener in _listeners)
        {
            if (listener.GetType() == typeof(BoxEventListener<T>))
            {
                ((BoxEventListener<T>)listener).Invoke(data);
            }
        }
    }

    public void Register(BoxEventListener boxEventListener) => _listeners.Add(boxEventListener);
    public void Deregister(BoxEventListener boxEventListener) => _listeners.Remove(boxEventListener);

}




/*
public void RegisterListener(BoxEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(BoxEventListener _listener)
    {
        listeners.Remove(listener);
    }
*/

    



