using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScript : MonoBehaviour {

  public Sprite spriteDream;
  public Sprite spriteReal;

  public void chgScript() {

    this.gameObject.GetComponent<Image>().sprite = spriteReal;

  }
}