using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour{

    public Rigidbody EntityRigidbody;

    public BoxCollider EntityCollider;

    public bool Attackable = true;

    public EntityState State;

    public virtual void Awake() {
        EntityRigidbody = GetComponent<Rigidbody>();
        EntityCollider = GetComponent<BoxCollider>();
    }

    public void TakeDamage(float damage,Transform sorce) {
        State.CurHP -= damage;

        if (State.CurHP < 0) {
            Die();
        }
    }

    public virtual void Die() {
        Object.Destroy(base.gameObject);
    }

}
