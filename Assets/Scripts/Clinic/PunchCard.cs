using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PunchCard : MonoBehaviour {
  [Header("Configuration")]
  public string owner = "";
  public float missProbability = 0.2f;
  public int maxMissFrequency = 1;
  public float luck = 0.2f;
  public float unluck = 0.5f;
  public DayPunchCardRandomizer luckyDay = new DayPunchCardRandomizer() {
    enter = new RandomRange(5.6f, 5.9f), exit = new RandomRange(19f, 19.5f)
  };
  public DayPunchCardRandomizer regularDay = new DayPunchCardRandomizer () {
    enter = new RandomRange(5.6f, 6), exit = new RandomRange(20f, 21f)
  };
  public DayPunchCardRandomizer unluckyDay = new DayPunchCardRandomizer () {
    enter = new RandomRange(5.3f, 6.8f), exit = new RandomRange(22f, 23.5f)
  };

  [Header("Initialization")]
  public Transform entriesRoot;

  public void Randomize () {
    int misses = 0;

    for (int i=0; i<entriesRoot.childCount; i++) {
      PunchCardEntry entry = entriesRoot.GetChild(i).GetComponent<PunchCardEntry>();

      float dice = Random.Range(0,1f);
      bool miss = misses < maxMissFrequency && dice < missProbability;
      misses += miss? 1: 0;

      if (miss) {
        entry.exit.text = entry.enter.text = "";
        continue;
      }

      dice = Random.Range(0,1f);
      DayPunchCardRandomizer randomizer = (dice < luck? luckyDay: (dice < unluck? unluckyDay: regularDay));
      entry.enter.text = Utils.DigitalTime(randomizer.enter.Uniform);
      entry.exit.text = Utils.DigitalTime(randomizer.exit.Uniform);
    }
  }
}
