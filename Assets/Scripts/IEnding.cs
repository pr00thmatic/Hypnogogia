using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IEnding {
  public event System.Action onFinished;
  public void TriggerEndOfEnding ();
}
