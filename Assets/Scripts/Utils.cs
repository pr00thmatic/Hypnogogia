using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
using System.Collections.Generic;

public class Utils {
  public static Vector3 SetZ (Vector3 v, float z) {
    v.z = z;
    return v;
  }

  public static Vector3 SetY (Vector3 v, float y) {
    v.y = y;
    return v;
  }

  public static Vector3 SetX (Vector3 v, float x) {
    v.x = x;
    return v;
  }

  public static void Set (SortingGroup sGroup, string sortingLayerName, int sortingOrder) {
    sGroup.sortingLayerName = sortingLayerName;
    sGroup.sortingOrder = sortingOrder;
  }

  public static void Set (SortingGroup sGroup, SortingGroup other) {
    Set(sGroup, other.sortingLayerName, other.sortingOrder);
  }

  public static T RandomPick<T> (T[] items) {
    return items[Random.Range(0, items.Length)];
  }

  public static GameObject CreateEmptyChild (Transform parent, string name) {
    GameObject child = new GameObject(name);
    child.transform.parent = parent;
    child.transform.localPosition = Vector3.zero;
    child.transform.localRotation = Quaternion.identity;
    child.transform.localScale = Vector3.one;
    return child;
  }

  public static string TwoDigits (string source) {
    if (source.Length == 1) return "0" + source;
    return source;
  }

  public static string DigitalTime (float hour) {
    return Utils.TwoDigits((int) (hour) + "") + ":" + Utils.TwoDigits((int) ((hour * 60) % 60) + "");
  }

  public static bool IsInState (Animator animator, string stateName) {
    return animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
  }
}
