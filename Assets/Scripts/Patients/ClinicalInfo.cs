using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ClinicalInfo", menuName = "pr00/clinical info")]
public class ClinicalInfo : ScriptableObject {
  public string apellidos;
  public string nombre;
  public bool male = true;
  public Pain pain;
  public Consciousness consciousness;
  public LocalizedComment[] presentation;
  public string cause;
}
