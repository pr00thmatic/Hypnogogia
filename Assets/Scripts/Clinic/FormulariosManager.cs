using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FormulariosManager : NonPersistentSingleton<FormulariosManager> {
  [Header("Information")]
  public Dictionary<string, TinderGuyComment> commentOnAsking = new Dictionary<string, TinderGuyComment>();
  public bool CanHas (string form) {
    return !FormulariosManager.Instance.commentOnAsking.ContainsKey(form) ||
      FormulariosManager.Instance.commentOnAsking[form] == null;
  }

  [Header("Initialization")]
  public IngresosSettings blockedIngresosComments;
  public EpicrisisSettings blockedEpicrisisComments;
  public RecepcionistaGrabingHand recepcionista;

  override protected void Awake () {
    base.Awake();
    commentOnAsking["ingresos"] = null;
    commentOnAsking["epicrisis"] = blockedEpicrisisComments.ingresoNotYetAsked;
  }

  void OnEnable () {
    recepcionista.onFormDelivery += HandleDelivery;
    recepcionista.onFormSubmitted += HandleSubmission;
  }

  void OnDisable () {
    recepcionista.onFormDelivery -= HandleDelivery;
    recepcionista.onFormSubmitted += HandleSubmission;
  }

  public void HandleDelivery (string form) {
    switch (form) {
      case "ingresos":
        commentOnAsking["epicrisis"] = blockedEpicrisisComments.ingresoNotYetSubmitted;
        commentOnAsking["ingresos"] = blockedIngresosComments.ingresoNotYetSubmitted;
        break;
      case "epicrisis":
        commentOnAsking["ingresos"] = blockedIngresosComments.epicrisisNotYetSubmitted;
        commentOnAsking["epicrisis"] = blockedEpicrisisComments.epicrisisNotYetSubmitted;
        break;
      default:
        Debug.Log("I DON'T KNOW THAT FORM! (" + form + ")", this); // TODO: featurize!
        break;
    }
  }

  public void HandleSubmission (string form) {
    switch (form) {
      case "ingresos":
        commentOnAsking["ingresos"] = blockedIngresosComments.epicrisisNotYetAsked;
        commentOnAsking["epicrisis"] = null;
        break;
      case "epicrisis":
        commentOnAsking["ingresos"] = null;
        commentOnAsking["epicrisis"] = blockedEpicrisisComments.ingresoNotYetAsked;
        break;
      default:
        Debug.Log("I DON'T KNOW THAT FORM! (" + form + ")", this); // TODO: featurize!
        break;
    }
  }
}
