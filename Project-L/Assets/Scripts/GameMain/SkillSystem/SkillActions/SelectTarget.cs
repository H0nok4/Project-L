using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Skill
{
    public class SelectTarget : SkillActionBase
    {
        public Type SelectType;

        public SelectTargetEntityType EntityType;

        [ShowIf("@this.SelectType != Type.Self")]
        public SelectRangeOffsetType SelectRangeType;

        [ShowIf("@this.SelectType != Type.Self")]
        public Vector3 OffsetCenterPosition;

        [ShowIf("@this.SelectType != Type.Self && this.SelectType != Type.SquareRange")]
        public float RangeLength;

        [ShowIf("@this.SelectType != Type.Self && this.SelectType == Type.SquareRange")]
        public Vector3 SquareSize;

        public enum Type {
            Self,
            SquareRange,
            CubeRange,
            SphereRange,
        }

        public enum SelectRangeOffsetType {
            /// <summary>
            /// 从自身为中心内点开始
            /// </summary>
            FromSelf,
            /// <summary>
            /// 从自身正前方为基准的偏移点为中心点
            /// </summary>
            ForwardSelf,
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
        
        public enum SelectTargetEntityType
        {
            Enemy,
            Friendly,
            Same,
            Diff,
            All
        }

    }



}
