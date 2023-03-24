using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    //目前敌人只是木桩

    public override void Awake() {
        EntityRigidbody = base.transform.GetComponent<Rigidbody>();
        EntityCollider = base.transform.GetComponent<BoxCollider>();
    }

}
