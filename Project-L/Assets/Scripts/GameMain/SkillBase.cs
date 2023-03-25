using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SkillBase",menuName = "Creat/Skill",order = 0)]
public class SkillBase : ScriptableObject {
    public float TotalTime;
    public List<SkillEvent> Events;
}
[Serializable]
public class SkillEvent {
    public float Time;
}
