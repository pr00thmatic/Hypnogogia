using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class RandomIntFromArray {
  public int[] array;
  public int chosen;
  public void Randomize () { chosen = Utils.RandomPick(array); }
}
