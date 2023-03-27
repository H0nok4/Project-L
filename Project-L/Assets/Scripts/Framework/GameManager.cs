using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool IsAwake;
    private void Awake()
    {
        KeyBinding.Init();
        UnityEditor.Compilation.CompilationPipeline.compilationStarted += CompilationStarted;
        IsAwake = true;
    }

    private void OnDestroy() {
        UnityEditor.Compilation.CompilationPipeline.compilationStarted -= CompilationStarted;
        IsAwake = false;
    }

    private void CompilationStarted(object obj) {
        UnityEditor.EditorApplication.Beep();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
