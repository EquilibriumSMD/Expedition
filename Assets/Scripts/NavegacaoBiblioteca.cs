using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class NavegacaoBiblioteca : MonoBehaviour {
    
    public Button BotaoAventureiro,BotaoSair;
    [Space(20)]
    public string livros1 = "Livro1";
    
     void Awake(){
        DontDestroyOnLoad (transform.gameObject);
     }
    

	// Use this for initialization
	void Start () {
        Cursor.visible = true;
        
        // =========SETAR BOTOES==========//
        BotaoAventureiro.onClick = new Button.ButtonClickedEvent();
        BotaoSair.onClick = new Button.ButtonClickedEvent();
        
        BotaoAventureiro.onClick.AddListener(() => Tipo1());
        BotaoSair.onClick.AddListener(() => Sair());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    private void Tipo1(){
        SceneManager.LoadScene (livros1);
    }
    private void Sair(){
        Application.Quit ();
    }
    
}
