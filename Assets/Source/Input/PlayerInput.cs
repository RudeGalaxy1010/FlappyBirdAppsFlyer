using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Action JumpButtonPressed;

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpButtonPressed?.Invoke();
        }
#else
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            JumpButtonPressed?.Invoke();
        }
#endif
    }
}
