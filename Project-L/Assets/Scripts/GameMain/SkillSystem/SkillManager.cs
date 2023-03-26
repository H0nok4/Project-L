using System;
using System.Collections;
using System.Collections.Generic;
using Skill;
using Unity.VisualScripting;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public bool RunningSkill { get; private set; }

    private float _runningTime;

    private SkillBase _runningSkillBase;

    private void Update()
    {
        if (!RunningSkill)
        {
            return;
        }

        _runningTime += Time.deltaTime;
        TryTriggerSkillBase(_runningTime);
    }

    private void TryTriggerSkillBase(float time)
    {
        
        foreach (var skillEvent in _runningSkillBase.Events)
        {
            if (skillEvent.Trigged)
            {
                continue;
            }

            //到时间了可以触发了
            if (skillEvent.TriggerTime < time)
            {
                List<SkillActionBase> skillAction = new List<SkillActionBase>();
                foreach (var gameObject in skillEvent.Events)
                {
                    skillAction.AddRange(gameObject.GetComponents<SkillActionBase>());
                }

                RunSkillAction(skillAction);
                skillEvent.Trigged = true;
            }


        }

        if (time > _runningSkillBase.TotalTime)
        {
            Exit();
        }
    }

    private void FixedUpdate()
    {

    }
    public void PlaySkill(SkillBase skillBase)
    {
        Debug.Log("开始释放Skill");
        _runningTime = 0f;
        _runningSkillBase = skillBase;
        RunningSkill = true;
        foreach (var skillBaseEvent in skillBase.Events)
        {
            skillBaseEvent.Trigged = false;
        }
    }

    public void Exit()
    {
        RunningSkill = false;
        _runningSkillBase = null;
        _runningTime = 0;
    }

    public void StopSkill()
    {

    }

    public void RunSkillAction(List<SkillActionBase> actions)
    {
        List<Transform> SelectTarget = null;
        foreach (var action in actions)
        {
            if (action is Log logAction)
            {
                Debug.Log(logAction.LogString);
            }else if (action is PlayAnimationSkillAction playAnimationAction)
            {
                if (SelectTarget is { Count: > 0 })
                {
                    foreach (var targets in SelectTarget)
                    {
                        var animator = targets.GetComponentInChildren<Animator>();
                        if (animator != null)
                        {
                            animator.Play(playAnimationAction.AnimationName);
                        }
                    }
                }
            }else if (action is SelectTarget selectTargetAction)
            {
                switch (selectTargetAction.SelectType)
                {
                    case Skill.SelectTarget.Type.Self:
                        if (SelectTarget == null)
                        {
                            SelectTarget = new List<Transform>();
                        }
                        else
                        {
                            SelectTarget.Clear();
                        }
                        SelectTarget.Add(this.transform);
                        break;
                    case Skill.SelectTarget.Type.SphereRange:
                    case Skill.SelectTarget.Type.SquareRange:
                    case Skill.SelectTarget.Type.CubeRange:
                        if (SelectTarget == null) {
                            SelectTarget = new List<Transform>();
                        }
                        else {
                            SelectTarget.Clear();
                        }

                        switch (selectTargetAction.SelectRangeType) {
                            case Skill.SelectTarget.SelectRangeOffsetType.FromSelf:
                                var hits = Physics.OverlapBox(this.transform.position, new Vector3(selectTargetAction.RangeLength, selectTargetAction.RangeLength, selectTargetAction.RangeLength));
                                foreach (var hit in hits)
                                {
                                    var entity = hit.GetComponent<Entity>();
                                    if (entity != null)
                                    {
                                        switch (selectTargetAction.EntityType)
                                        {
                                            case Skill.SelectTarget.SelectTargetEntityType.Enemy:
                                                if (entity is Enemy)
                                                {
                                                    SelectTarget.Add(entity.transform);
                                                }
                                                break;
                                            case Skill.SelectTarget.SelectTargetEntityType.Friendly:
                                                if (entity is PlayerCharacter)
                                                {
                                                    SelectTarget.Add(entity.transform);
                                                }
                                                break;
                                            case Skill.SelectTarget.SelectTargetEntityType.Same:
                                                if (this.GetComponent<Entity>().GetType() == entity.GetType())
                                                {
                                                    SelectTarget.Add(entity.transform);
                                                }
                                                break;
                                            case Skill.SelectTarget.SelectTargetEntityType.Diff:
                                                if (this.GetComponent<Entity>().GetType() != entity.GetType()) {
                                                    SelectTarget.Add(entity.transform);
                                                }
                                                break;
                                                
                                        }
                                    }
                                }
                                break;
                            case Skill.SelectTarget.SelectRangeOffsetType.ForwardSelf:
                            case Skill.SelectTarget.SelectRangeOffsetType.FromOffsetSelf:
                            case Skill.SelectTarget.SelectRangeOffsetType.FromMouseInputPosition:
                            case Skill.SelectTarget.SelectRangeOffsetType.FromMouseSelectPosition:
                            default:
                                break;
                        }


                        break;
                        
                }
            }
        }
    }
}
