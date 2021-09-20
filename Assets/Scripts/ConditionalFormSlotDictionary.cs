using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConditionalFormSlotDictionary : FormSlot {
  [Header("Initialization")]
  public ContextualIngreso ingresos;
  public DictionaryForRandomization maleCase;
  public DictionaryForRandomization femaleCase;
  public override DictionaryForRandomization dictionary {
    get  {
      return ingresos.attendingPatient.info.male? maleCase: femaleCase;
    }
  }

}
