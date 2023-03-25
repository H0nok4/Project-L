using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Skill
{
    [Serializable]
    public class SkillEvent
    {

        [HideInInspector] public bool Trigged = false;

        /// <summary>
        /// ´¥·¢Ê±¼ä
        /// </summary>
        public float TriggerTime;


        [ShowInInspector]
        public List<GameObject> Events;


        public IEnumerable<Type> GetFilteredTypeList() {

            var q = typeof(SkillActionBase).Assembly.GetTypes()
                .Where(x => !x.IsAbstract)                                          // Excludes BaseClass
                .Where(x => !x.IsGenericTypeDefinition)                             // Excludes C1<>
                .Where(x => typeof(SkillActionBase).IsAssignableFrom(x));                 // Excludes classes not inheriting from BaseClass


            Debug.Log($"q.Count = {q.Count()}");
            return q;
        }

    }
}
