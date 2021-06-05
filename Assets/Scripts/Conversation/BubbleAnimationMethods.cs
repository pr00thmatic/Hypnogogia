using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Conversations {
public class BubbleAnimationMethods : MonoBehaviour {
  public void DisplayText () {
    GetComponentInParent<Bubble>().DisplayText();
  }

  public void HideText () {
    GetComponentInParent<Bubble>().HideText();
  }
}
}
