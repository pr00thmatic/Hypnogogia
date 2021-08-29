using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
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

  public static T RandomPick<T> (List<T> items) {
    return items[Random.Range(0, items.Count)];
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

  public static void DeleteChildren (Transform dad) {
    for (int i=dad.childCount-1; i>=0; i--) {
      Transform chosen = dad.GetChild(i);
      chosen.parent = null;
      GameObject.Destroy(chosen.gameObject);
    }
  }

  // https://stackoverflow.com/questions/273313/randomize-a-listt (grenade)
  public static void Shuffle<T> (List<T> list)   {
    int n = list.Count;
    while (n > 1) {
      n--;
      // rng.Next(n + 1);
      int k = Random.Range(0, n);
      T value = list[k];
      list[k] = list[n];
      list[n] = value;
    }
  }

  public static void CopyTransform (Transform toCopy, Transform copier) {
    copier.position = toCopy.position;
    copier.rotation = toCopy.rotation;
    copier.localScale = toCopy.localScale;
  }

  public static void RandomSkin (SpriteResolver[] resolvers) {
    IEnumerable<string> FUCK = resolvers[0].spriteLibrary.spriteLibraryAsset
      .GetCategoryLabelNames(resolvers[0].GetCategory());
    int count = 0;
    foreach (string fuck in FUCK) { count++; }
    int pick = Random.Range(0, count);

    foreach (SpriteResolver resolver in resolvers) {
      int i = 0;
      IEnumerable<string> uselessList =
        resolver.spriteLibrary.spriteLibraryAsset.GetCategoryLabelNames(resolver.GetCategory());
      foreach (string fuck in uselessList) {
        if (i == pick) {
          resolver.SetCategoryAndLabel(resolver.GetCategory(), fuck);
          break;
        }
        i++;
      }
    }
  }

  public static int GetSkinIndex (SpriteResolver resolver) {
    IEnumerable<string> skins = resolver.spriteLibrary.spriteLibraryAsset.GetCategoryLabelNames(resolver.GetCategory());
    int index = 0;
    foreach (string skin in skins) {
      if (skin == resolver.GetLabel()) return index;
    }
    return -1;
  }

  public static void SetSkinByIndex (SpriteResolver resolver, int index) {
    IEnumerable<string> skins = resolver.spriteLibrary.spriteLibraryAsset.GetCategoryLabelNames(resolver.GetCategory());
    int count = 0;
    string found = "";
    foreach (string skin in skins) {
      if (count == index) { found = skin; break; }
      count++;
    }
    resolver.SetCategoryAndLabel(resolver.GetCategory(), found);
  }

  public static void RandomSkin (SpriteResolver resolver) {
    RandomSkin(new SpriteResolver[] { resolver });
  }

  // SAUCE: Davidblkx https://gist.github.com/Davidblkx/e12ab0bb2aff7fd8072632b396538560
  /// <summary>
  ///     Calculate the difference between 2 strings using the Levenshtein distance algorithm
  /// </summary>
  /// <param name="source1">First string</param>
  /// <param name="source2">Second string</param>
  /// <returns></returns>
  public static int Levenshtein (string source1, string source2) //O(n*m)
  {
    var source1Length = source1.Length;
    var source2Length = source2.Length;

    var matrix = new int[source1Length + 1, source2Length + 1];

    // First calculation, if one entry is empty return full length
    if (source1Length == 0)
      return source2Length;

    if (source2Length == 0)
      return source1Length;

    // Initialization of matrix with row size source1Length and columns size source2Length
    for (var i = 0; i <= source1Length; matrix[i, 0] = i++){}
    for (var j = 0; j <= source2Length; matrix[0, j] = j++){}

    // Calculate rows and collumns distances
    for (var i = 1; i <= source1Length; i++)
    {
      for (var j = 1; j <= source2Length; j++)
      {
        var cost = (source2[j - 1] == source1[i - 1]) ? 0 : 1;

        matrix[i, j] = System.Math.Min(
          System.Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
          matrix[i - 1, j - 1] + cost);
      }
    }
    // return result
    return matrix[source1Length, source2Length];
  }
}
