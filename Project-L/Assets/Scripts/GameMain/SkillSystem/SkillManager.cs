using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
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
        RunningSkill = false;
        _runningSkillBase = null;
        _runningTime = 0;
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
            }else if (action is SelectTarget selectTargetAction) {

                SelectTarget = GetTargetByAction(selectTargetAction);

            }else if (action is MoveTo moveAction) {

            }
        }

        List<Transform> GetTargetByAction(SelectTarget selectAction) {
            List<Transform> result = new List<Transform>();

            if (selectAction.SelectType == Skill.SelectTarget.Type.Self) {
                result.Add(this.transform);
            }
            else {
                var hits = GetsHits(selectAction.SelectType, GetStartPosition(selectAction.SelectRangeType));
                foreach (var hit in hits) {
                    var entity = hit.GetComponent<Entity>();
                    if (entity != null) {
                        switch (selectAction.EntityType) {
                            case Skill.SelectTarget.SelectTargetEntityType.Enemy:
                                if (entity is Enemy) {
                                    result.Add(entity.transform);
                                }
                                break;
                            case Skill.SelectTarget.SelectTargetEntityType.Friendly:
                                if (entity is PlayerCharacter) {
                                    result.Add(entity.transform);
                                }
                                break;
                            case Skill.SelectTarget.SelectTargetEntityType.Same:
                                if (this.GetComponent<Entity>().GetType() == entity.GetType()) {
                                    result.Add(entity.transform);
                                }
                                break;
                            case Skill.SelectTarget.SelectTargetEntityType.Diff:
                                if (this.GetComponent<Entity>().GetType() != entity.GetType()) {
                                    result.Add(entity.transform);
                                }
                                break;

                        }
                    }
                }
            }


            return result;

            Vector3 GetStartPosition(Skill.SelectTarget.SelectRangeOffsetType offsetType) {
                switch (offsetType) {
                    case Skill.SelectTarget.SelectRangeOffsetType.FromSelf:
                        return this.transform.position;
                    case Skill.SelectTarget.SelectRangeOffsetType.ForwardSelf:
                        var position = this.transform.position + (this.transform.forward + selectAction.OffsetCenterPosition);
                        Debug.Log($"ForwardSelf Position = {position}");
                        return position;
                    case Skill.SelectTarget.SelectRangeOffsetType.FromMouseInputPosition:
                        break;
                    case Skill.SelectTarget.SelectRangeOffsetType.FromMouseSelectPosition:
                        break;
                    case Skill.SelectTarget.SelectRangeOffsetType.FromOffsetSelf:
                        break;
                }

                return this.transform.position;
            }

            Collider[] GetsHits(Skill.SelectTarget.Type type,Vector3 position) {
                switch (type) {
                    case Skill.SelectTarget.Type.CubeRange:
                        return Physics.OverlapBox(position, new Vector3(selectAction.RangeLength, selectAction.RangeLength, selectAction.RangeLength));
                    case Skill.SelectTarget.Type.SphereRange:
                        return Physics.OverlapSphere(position, selectAction.RangeLength);
                    case Skill.SelectTarget.Type.SquareRange:
                        return Physics.OverlapBox(position, selectAction.SquareSize); ;
                }

                return null;
            }
        }
    }


}
