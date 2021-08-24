using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MultipleChoise : MonoBehaviour {
  [Header("Information")]
  public List<FormSlot> available;

  [Header("Initialization")]
  public Transform options;
  public Transform formSlots;

  void OnEnable () {
    foreach (Transform child in formSlots) {
      FormSlot slot = child.GetComponent<FormSlot>();
      available.Add(slot);
      slot.onFill += HandleFormFilled;
    }

    DisplayChoise();
  }

  public void Display (string option, List<string> dictionary) {
    TextMeshPro[] labels = options.GetComponentsInChildren<TextMeshPro>();
    TextMeshPro theChosenOne = Utils.RandomPick(labels);
    theChosenOne.text = option;

    foreach (TextMeshPro label in labels) {
      if (label == theChosenOne) continue;
      do {
        label.text = Utils.RandomPick(dictionary);
      } while (label.text == option);
    }
  }

  void HandleFormFilled (FormSlot used) { DisplayChoise(); }
  public void DisplayChoise () {
    FormSlot chosen = Utils.RandomPick(available);
    Display(chosen.expected, chosen.dictionary.Entries);
    available.Remove(chosen);
  }
}
