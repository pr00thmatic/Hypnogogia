using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CookedEggInPan : MonoBehaviour {
  [Header("Information")]
  public EggStatus status;
  public bool IsStuck {
    get => original.isStuck;
    set => original.isStuck = value;
  }
  public bool alreadySlided = false;

  [Header("Initialization")]
  public ContextualEgg original;
  public Rigidbody2D body;
  public new Collider2D collider;
  public Transform pannedEggs;
  public Transform splashedEggs;

  void OnEnable () {
    body.velocity = Vector2.zero;
    if (original) Copy(original);
  }

  void Update () {
    if (transform.localPosition.x > -0.22f && !alreadySlided) {
      Slide();
    }
  }

  void OnCollisionStay2D (Collision2D c) {
    if (IsStuck || c.collider.GetComponentInParent<Pan>()) return;
    Splash(c.collider);
  }

  public void Copy (ContextualEgg egg) {
    this.original = egg;
    for (int i=0; i<egg.eggs.Length; i++) {
      Egg original = egg.eggs[i];
      Egg clone = pannedEggs.Find(original.name).GetComponent<Egg>();
      clone.Copy(original);
      clone.name = original.name;
      clone.wigglyShines = 0;
      clone.status = 0.5f;
    }
  }

  public void Slide () {
    GetComponentInParent<Pan>().oil = 0;
    if (!IsStuck) {
      alreadySlided = true;
      transform.parent = null;
      collider.isTrigger = false;
      original.DestroySelf();
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
