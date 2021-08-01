using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HairVariant : Variant {
  [Header("Initialization")]
  public float[] colorAccumulativeDistribution;
  public Color[] colors;
  public Sprite[] front;
  public Sprite[] back;
  public SpriteRenderer frontRenderer;
  public SpriteRenderer backRenderer;

  public override void Set () {
    float dice = Random.Range(0,1f);
    int chosenColor = 0;

    for (chosenColor=0; chosenColor<colors.Length; chosenColor++) {
      if (dice <= colorAccumulativeDistribution[chosenColor]) {
        break;
      }
    }

    frontRenderer.sprite = front[chosen];
    backRenderer.sprite = back[chosen];
    frontRenderer.color = backRenderer.color = colors[chosenColor];
  }
}
