using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristal : MonoBehaviour {

	// Declarar variaveis	// Armazena uma referência pública ao objeto do jogo Player, para que possamos nos referir ao seu Transform.
	public GameObject player;

	// Armazena um deslocamento Vector3 do player (uma distância para colocar a câmera do player o tempo todo).
	private Vector3 offset;


	// Inicialização do jogo. (No início do jogo...)
	void Start ()
	{
		// Crie um deslocamento subtraindo a posição da câmera da posição do player.
		offset = transform.position - player.transform.position;
	}

	// // O Update(atualização) é chamada uma vez por quadro.
	// void Update () {
		
	// }


	// Executa depois que o loop 'Update()' padrão é executado, e imediatamente antes de cada quadro ser renderizado.
	void LateUpdate ()
	{
		// Set the position of the Camera (the game object this script is attached to)
		// to the player's position, plus the offset amount
		transform.position = player.transform.position + offset;
	}
}
