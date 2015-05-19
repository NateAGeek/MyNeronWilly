using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PromptBubble : MonoBehaviour {

	public Text TextComponet;

	public void setText(string text){
		TextComponet.text = text;
	}
}
