using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MultipleChoise : MonoBehaviour {
  [Header("Initialization")]
  public Transform options;

  void OnEnable () {
    Display("Mamani", RandomizerDictionary.apellidos);
  }

  public void Display (string option, string[] dictionary) {
    TextMeshPro[] labels = options.GetComponentsInChildren<TextMeshPro>();
    TextMeshPro theChosenOne = Utils.RandomPick(labels);
    theChosenOne.text = option;

    List<IntPair> distances = new List<IntPair>();
    bool[] used = new bool[dictionary.Length];
    for (int i=0; i<dictionary.Length; i++) {
      distances.Add(new IntPair(i, Utils.Levenshtein(dictionary[i], option)));
    }

    distances.Sort((IntPair a, IntPair b) => { return a.b - b.b; });
    foreach (IntPair item in distances) {
      Debug.Log(dictionary[item.a] + " distance: " + item.b);
    }
  }
}
