using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToKill : MonoBehaviour
{
    [SerializeField] GameEvent _onDied;

    bool _dead;

    void OnMouseDown()
    {
        if (_dead == false)
            Die();
    }

    void Die()
    {
        _onDied?.Invoke();
        _dead = true;
    }
}
