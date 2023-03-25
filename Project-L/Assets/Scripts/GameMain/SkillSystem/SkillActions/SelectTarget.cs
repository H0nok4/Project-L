using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Skill
{
    public class SelectTarget : SkillActionBase
    {
        public SelectTargetType SelectType;

        [ShowIf("SelectType", SelectTargetType.Square)]
        public SelectRangeOffsetType SquareSelectRangeType;
        [ShowIf("SelectType", SelectTargetType.CubeRange)]
        public SelectRangeOffsetType CubeSelectRangeType;
        [ShowIf("SelectType", SelectTargetType.SphereRange)]
        public SelectRangeOffsetType SphereRangeType;
        public enum SelectTargetType {
            self,
            Square,
            CubeRange,
            SphereRange,
        }

        public enum SelectRangeOffsetType {
            /// <summary>
            /// 从自身为中心内点开始
            /// </summary>
            FromSelf,
            /// <summary>
            /// 从自身附近的偏移位置为中心点开始
            /// </summary>
            FromOffsetSelf,
            /// <summary>
            /// 从一个储存的鼠标选取点开始
            /// </summary>
            FromMouseSelectPosition,
            /// <summary>
            /// 跟随当前鼠标选中位置开始
            /// </summary>
            FromMouseInputPosition
        }

    }



}
