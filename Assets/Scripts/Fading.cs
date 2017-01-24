using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour 
{
	public Texture2D fadeOutTexture; //Textura que vai para a tela
	public float fadeSpeed = 0.8f; //Velocidade do Fade
	public float alphaInicial = 1.0f; //Alpha da textura. Em telas como menu deixa 0

	private int drawDepth = -1000; //Ordem de hierarquia, menor número fica em cima
	private int fadeDir = -1; //Direção do fade: in = -1 ou out = 1

	void OnGUI ()
	{
		//fade out/in com o alpha, usando a direção, velocidade e tempo para ser em segundos
		alphaInicial += fadeDir * fadeSpeed * Time.deltaTime;
		// force (clamp) o número entre 0 e 1 para GUI.color usar alpha entre 0 e 1
		alphaInicial = Mathf.Clamp01(alphaInicial);

		//Cor da GUI (textura aqui)
		GUI.color = new Color (GUI.color.r,GUI.color.g, GUI.color.b, alphaInicial);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

	public float beginFade (int direction)
	{
		fadeDir = direction;
		return (fadeSpeed); //Retorna fadeSpeed pra calcular o tempo
	}

	//OnLevelWasLoaded é chamado quando o level é carregado. Pega o index(int) como parametro para definir onde vai ter fade
	void OnLevelWasLoaded()
	{
		//alpha = 1; //Usar para o caso do alpha não estar em 1 por padrão
		beginFade(-1); //Chama o fade
	}

	public IEnumerator fadeCena(int numCena)
	{
		float fadeTime = GameObject.Find("Main Camera").GetComponent<Fading>().beginFade(1);
		//float fadeTime = GameObject.FindObjectOfType<Fading>;
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene (numCena);
	}

	public void mudarCena(int numCena)
	{
		//sceneStarting = false;
		StartCoroutine("fadeCena", numCena);
	}
}
