using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Estufable))]
public class PlasticBurn : MonoBehaviour {
  [Header("Configuration")]
  public float timeRequiredToFire = 1;
  public Vector2 burnSubinterval = new Vector2(0, 1);

  [Header("Information")]
  public List<float> originals = new List<float>();
  public List<float> rotationTargets = new List<float>();
  public float timeInEstufa = 0;
  public float burnPercentage;

  [Header("Initialization")]
  public Estufable estufable;
  public Transform rig;
  public GameObject fire;
  public new SpriteRenderer renderer;

  void Reset () {
    estufable = GetComponent<Estufable>();
    estufable.cookingTimeAtMax = 3;
    rig = transform.GetChild(0);
    fire = transform.Find("fire").gameObject;
    renderer = GetComponentInChildren<SpriteRenderer>();
    if (!renderer) renderer = GetComponent<SpriteRenderer>();
  }

  void Start () {
    foreach (Transform child in rig) {
      CalculateTargets(child, 1);
    }
  }

  void Update () {
    if (estufable.hornilla && estufable.hornilla.IsOn) {
      burnPercentage = (estufable.hotness - burnSubinterval.x) / (burnSubinterval.y - burnSubinterval.x);
      timeInEstufa += Time.deltaTime;
      foreach (Transform child in rig) {
        UpdateTargets(child);
      }
      renderer.color = Color.Lerp(Color.white, Color.black, burnPercentage);
    } else {
      timeInEstufa = 0;
    }

    fire.SetActive(timeInEstufa > timeRequiredToFire);
  }

  public void UpdateTargets (Transform parent, int i=0) {
    parent.rotation = Quaternion.Euler(0,0, Mathf.Lerp(originals[i], originals[i] + rotationTargets[i], burnPercentage));
    foreach (Transform child in parent) {
      UpdateTargets(child, i+1);
    }
  }

  public void CalculateTargets (Transform parent, float sign) {
    rotationTargets.Add(Random.Range(30, 60) * sign);
    originals.Add(parent.rotation.eulerAngles.z);
    foreach (Transform child in parent) {
      CalculateTargets(child, -sign);
    }
  }
}
