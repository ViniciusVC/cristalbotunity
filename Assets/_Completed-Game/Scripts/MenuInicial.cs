
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour {

	public void LoadScene(string name){
		print("ir para a fase " + name);
		// Usar "SceneManager.LoadScene" ou "Application.LoadLevel"?
		// SceneManager.LoadScene é a maneira mais nova. O SceneManager oferece uma interface melhor para carregar cenas e descobrir quais cenas estão carregadas no momento.
		// SceneManagement.LoadScene(name);
		SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Additive);
		//SceneManagement.LoadScene(name);
		SceneManager.LoadScene(name);
		// Application.LoadLevel é a maneira mais antiga. Está obsoleto. Não conte com ele a longo prazo. Está versão mais antiga não tinha como descobrir quais cenas já estão carregadas. Isso realmente só permite que você carregue uma cena
		// Application.LoadLevel(name);
	}

	public void QuitGame(){
		Application.Quit();
	}

}
