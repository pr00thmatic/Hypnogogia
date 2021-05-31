using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CookingPlace : MonoBehaviour {
  [Header("Initialization")]
  public ContextualStove contextual;
  public Transform WhatsCookin { get => contextual.whatsCookin; }
}
