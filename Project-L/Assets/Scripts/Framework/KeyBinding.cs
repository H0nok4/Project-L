using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KeyBinding
{
    public static KeyCode LeftKeyCode;

    public static KeyCode RightKeyCode;

    public static KeyCode UpKeyCode;

    public static KeyCode DownKeyCode;

    public static KeyCode AttackKeyCode;

    public static void Init()
    {
        LeftKeyCode = KeyCode.A;
        RightKeyCode = KeyCode.D;
        UpKeyCode = KeyCode.W;
        DownKeyCode = KeyCode.S;
        AttackKeyCode = KeyCode.Mouse0;
    }
}
