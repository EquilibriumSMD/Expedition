using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class ButonBack : MonoBehaviour {

	public Button BotaoBack;
	public string nomeCena = "Menu";


	void Start () {

		// =========SETAR BOTOES==========//
		BotaoBack.onClick = new Button.ButtonClickedEvent();
		BotaoBack.onClick.AddListener(() => Back());
	}

	//===========VOIDS NORMAIS=========//
	private void Back(){
		SceneManager.LoadScene (nomeCena);
	}
}
