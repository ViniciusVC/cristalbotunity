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
	public Text TxtInfPontos; // Total de pontos da faze.

	public Text infoText; // Legendas.
	public Text tempoText; // Energia do personagem.

	public Text energiaText; // Energia do personagem.
	public Text ObjTxtInfFaseNivel; // Informação de Planeta e Nivel. 

	public bool Movendo; // Personagem esta se movendo? sim ou não.
	//public bool PossueCrisal; // Personagem esta carregando cristal? sim ou não.

	private string LetraMenuBut; //Botão de direção que foi clicado.

	public static string carregandocristal; //"","A","B","C","D","E"
	
	public static int LimpaCristais; // Total de cristais a serem limpos no laboratorio;


	public Vector3 RotateAtual; // Vetor 3D da direção do Personagem.	
	
	public GameObject[] ObjCritalNaGara; // Objeto 3D Cristal no terreno.

	//public GameObject ObjCrisMov; // Objeto cristal na garra do Robo. 

	public GameObject objPortaNave; // Objeto 3D Porta da nave

	public GameObject ObjBarraEnergia; // Objeto UX ->  Barra de Energia.

	public GameObject ObjBarraCristal; // Objeto UX -> Barra de cristal .
	public GameObject ObjBarraTempo; // Objeto UX -> Barra de cristal .

	public static int countCristais; // a contagem de objetos coletados até o momento
	public static int Pontos; // Pontos da fase (TxtInfPontos);

	// Declarando(Criando) variaveis privadas  
	private Rigidbody rb; // CorpoRigido no personagem.

	private int varEnergia; // Variavel de energia do personagem.
	private int varTempo; // Variavel de Tempo da faze.

	private int AnguloDestino;
	private int AnguloAtual;

	private int varNivelAtual;

	private int limiteCargaCristais;

	private GameObject objtemporario;// = FindObjectOfType<PortaNave>();

	// === inicio do game =================
	void Start ()
	{

		AnguloDestino=0;
		AnguloAtual=0; // Direção que o corpo do robo esta.
		//PossueCrisal=false; //Ao iniciar não está carregando criatal.
		
		controleMenu.LinguaGame="portugues"; // Lingua do texto (ingles/portugues)
		countCristais = 0; // Total de cristais extraidos.
		Pontos = 0;
		varEnergia = 1000; // Energia inicia em 1000.

		carregandocristal=""; // "","A","B","C","D","E"

		funcCristalGarra("");
	
		IniciarNivel(1);

		// Atribua o componente Rigidbody a variável privada rb (CorpoRigido no player)
		rb = GetComponent<Rigidbody>();
		SetCountText ();

		infoText.text = VerificaLingua("Recolha os cristais.","Collect the crystals.");
		// Defina a propriedade text da nossa interface de usuário do Win Text como uma string vazia,
		//winText.text = ""; // Deixando o campo 'Você Ganhou' (mensagem de game over) em branco.
		//FuncAbrirPorta();	
		Time.timeScale=1;
	}


	private void funcCristalGarra(string numObJCris){
		// Esconder Cristais da Garra do Robo.
		ObjCritalNaGara[0].gameObject.SetActive(false);
		ObjCritalNaGara[1].gameObject.SetActive(false);
		ObjCritalNaGara[2].gameObject.SetActive(false);
		ObjCritalNaGara[3].gameObject.SetActive(false);
		ObjCritalNaGara[4].gameObject.SetActive(false);
		// Esconder cristais do laboratorio.
		if(numObJCris=="A"){
			ObjCritalNaGara[0].gameObject.SetActive(true);
		}else if(numObJCris=="B"){
			ObjCritalNaGara[1].gameObject.SetActive(true);
		}else if(numObJCris=="C"){
			ObjCritalNaGara[2].gameObject.SetActive(true);
		}else if(numObJCris=="D"){
			ObjCritalNaGara[3].gameObject.SetActive(true);
		}else if(numObJCris=="E"){
			ObjCritalNaGara[4].gameObject.SetActive(true);
		}
	}

	private string VerificaLingua(string varTextoBr, string varTextoIng)
	{
		if(controleMenu.LinguaGame=="portugues"){
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
		//varEnergia de 0 até 10000 (0.0f=0) (0.1f=???) (0.3f=???) (0.5f=???) (0.8f=???) (1.0f=10000)
		Vector3 PorcentagemBarra = new Vector3 (FuncCalcBarra(10000,varTempo), 1.0f, 1.0f);
		ObjBarraTempo.gameObject.transform.localScale = PorcentagemBarra;
	}

	private void FuncGiraCorpoRobo(float moveHorizontal,float moveVertical)
	{
		// Reconhece o angulo a ser rotacionado.
		if(moveHorizontal==0 & moveVertical>0){
			//print("Subindo ^ ");
			AnguloDestino = 180;
			//FindObjectOfType<controleMenu>().GetComponent<controleMenu>().PainelMenuMostra();
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
		if(Time.timeScale>0){
			funcCristalGarra(carregandocristal);
			if(varTempo>0){
				varTempo = varTempo-1;
				tempoText.text = VerificaLingua("Tempo : ","Time : ")+varTempo.ToString();
				FuncBarraTempo();
			}else if(varTempo==0){
				varEnergia = 0;
				//AudioControler.rodarSom = "SemEnergia"; // "PortaNave","Cristal","SemEnergia"
				//winText.text = VerificaLingua("Não conseguiu recolher os cristais a tempo.","He was unable to collect the crystals in time.");
				infoText.text = VerificaLingua("Não conseguiu recolher os cristais a tempo.","He was unable to collect the crystals in time.");
				string TextoDeFimDeJogo = VerificaLingua("Não conseguiu recolher os cristais a tempo.","He was unable to collect the crystals in time.");
				string TextoBotaoFimDeJogo = VerificaLingua("Voltar","Retur");
				//FimFaseController.FimFaseController.PerdeuFimFase(VerificaLingua("Não conseguiu recolher os cristais a tempo.","He was unable to collect the crystals in time.")).
				FindObjectOfType<FimFaseController>().GetComponent<FimFaseController>().PerdeuFimFase(TextoDeFimDeJogo,TextoBotaoFimDeJogo);
			}

			if(varEnergia>0){
				varEnergia = varEnergia-1;
				energiaText.text = VerificaLingua("Energia : ","Energy : ")+varEnergia.ToString();
				FuncBarraEnergia();
			}else if(varEnergia<=0){
				//varEnergia = varEnergia-1;
				//AudioControler.rodarSom = "SemEnergia"; // "PortaNave","Cristal","SemEnergia"
				infoText.text = VerificaLingua("Pouca energia. Volte a cabine.","Little energy. Go back to the cabin.");
			}
		}
	}

public void butPare(){
		print("Clicou no Pare");
		LetraMenuBut = "";
	}
public void butA(){
		print("Clicou no A");
		if(LetraMenuBut == "A"){
			LetraMenuBut = "";
		}else{
			LetraMenuBut = "A";
		}
	}

	public void butD(){
		print("Clicou no D");
		if(LetraMenuBut == "D"){
			LetraMenuBut = "";
		}else{
			LetraMenuBut = "D";
		}
	}

	public void butE(){
		print("Clicou no E");
		if(LetraMenuBut == "E"){
			LetraMenuBut = "";
		}else{
			LetraMenuBut = "E";
		}
	}

	public void butQ(){
		print("Clicou no Q");
		if(LetraMenuBut == "Q"){
			LetraMenuBut = "";
		}else{
			LetraMenuBut = "Q";
		}
	}

	public void butS(){
		print("Clicou no S");
		if(LetraMenuBut == "S"){
			LetraMenuBut = "";
		}else{
			LetraMenuBut = "S";
		}
	}

	public void butW(){
		print("Clicou no W");
		if(LetraMenuBut == "W"){
			LetraMenuBut = "";
		}else{
			LetraMenuBut = "W";
		}
	}

	public void butX(){
		print("Clicou no X");
		if(LetraMenuBut == "X"){
			LetraMenuBut = "";
		}else{
			LetraMenuBut = "X";
		}
	}

	public void butZ(){
		print("Clicou no Z");
		if(LetraMenuBut == "Z"){
			LetraMenuBut = "";
		}else{
			LetraMenuBut = "Z";
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
				FindObjectOfType<controleMenu>().GetComponent<controleMenu>().PainelMenuMostra();
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
		SetCountText();
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
			Vector3 positEfeito = new Vector3 (objPortaNave.gameObject.transform.position.x-7.0f,objPortaNave.gameObject.transform.position.y+1.0f,objPortaNave.gameObject.transform.position.z+5.0f);
			FindObjectOfType<controleEfeitos>().GetComponent<controleEfeitos>().funcEfeitoCristal2(positEfeito);
		}
	}

	// função que verifique verifica pontos e muda mensagens de texto
	void SetCountText()
	{
		if (countCristais>=limiteCargaCristais)  //Pode ser de 1 a 12. (Cristais recolhidos no laboratorio)
		{
			//countCristais = 0;
			if(varNivelAtual<3){
				countText.text = VerificaLingua("Cristais : 0","Crystals : 0");
				infoText.text = VerificaLingua("Desafio concuido. Pontos:"+Pontos.ToString(),"Challenge met. Score:"+Pontos.ToString());
				string TextoDeFimDeJogo = VerificaLingua("Não conseguiu recolher os cristais a tempo.","He was unable to collect the crystals in time.");
				string TextoBotaoFimDeJogo = VerificaLingua("Voltar","Retur");
				IniciarNivel(varNivelAtual+1);
				FuncFecharPorta();
			}else{
				//print("******* varNivelAtual="+varNivelAtual.ToString());
				countText.text = VerificaLingua("Todos os Cristais.","All Crystals.");
				infoText.text = VerificaLingua("Desafio concuido. Explore outros planetas. Pontos:"+Pontos.ToString(),"Challenge met. Explore other planets. Score:"+Pontos.ToString());
				//winText.text = VerificaLingua("Parabéns!\nDesafio concuido.\nExplore outros planetas. Pontos:"+Pontos.ToString(),"Congratulations!\nChallenge met.\nExplore other planets. Score:"+Pontos.ToString());
				subirNivelJogador();
				string textoFinal=VerificaLingua("Parabéns!\nDesafio concuido. Pontos:"+Pontos.ToString()+".\nExplore outros planetas.","Congratulations!\nChallenge met. Score:"+Pontos.ToString()+".\nExplore other planets.");
				string textoBt="Novo Destino";
				int trofeus=1;
				if(Pontos>880){
					trofeus=3;
				}else if(Pontos>440){ 
					trofeus=2;
				}
				FindObjectOfType<FimFaseController>().GetComponent<FimFaseController>().GanhoFimFase(textoFinal, textoBt, trofeus);
			}
		}
		else
		{
			TxtInfPontos.text = "Pontos "+ Pontos.ToString();
			infoText.text = VerificaLingua("Pegue outro cristal.","Take another crystal.");
			countText.text = VerificaLingua("Cristais : ","Crystals : " )+ countCristais.ToString ();
		}
	}

	private void subirNivelJogador()
	{
		print("PlayerController -> subirNivelJogador()");
		if(controleMenu.nivelJogador>=5){
				print("*******************nivelJogador+=1");
				controleMenu.nivelJogador=controleMenu.nivelJogador+1;
		}else if(controleMenu.CenarioAtualstatic=="Marte"){
			if(controleMenu.nivelJogador<1){
				print("*******************nivelJogador=1");
				controleMenu.nivelJogador=1; // Subir nivel do Jogador 
			}
		}else if(controleMenu.CenarioAtualstatic=="Lua"){
			if(controleMenu.nivelJogador<2){
				print("*******************nivelJogador=2");
				controleMenu.nivelJogador=2; // Subir variavel nivel do Jogador 
			}
		}else if(controleMenu.CenarioAtualstatic=="Plutao"){
			if(controleMenu.nivelJogador<3){
				controleMenu.nivelJogador=3; // Subir variavel nivel do Jogador 
				print("*******************nivelJogador=3");
			}
		}else if(controleMenu.CenarioAtualstatic=="Mercurio"){
			if(controleMenu.nivelJogador<4){
				controleMenu.nivelJogador=4; // Subir variavel nivel do Jogador
				print("*******************nivelJogador=4");
			}
		}else if(controleMenu.CenarioAtualstatic=="Venus"){
			if(controleMenu.nivelJogador<5){
				controleMenu.nivelJogador=5; // Subir variavel nivel do Jogador
				print("*******************nivelJogador=5");
			} 
		} 
	} 
		

	private void IniciarNivel(int varProximoNivel)
	{
		ObjTxtInfFaseNivel.text = controleMenu.CenarioAtualstatic + " nivel "+varProximoNivel.ToString();

		print("PlayerController->IniciarNivel(varProximoNivel)");
		varNivelAtual = varProximoNivel; // Nivel da fase;
		countCristais = 0;
		int ajusteTempoNivel=controleMenu.nivelJogador*100+varProximoNivel*100;
		if(ajusteTempoNivel>9000){
			ajusteTempoNivel=9000;
		}
		varTempo = 10000-ajusteTempoNivel; // O Tempo da Faze.
		LimpaCristais = 12; // Limpar os 12 cristais do laboratorio;
		
		if(varNivelAtual==1){
			limiteCargaCristais=5;
		}else if(varNivelAtual==2){
			limiteCargaCristais=7;
		}else{
			limiteCargaCristais=9;
		}
 
		print("Iniciando Nivel "+ varProximoNivel.ToString() + ". (script player)");
		AudioControler.rodarSom = "VoodaNave";
		NaveControler.varStatusNave="nivel"+varProximoNivel.ToString();
	}

	private void FuncFecharPorta()
	{
		//FindObjectOfType<controleMenu>().GetComponent<controleMenu>().PainelMenuMostra();
		//FindObjectOfType<game_porta_nave>().GetComponent<PortaControler>().AbrirPorta();
		//FindObjectOfType<Nave>().FindObjectOfType<PortaNave>().GetComponent<PortaControler>().FecharPorta();
		//FindObjectOfType<PortaNave>().GetComponent<PortaControler>().FecharPorta();
		//FindObjectOfType<PortaNave>().GetComponent<PortaControler>().FecharPorta();

		//objtemporario = FindObjectOfType<Nave>();
		//objtemporario.GetComponent<PortaControler>().FecharPorta();;

		PortaControler.varStatusPorta = "fechando"; //"", "abrindo", "fechando"
		AudioControler.rodarSom = "PortaNave"; // "PortaNave","Cristal","SemEnergia"		
	}

}