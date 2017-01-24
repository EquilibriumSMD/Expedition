using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class Menu : MonoBehaviour {

	SceneFader fadeScr;
	Fading fadingCena;

 public Button BotaoJogar,BotaoConfigurar,BotaoSair;
 public Button BotaoBiblioteca;
 [Space(20)]
 public Slider BarraVolume;
 public Button BotaoVoltar, BotaoSalvarPref;
 [Space(20)]
 public Text textoVol;
 public string nomeCenaJogo = "Scene1";
 public string livros = "SceneBooks";
 private string nomeDaCena;
 private float VOLUME;

 void Awake(){
    DontDestroyOnLoad (transform.gameObject);
	//fadeScr = GameObject.FindObjectOfType<SceneFading> ();
	fadingCena = GameObject.FindObjectOfType<Fading> ();
 }

 void Start () {
     Opcoes (false);
     nomeDaCena = SceneManager.GetActiveScene ().name;
     Cursor.visible = true;
     Time.timeScale = 1;
     BarraVolume.minValue = 0;
     BarraVolume.maxValue = 1;

     //=============== SAVES===========//
     if (PlayerPrefs.HasKey ("VOLUME")) {
         VOLUME = PlayerPrefs.GetFloat ("VOLUME");
         BarraVolume.value = VOLUME;
     } else {
         PlayerPrefs.SetFloat ("VOLUME", 1);
         BarraVolume.value = 1;
     }

     // =========SETAR BOTOES==========//
     BotaoJogar.onClick = new Button.ButtonClickedEvent();
     BotaoBiblioteca.onClick = new Button.ButtonClickedEvent();
     BotaoConfigurar.onClick = new Button.ButtonClickedEvent();
     BotaoSair.onClick = new Button.ButtonClickedEvent();
     BotaoVoltar.onClick = new Button.ButtonClickedEvent();
     BotaoSalvarPref.onClick = new Button.ButtonClickedEvent();
     BotaoJogar.onClick.AddListener(() => Jogar());
     BotaoBiblioteca.onClick.AddListener(() => Biblioteca());
     BotaoConfigurar.onClick.AddListener(() => Opcoes(true));
     BotaoSair.onClick.AddListener(() => Sair());
     BotaoVoltar.onClick.AddListener(() => Opcoes(false));
     BotaoSalvarPref.onClick.AddListener(() => SalvarPreferencias());
 }
    
//=========VOIDS DE CHECAGEM==========//
 private void Opcoes(bool ativarOP){
     BotaoJogar.gameObject.SetActive (!ativarOP);
     BotaoBiblioteca.gameObject.SetActive (!ativarOP);
     BotaoConfigurar.gameObject.SetActive (!ativarOP);
     BotaoSair.gameObject.SetActive (!ativarOP);
     textoVol.gameObject.SetActive (ativarOP);
     BarraVolume.gameObject.SetActive (ativarOP);
     BotaoVoltar.gameObject.SetActive (ativarOP);
     BotaoSalvarPref.gameObject.SetActive (ativarOP);
 }
    
//=========VOIDS DE SALVAMENTO==========//
 private void SalvarPreferencias(){
     PlayerPrefs.SetFloat ("VOLUME", BarraVolume.value);
     AplicarPreferencias ();
 }
 private void AplicarPreferencias(){
     VOLUME = PlayerPrefs.GetFloat ("VOLUME");
 }
    
//===========VOIDS NORMAIS=========//
 void Update(){
     if (SceneManager.GetActiveScene ().name != nomeDaCena) {
         AudioListener.volume = VOLUME;
         Destroy (gameObject);
     }
 }

 private void Jogar(){
    //SceneManager.LoadScene (nomeCenaJogo); //[osawa]
		//fadeScr.EndScene(1);
		fadingCena.mudarCena (1);
	//	fadeJogar();

 }
	/*public IEnumerator fadeJogar()
	{
		float fadeTime = GameObject.Find("UIMenu").GetComponent<Fader>().beginFade(1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene (nomeCenaJogo);
	}*/

 private void Biblioteca(){
    SceneManager.LoadScene (livros);
 }
 private void Sair(){
    Application.Quit ();
 }
}
