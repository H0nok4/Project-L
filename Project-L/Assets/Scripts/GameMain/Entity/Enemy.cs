using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    //Ŀǰ����ֻ��ľ׮

    public override void Awake() {
        EntityRigidbody = base.transform.GetComponent<Rigidbody>();
        EntityCollider = base.transform.GetComponent<BoxCollider>();
    }

}
