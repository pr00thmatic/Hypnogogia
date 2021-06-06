using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CookedEggInPan : MonoBehaviour {
  [Header("Information")]
  public bool isStuck = false;
  public EggStatus status;
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
    if (isStuck) return;
    Splash(c.collider);
  }

  public void Slide () {
    GetComponentInParent<Pan>().oil = 0;
    if (!isStuck) {
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
