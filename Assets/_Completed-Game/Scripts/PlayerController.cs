using UnityEngine;
// Include the namespace required to use Unity UI
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	
	// Declarando(Criando) variaveis publicas 
	public float speed; // Velocidade do personagem.
	
	// Declarar os Campos de Text UI game objects.
	public Text countText; // Contagem de cristais.
	public Text winText; // Mensagem de inicio e fim de jogo.
	public Text infoText; // Legendas.

	public Text tempoText; // Energia do personagem.

	public Text energiaText; // Energia do personagem.

	public bool Movendo; // Personagem esta se movendo? sim ou não.
	public bool PossueCrisal; // Personagem esta carregando cristal? sim ou não.

	public static string LetraMenuBut; //Botão de direção que foi clicado.

	public static string LinguaGame; // Lingua do texto (ingles/Portugues)
	public Vector3 RotateAtual; // Vetor 3D da direção do Personagem.	
	
	public GameObject ObjCrisLab1; // Objeto 3D Cristal Laboratorio.
	public GameObject ObjCrisLab2; // Objeto 3D Cristal Laboratorio.  
	public GameObject ObjCrisLab3; // Objeto 3D Cristal Laboratorio.
	public GameObject ObjCrisLab4; // Objeto 3D Cristal Laboratorio.
	public GameObject ObjCrisLab5; // Objeto 3D Cristal Laboratorio.  
	public GameObject ObjCrisLab6; // Objeto 3D Cristal Laboratorio.  
	public GameObject ObjCrisLab7; // Objeto 3D Cristal Laboratorio.  
	public GameObject ObjCrisLab8; // Objeto 3D Cristal Laboratorio.  
	public GameObject ObjCrisLab9; // Objeto 3D Cristal Laboratorio.  
	public GameObject ObjCrisLab10; // Objeto 3D Cristal Laboratorio.  
	public GameObject ObjCrisLab11; // Objeto 3D Cristal Laboratorio.  
	public GameObject ObjCrisLab12; // Objeto 3D Cristal Laboratorio.  
	public GameObject ObjCrisMov; // Objeto cristal na garra do Robo. 

	public GameObject objPortaNave; // Objeto 3D Porta da nave
	public GameObject ObjPainelMenu; // Menu Principal do game.

	public GameObject ObjBarraEnergia; // Objeto UX ->  Barra de Energia.

	public GameObject ObjBarraCristal; // Objeto UX -> Barra de cristal .
	public GameObject ObjBarraTempo; // Objeto UX -> Barra de cristal .


	// Declarando(Criando) variaveis privadas  
	private Rigidbody rb; // CorpoRigido no personagem.
	private int countCristais; // a contagem de objetos coletados até o momento
	private int varEnergia; // Variavel de energia do personagem.
	private int varTempo; // Variavel de Tempo da faze.

	private int AnguloDestino;
	private int AnguloAtual;

	private int varNivelAtual;

	// === inicio do game =================
	void Start ()
	{
		AnguloDestino=0;
		AnguloAtual=0; // Direção que o corpo do robo esta.
		PossueCrisal=false; //Ao iniciar não está carregando criatal.
		LinguaGame="portugues"; // Lingua do texto (ingles/portugues)
		countCristais = 0; // Total de cristais extraidos.
		varEnergia = 1000; // Energia inicia em 1000.

		IniciarNivel(1);

		// Atribua o componente Rigidbody a variável privada rb (CorpoRigido no player)
		rb = GetComponent<Rigidbody>();
		SetCountText ();

		infoText.text = VerificaLingua("Recolha os cristais.","Collect the crystals.");
		// Defina a propriedade text da nossa interface de usuário do Win Text como uma string vazia,
		winText.text = ""; // Deixando o campo 'Você Ganhou' (mensagem de game over) em branco.
		//FuncAbrirPorta();
	}

	private string VerificaLingua(string varTextoBr, string varTextoIng)
	{
		if(LinguaGame=="portugues"){
			return varTextoBr;
		}else{
			return varTextoIng;
		}
	}

	private float FuncCalcBarra(int valorMax, int varCalcInicial)
	{
		// Como descobrir percentual de um número
		// Pegue o número menor, divida pelo maior, e em seguida multiplique por cem.
		// Vai de 0% a 100%. Mas eu quero de 0 a 1. Dividir por 100 (Ex.:0,0 0,01 0,50 0,90 1,00)
		float varCalcSaida= (float)varCalcInicial/(float)valorMax;
		//print("varCalcSaida="+ varCalcSaida.ToString());
		return varCalcSaida;
	}
	
	private void FuncBarraEnergia()
	{
		float valorBarraEnergia = FuncCalcBarra(2000,varEnergia);
		//varEnergia de 0 até 2000 (0.0f=0) (0.1f=10) (0.3f=500) (0.5f=1000) (0.8f=1500) (1.0f=2000)
		Vector3 PorcentagemBarra = new Vector3 (valorBarraEnergia, 1.0f, 1.0f);
		ObjBarraEnergia.gameObject.transform.localScale = PorcentagemBarra;
	}

	private void FuncBarraCristais()
	{
		//varEnergia de 0 até 1000 (0.0f=0) (0.1f=1) (0.3f=3) (0.5f=6) (0.8f=9) (1.0f=12)
		Vector3 PorcentagemBarra = new Vector3 (FuncCalcBarra(12,countCristais), 1.0f, 1.0f);
		ObjBarraCristal.gameObject.transform.localScale = PorcentagemBarra;
	}

	private void FuncBarraTempo()
	{
		//varEnergia de 0 até 1000 (0.0f=0) (0.1f=???) (0.3f=???) (0.5f=???) (0.8f=???) (1.0f=10000)
		Vector3 PorcentagemBarra = new Vector3 (FuncCalcBarra(12,varTempo), 1.0f, 1.0f);
		ObjBarraTempo.gameObject.transform.localScale = PorcentagemBarra;
	}

	private void FuncGiraCorpoRobo(float moveHorizontal,float moveVertical)
	{
		// Reconhece o angulo a ser rotacionado.
		if(moveHorizontal==0 & moveVertical>0){
			//print("Subindo ^ ");
			AnguloDestino = 180;
		}else if(moveHorizontal==0 & moveVertical<0){
			//print("Descendo v ");
			AnguloDestino = 0;
		}else if(moveHorizontal>0 & moveVertical==0){
			//print("Esquerda -> ");
			AnguloDestino = 270;
		}else if(moveHorizontal<0 & moveVertical==0){
			//print("Direita <- ");
			AnguloDestino = 90;
		}else if(moveHorizontal>0 & moveVertical>0){
			//print("Angulo Esquerda ->  Subindo ^ / ");
			AnguloDestino = 225;
		}else if(moveHorizontal<0 & moveVertical>0){
			//print("Angulo Direita <- Subindo ^ \\ ");
			AnguloDestino = 135;
		}else if(moveHorizontal>0 & moveVertical<0){
			//print("Angulo Esquerda -> Descendo v \\ ");
			AnguloDestino = 315; // 270+45 0 e 270 ;//45;
		}else if(moveHorizontal<0 & moveVertical<0){
			//print("Angulo Direita <- Descendo v / ");
			AnguloDestino = 45; //0 e 90;//210;
		}

		// Gira o Robo. 
		if(AnguloDestino!=AnguloAtual){
			//print("if(AnguloDestino!=AnguloAtual)");
			AnguloAtual=AnguloDestino;
			Quaternion rotacaoAtual = rb.rotation; 
			Quaternion rotacaoAlvo = Quaternion.Euler(0,AnguloDestino,0);
			Quaternion novaRotacao = Quaternion.Lerp(rotacaoAtual,rotacaoAlvo,1);
			rb.MoveRotation(novaRotacao);
		}

	}

	private void FuncMoveRobo(float moveHorizontal,float moveVertical)
	{
			// Crando uma variável de Vector3D e tribua X, Y e Z
			// x=horizontal, y=0.0f, z = vertical
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

			// Adicione uma força física ao rb(CorpoRigido) usando nosso 'movimento'(Vector3) acima,
			// multiplicando-o por 'speed' - a velocidade do nosso player público que aparece no inspetor
			rb.AddForce(movement * speed);

	}



	void LateUpdate ()
	{	
		if(varTempo>0){
			varTempo = varTempo-1;
			tempoText.text = VerificaLingua("Tempo : ","Time : ")+varTempo.ToString();
			FuncBarraTempo();
		}else if(varEnergia==0){
			varEnergia = varEnergia-1;
			AudioControler.rodarSom = "SemEnergia"; // "PortaNave","Cristal","SemEnergia"
			infoText.text = VerificaLingua("Não conseguiu recolher os cristais a tempo.","He was unable to collect the crystals in time.");
		}

		if(varEnergia>0){
			varEnergia = varEnergia-1;
			energiaText.text = VerificaLingua("Energia : ","Energy : ")+varEnergia.ToString();
			FuncBarraEnergia();
		}else if(varEnergia==0){
			varEnergia = varEnergia-1;
			AudioControler.rodarSom = "SemEnergia"; // "PortaNave","Cristal","SemEnergia"
			infoText.text = VerificaLingua("Pouca energia. Volte a cabine.","Little energy. Go back to the cabin.");
		}
	}

	// === Física do game =================
	void FixedUpdate()
	{
		float Submit = Input.GetAxis("Submit");
		float Cancel = Input.GetAxis("Cancel");
		if(Submit!=0 || Cancel!=0 || Input.GetKeyDown(KeyCode.Escape)){
			// Abrir PainelMenu
			//controleMenu.MenuMostra();
			if(controleMenu.estadoPainelMenu==true){
				print("Sair");
				Application.Quit();
			}else{
				controleMenu.estadoPainelMenu=true;
				ObjPainelMenu.gameObject.SetActive(true);
			}
		}else{
			// Defina algumas variáveis flutuantes locais iguais ao valor de nossas entradas horizontais e verticais	
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");
			
			if(moveHorizontal==0 & moveVertical==0){
				if (Input.GetKeyDown ("q") || LetraMenuBut=="Q")
				{
					//print("Q");
					moveHorizontal = -0.5f;
					moveVertical = 0.5f;
				}
				else if (Input.GetKeyDown ("e") || LetraMenuBut=="E")
				{
					//print("E");
					moveHorizontal = 0.5f;
					moveVertical = 0.5f;
				}
				else if (Input.GetKeyDown ("z") || LetraMenuBut=="Z")
				{
					//print("Z");
					moveHorizontal = -0.5f;
					moveVertical = -0.5f;
				}
				else if (Input.GetKeyDown ("x") || LetraMenuBut=="X")
				{
					//print("X");
					moveHorizontal = 0.5f;
					moveVertical = -0.5f;
				}
				else if (LetraMenuBut=="W"){
					//print("PlayerControlle -> LetraMenuBut : " + LetraMenuBut);
					//print("W");
					moveHorizontal = 0.0f;
					moveVertical = 0.5f;
				}
				else if (LetraMenuBut=="S"){
					//print("PlayerControlle -> LetraMenuBut : " + LetraMenuBut);
					//print("S");
					moveHorizontal = 0.0f;
					moveVertical = -0.5f;
				}
				else if (LetraMenuBut=="A"){
					//print("PlayerControlle -> LetraMenuBut : " + LetraMenuBut);
					//print("A");
					moveHorizontal = -0.5f;
					moveVertical = 0.0f;
				}
				else if (LetraMenuBut=="D"){
					//print("PlayerControlle -> LetraMenuBut : " + LetraMenuBut);
					//print("D");
					moveHorizontal = 0.5f;
					moveVertical = 0.0f;
				}
			}
			//print("Vetor 3D -> moveHorizontal="+moveHorizontal);
			if(moveHorizontal==0 & moveVertical==0){
				// Parado
				Movendo=false;
				GiraRodas.Movendo=false;
				
				//rb.roda1.transform.Rotate (new Vector3 (20, 0, 0));
				//transform.Rotate (new Vector3 (0.0f, 0, 0.0f));	
			}else{
				// Movendo
				Movendo=true;
				GiraRodas.Movendo=true;
				if(varEnergia<10){
					moveHorizontal = moveHorizontal/2;
					moveVertical = moveVertical/2; 
				}
				FuncMoveRobo(moveHorizontal, moveVertical);			
				FuncGiraCorpoRobo(moveHorizontal, moveVertical); 
			}
		}
	}

	void OnTriggerEnter(Collider other) 
	{
	// Quando este objeto colidir com 'is trigger' marcado, 
	// A variável 'other' recebe uma referência ao objeto colisor.

		if(other.gameObject.CompareTag("Tambor"))
		{
			// colidiu com um objeto com a tag 'Tambor'?
			print("Colidiu com um Tambor");
			AudioControler.rodarSom = "Meteoro";
			varEnergia = varEnergia - 500;
		}
		else if(other.gameObject.CompareTag("Cabine"))
		{
			// colidiu com um objeto com a tag 'Cabine'?
			print("Cabine");
			varEnergia = 2000;
			infoText.text = VerificaLingua("A cabine recarrega sua bateria.","The cabin recharges its battery.");
		}
		else if(other.gameObject.CompareTag("Laboratorio"))
		{
			// colidiu com um objeto com a tag 'Laboratorio'?
			print("Laboratorio");
			if(PossueCrisal){
				PossueCrisal = false;
				AudioControler.rodarSom = "Cristal"; // "PortaNave","Cristal","SemEnergia"
				infoText.text = VerificaLingua("Deixou o cristal no laboratorio.","He left the crystal in the laboratory.");
				// Add one to the score variable 'countCristais'
				countCristais = countCristais + 1;
				FuncBarraCristais();
				ObjCrisMov.gameObject.SetActive(false);
				if(countCristais==1){
					ObjCrisLab1.gameObject.SetActive(true);
				}else if(countCristais==2){
					ObjCrisLab2.gameObject.SetActive(true);
				}else if(countCristais==3){
					ObjCrisLab3.gameObject.SetActive(true);
				}else if(countCristais==4){
					ObjCrisLab4.gameObject.SetActive(true);
				}else if(countCristais==5){
					ObjCrisLab5.gameObject.SetActive(true);
				}else if(countCristais==6){
					ObjCrisLab6.gameObject.SetActive(true);
				}else if(countCristais==7){
					ObjCrisLab7.gameObject.SetActive(true);
				}else if(countCristais==8){
					ObjCrisLab8.gameObject.SetActive(true);
				}else if(countCristais==9){
					ObjCrisLab9.gameObject.SetActive(true);
				}else if(countCristais==10){
					ObjCrisLab10.gameObject.SetActive(true);
				}else if(countCristais==11){
					ObjCrisLab11.gameObject.SetActive(true);
				}else if(countCristais>12){
					ObjCrisLab12.gameObject.SetActive(true);
				}
				SetCountText();
			}else{
				infoText.text = VerificaLingua("Este é o laboratorio.","This is the laboratory.");
			}
		}
		else if(other.gameObject.CompareTag("Pick Up"))
		{
			// colidiu com um objeto com a tag 'Pick Up'?
			AudioControler.rodarSom = "Cristal"; // "PortaNave","Cristal","SemEnergia"
			if (PossueCrisal){
				infoText.text = VerificaLingua("Só é possivel carregar um cristal.","It is only possible to carry a crystal.");
			}else{
				PossueCrisal = true;
				//ObjetoCristal = other.gameObject;

				// infoText.text = "pegou o " + other.gameObject.ToString;
				
				infoText.text = VerificaLingua("Pegou um criatal. Leve-o ao laboratorio.","He took a crystal. Take it to the laboratory.");
				//nomeObjeto = "Pick Up (5) (UnityEngine.GameObject)";
				
				// Esconder cristal que foi extraido.
				other.gameObject.SetActive(false);
				
				// Mostrar cristal na garra do Robo.
				ObjCrisMov.gameObject.SetActive(true);
			}
		}

	}

	// função que verifique verifica pontos e muda mensagens de texto
	void SetCountText()
	{
		if (countCristais >= 12) 
		{
			if(varNivelAtual<3){
				countText.text = VerificaLingua("Cristais : 0","Crystals : 0");
				infoText.text = VerificaLingua("Desafio concuido. Vamos ao próximo nível.","Challenge met. Next level!");
				//winText.text = VerificaLingua("Próximo nível!","Next level!");				
				IniciarNivel(varNivelAtual+1);
				FuncFecharPorta();
			}else{
				countText.text = VerificaLingua("Todos os Cristais.","All Crystals.");
				infoText.text = VerificaLingua("Desafio concuido. Explore outros planetas.","Challenge met. Explore other planets.");
				winText.text = VerificaLingua("Parabéns!","Congratulations!");
			}
		}
		else
		{
			infoText.text = VerificaLingua("Pegue outro cristal.","Take another crystal.");
			countText.text = VerificaLingua("Cristais : ","Crystals : " )+ countCristais.ToString ();
		}
	}

	private void IniciarNivel(int varProximoNivel){
		varNivelAtual = varProximoNivel;
		countCristais = 0;
		
		varTempo = 10000; // O Tempo da Faze.
	
		// Esconder cristais do laboratorio.
		ObjCrisLab1.gameObject.SetActive(false);		
		ObjCrisLab2.gameObject.SetActive(false);
		ObjCrisLab3.gameObject.SetActive(false);
		ObjCrisLab4.gameObject.SetActive(false);
		ObjCrisLab5.gameObject.SetActive(false);
		ObjCrisLab6.gameObject.SetActive(false);
		ObjCrisLab7.gameObject.SetActive(false);
		ObjCrisLab8.gameObject.SetActive(false);
		ObjCrisLab9.gameObject.SetActive(false);
		ObjCrisLab10.gameObject.SetActive(false);
		ObjCrisLab11.gameObject.SetActive(false);
		ObjCrisLab12.gameObject.SetActive(false);
		ObjCrisMov.gameObject.SetActive(false);

		print("Iniciando Nivel "+ varProximoNivel.ToString() + ". (script player)");
		// Debug.log("log-Inicou o GAME.");
		
		//AudioControler.rodarSom = "VoodaNave";
		NaveControler.varStatusNave="nivel"+varProximoNivel.ToString();
	}

	private void FuncFecharPorta()
	{
		PortaControler.varStatusPorta = "fechando"; //"", "abrindo", "fechando"
		AudioControler.rodarSom = "PortaNave"; // "PortaNave","Cristal","SemEnergia"		
	}

}