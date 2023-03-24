using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    /// <summary>
    /// 待机
    /// </summary>
    Idle,
    /// <summary>
    /// 使用技能
    /// </summary>
    UseSkill,
    /// <summary>
    /// 受击
    /// </summary>
    TakeDamage,
    /// <summary>
    /// 跑步
    /// </summary>
    Run
}
