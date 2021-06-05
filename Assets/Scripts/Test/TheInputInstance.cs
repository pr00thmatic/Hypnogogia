using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TheInputInstance {
  public static TheInput Input { get { if (_input == null) { _input = new TheInput(); _input.Enable(); } return _input; } }
  static TheInput _input;
}
