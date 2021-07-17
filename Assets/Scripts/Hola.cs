using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Hola : MonoBehaviour {
  [Header("Initialization")]
  public Text hola;
  public Text hi;
  // Gracias por jugar el demo de Hypnogogia, justo ahora solo tiene 3 finales y no incluye *el* final. Te recomiendo jugarlo en español... tiene más... *sabor*";
  // Thanks for playing Hypnogogia's demo! right now it only has 3 endings and it doesn't include *the* ending. I highly recommend playing it in spanish because english is not my main language and right now, I still haven't hired any translator :)";

  void Update () {
    hola.gameObject.SetActive(Localization.selected == "bo");
    hi.gameObject.SetActive(Localization.selected == "english");
  }

  public void StartGame () {
    SceneManager.LoadScene("Main");
  }
}
