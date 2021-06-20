using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CookedEggInPan : MonoBehaviour {
  [Header("Information")]
  public EggStatus status;
  public bool IsStuck = false;
  // public bool IsStuck {
  //   get => GetComponentInParent<Pan>().somethingIsStuck;
  //   set => GetComponentInParent<Pan>().somethingIsStuck = value;
  // }
  public bool alreadySlided = false;

  [Header("Initialization")]
  public Rigidbody2D body;
  public new Collider2D collider;
  public Transform pannedEggs;
  public Transform splashedEggs;

  void OnEnable () {
    body.velocity = Vector2.zero;
  }

  void Update () {
    if (transform.localPosition.x > -0.22f && !alreadySlided) {
      Slide();
    }
  }

  void OnCollisionStay2D (Collision2D c) {
    if (IsStuck) return;
    Splash(c.collider);
  }

  public void Slide () {
    GetComponentInParent<Pan>().oil = 0;
    if (!IsStuck) {
      alreadySlided = true;
      transform.parent = null;
      collider.isTrigger = false;
    } else {
      body.isKinematic = true;
    }
  }

  public void Splash (Collider2D c) {
    foreach (Transform pannedEgg in pannedEggs) {
      splashedEggs.Find(pannedEgg.name).GetComponent<SpriteRenderer>().color =
        new Color(1,1,1, pannedEgg.GetComponent<Egg>().alpha);
      splashedEggs.parent = c.transform;
      splashedEggs.gameObject.SetActive(true);
      Destroy(gameObject);
    }
  }
}
