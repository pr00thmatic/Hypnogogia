using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WalkToEnfermeria : MonoBehaviour {
  [Header("Configuration")]
  public float walkingSpeed = 2;
  public SideSkin side;

  [Header("Information")]
  public float speed = 0;

  [Header("Initialization")]
  public Transform root;
  public GameObject sittingAtEnfermeria;

  void OnEnable () {
    side.gameObject.SetActive(true);
    Walk();
  }

  void Update () {
    if (!side.gameObject.activeSelf && speed > 0) side.gameObject.SetActive(true);
  }

  public void Walk () { StartCoroutine(_GoToEnfermeria()); } IEnumerator _GoToEnfermeria () {
    PatientsManager manager = GetComponentInParent<PatientsManager>();
    speed = 1;

    while (root.transform.position.x != manager.enfermeriaTarget.position.x) {
      float direction = Mathf.Sign(manager.enfermeriaTarget.position.x - root.transform.position.x);
      root.localScale = Utils.SetX(root.localScale, Mathf.Abs(root.localScale.x) * direction);
      root.transform.position =
        Utils.SetX(root.transform.position, Mathf.MoveTowards(root.transform.position.x, manager.enfermeriaTarget.position.x,
                                                         walkingSpeed * Time.deltaTime));
      yield return null;
    }

    manager.enfermeriaDoor.isOpen = true;
    speed = 0;
    yield return new WaitForSeconds(1);
    // skins.SetActive(false);
    yield return new WaitForSeconds(0.25f);
    manager.enfermeriaDoor.isOpen = false;
    sittingAtEnfermeria.SetActive(true);
    root.transform.parent = manager.enfermeriaChair;
    root.transform.localPosition = Vector3.zero;
  }
}
