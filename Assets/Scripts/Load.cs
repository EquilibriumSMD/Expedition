using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Load : MonoBehaviour {
	/*
	IEnumerator LoadingLevel (int i) {
         Async = Application.LoadLevelAsync (i);
         yield return Async;
     }

	void OnGUI () {
		if (async != null) {
			GUI.DrawTexture (new Rect (0, 0, 100, 50), ProgressBarEmpty);
			GUI.DrawTexture (new Rect (0, 0, 100* async.progress, 50), ProgressBarFull);
		}
	}

	*/


	private bool loadScene = false;

	[SerializeField]
	private string scene;
	[SerializeField]
	private Text loadingText;

	AsyncOperation async = null;
	public Texture ProgressBarEmpty;
	public Texture ProgressBarFull;


	void Start() {
		scene = Menu.nextScene;
	}

	// Updates once per frame
	void Update() {

		// If the player has pressed the space bar and a new scene is not loading yet...
		if (loadScene == false) {

			// ...set the loadScene boolean to true to prevent loading a new scene more than once...
			loadScene = true;

			// ...change the instruction text to read "Loading..."
			loadingText.text = "Loading...";

			// ...and start a coroutine that will load the desired scene.
			StartCoroutine(LoadNewScene());

		}

		// If the new scene has started loading...
		if (loadScene == true) {

			// ...then pulse the transparency of the loading text to let the player know that the computer is still working.
			loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));

		}

         /*if (async != null) {
             GameObject.Find ("protagonista").transform.position = Vector3.MoveTowards(GameObject.Find ("protagonista").transform.position, new Vector3 (-528f + 975*async.progress, -309f, 58f), Time.deltaTime);
         }*/

	}

	// The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
	IEnumerator LoadNewScene() {

		// This line waits for 3 seconds before executing the next line in the coroutine.
		// This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
		yield return new WaitForSeconds(1);

		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
		async = Application.LoadLevelAsync(scene);

		// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
		while (!async.isDone) {
			yield return null;
		}

	}

}