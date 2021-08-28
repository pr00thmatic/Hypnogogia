using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MultipleChoise : MonoBehaviour {
  public event System.Action onDone;

  [Header("Information")]
  public List<FormSlot> available;

  [Header("Initialization")]
  public Transform options;
  public Transform formSlots;
  public ThoughtBubble bubble;

  void OnEnable () {
    foreach (Transform child in formSlots) {
      FormSlot slot = child.GetComponent<FormSlot>();
      slot.gameObject.SetActive(true);
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
      if (label == theChosenOne || label.text == option) continue;
      label.text = Utils.RandomPick(dictionary);
    }
  }

  void HandleFormFilled (FormSlot used) { DisplayChoise(); }
  public void DisplayChoise () {
    if (available.Count == 0) {
      bubble.PopOut();
      StartCoroutine(_TriggerDone());
    } else {
      FormSlot chosen = Utils.RandomPick(available);
      Display(chosen.expected, chosen.dictionary.Entries);
      available.Remove(chosen);
      bubble.Repop();
    }
  }

  IEnumerator _TriggerDone () {
    yield return new WaitForSeconds(1);
    onDone?.Invoke();
  }
}
