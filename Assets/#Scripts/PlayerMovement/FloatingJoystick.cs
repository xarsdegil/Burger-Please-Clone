using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(RectTransform))]
[DisallowMultipleComponent]

public class FloatingJoystick : MonoBehaviour
{
    [HideInInspector] public RectTransform _rectTransform;
    public RectTransform _knob;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
}
