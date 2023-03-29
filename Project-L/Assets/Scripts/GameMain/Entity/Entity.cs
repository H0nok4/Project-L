using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour{

    public Rigidbody EntityRigidbody;

    public BoxCollider EntityCollider;

    public bool Attackable = true;

    public EntityState State;

    public GameObject DamageShow;

    public virtual void Awake() {
        EntityRigidbody = GetComponent<Rigidbody>();
        EntityCollider = GetComponent<BoxCollider>();
    }

    public void TakeDamage(float damage,Transform sorce) {
        State.CurHP -= damage;
        Debug.Log($"受到{damage}点伤害,来源为玩家:{sorce.GetComponent<Entity>() is PlayerCharacter}");
        var show = Instantiate(DamageShow, this.transform.position,Quaternion.identity);
        show.SetActive(true);
        show.GetComponent<DamageShow>().Value = damage;

        if (State.CurHP < 0) {
            Die();
        }
    }

    public virtual void Die() {
        Object.Destroy(base.gameObject);
    }

}
