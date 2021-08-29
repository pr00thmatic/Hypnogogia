using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class RandomColorFromArray {
  public Color[] array;
  public Color chosen;

  public void Randomize () { chosen = Utils.RandomPick(array); }
}
