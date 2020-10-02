
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class controleMenu : MonoBehaviour {

	public GameObject ObjPainelMenu; // Menu principal do jogo.
	public GameObject ObjPainelDirecional; // Painel de controles.  
	public GameObject ObjPainelCreditos; // Painel com os créditos do jogo.
	public GameObject ObjPainelPlaneta; // Painel onde o jogador escolhe o cenario.
	public GameObject ObjPainelLingua; // Painel onde o jogador escolhe a lingua do jogo.
	//public GameObject ObjPainelFimFase; // Painel onde mostra a mensagem de parabéns.
	public Text TxtPanPlanetasTitulo; // Titulo do Painel de Planetas
	public Text TxtPanPlanetasVoltar; // Texto botão voltar do Painel de Planetas
	public Text TxtPanPlanetasMercurio;
	public Text TxtPanPlanetasVenus;
	public Text TxtPanPlanetasLua;
	public Text TxtPanPlanetasMarte;
	public Text TxtPanPlanetasPlutao;
	public Text TxtCreditos;
	public Text TxtCreditosBtVolta;

	public Text objTxtMenuBtJogar; // Texto do botão de Jogar no menu principal.
	public Text objTxtMenuBtCreditos; // Texto do botão de Creditos no menu principal.
	public Text objTxtMenuBtSair; // Texto do botão de Sair do Jogo no menu principal.
	public Text objTxtMenuBtPlanetas; // Texto do botão Escolher Planetas no menu principal.
	public Text objTxtMenuBtDirecao; // Texto do botão de direção no menu principal.
	public Text objTxtMenuBtLingua; // Texto do botão de Lingua no menu principal.
	public static bool estadoPainelMenu;
	public static bool estadoPainelDirecional;
	private bool estadoPainelCreditos;
	private bool estadoPainelPlaneta;
	private bool estadoPainelLingua;

	public static string CenarioAtualstatic; //"","Mercurio","Venus","Lua","Marte","Plutao";

	public string CenarioAtual; //"","Mercurio","Venus","Lua","Marte","Plutao";

	public static string LinguaGame; //"portugues","ingles"

	public static int nivelJogador; // 0="Marte liberado",1="Marte liberado",2,3,4,5="Ganhou o jogo"


	//private string[] Vogais = ["A","E","I","O","U"];
	//private string[] Consoante = ["B","C","D","F","G","H","J","K","L","M","N","X"];

	private string[] listaNomes = {"BENA","CAGU","DAFE","FEKA","GEHO","HAXE","JIMI","KOLE","LEJA","MUGA","NEDA","XABE"};

	void Start()
	{

		CenarioAtualstatic=CenarioAtual;
		estadoPainelMenu=false; // Iniciar variavel do Painel Menu (static bool).
		estadoPainelDirecional=false; // Iniciar estadoPainelDirecional.
		estadoPainelLingua=false; // Iniciar estadoPainelDirecional.
		estadoPainelCreditos=false;
		estadoPainelPlaneta=false;
		if(CenarioAtual=="MenuInicial"){
			nivelJogador=0; // iniciar variavel nivel do Jogador
			LinguaGame="portugues"; //"portugues","ingles"
		}
	}


	public void PainelMenuMostra(){
		if(estadoPainelMenu==true){
			Time.timeScale=1;
			estadoPainelMenu=false; // esconder menu;
		}else{
			Time.timeScale=0;
			estadoPainelMenu=true; // Mostrar menu;
		} 
		ObjPainelMenu.gameObject.SetActive(estadoPainelMenu);
	}

	public void PainelPlanetaMostra(){
		if(estadoPainelPlaneta==true){
			print("EstadoPainelPlaneta==true. Esconder planeta.");
			estadoPainelPlaneta=false;
			ObjPainelPlaneta.gameObject.SetActive(false);
		}else{
			//Esconter menu principal.
			print("EstadoPainelPlaneta==fase. Esconder Menu.");
			//Mostrar menu planetas.
			estadoPainelPlaneta=true;
			ObjPainelPlaneta.gameObject.SetActive(true);
			TxtPanPlanetasTitulo.text = VerificaLingua("ESCOLHA O DESTINO", "CHOOSE THE DESTINATION");
			TxtPanPlanetasMarte.text = VerificaLingua("Marte", "Mars");
			if(nivelJogador>0){
				TxtPanPlanetasLua.text = VerificaLingua("Lua", "Moon");
			}else{
				TxtPanPlanetasLua.text = "[ ]";
			}
			if(nivelJogador>1){
				TxtPanPlanetasPlutao.text = VerificaLingua("Plutão", "Pluto");
			}else{
				TxtPanPlanetasPlutao.text = "[ ]";
			}
			if(nivelJogador>2){
				TxtPanPlanetasMercurio.text = VerificaLingua("Mercurio", "Mercury");
			}else{
				TxtPanPlanetasMercurio.text = "[ ]";
			}
			if(nivelJogador>3){
				TxtPanPlanetasVenus.text = VerificaLingua("Venus", "Venus");
			}else{
				TxtPanPlanetasVenus.text = "[ ]";
			}
			TxtPanPlanetasVoltar.text = VerificaLingua("Voltar", "Return");
		} 
		//ObjPainelPlaneta.gameObject.SetActive(estadoPainelPlaneta);
	}


	public void PanelDirecionalMostra(){
		if(estadoPainelDirecional){
			estadoPainelDirecional=false;
		}else{
			estadoPainelDirecional=true;			
		}
		ObjPainelDirecional.gameObject.SetActive(estadoPainelDirecional);
	}


	public void PanelCreditosMostra(){
		if(estadoPainelCreditos==true){
			estadoPainelCreditos=false;
			ObjPainelCreditos.gameObject.SetActive(estadoPainelCreditos);
		}else{
			estadoPainelCreditos=true;
			ObjPainelCreditos.gameObject.SetActive(estadoPainelCreditos);
			TxtCreditos.text = VerificaLingua("Jogo Cristal Bot v. 0.2 Beta.\nAutor : Vinicius Valente  Coutinho.\nDesenvolvido na Unity com C#.\nModelagem 3D no Blender.","Game Cristal Bot v. 0.2 Beta.\nAuthor: Vinicius Valente Coutinho.\nDeveloped at Unity with C #.\n3D modeling in Blender.");
			TxtCreditosBtVolta.text = VerificaLingua("Voltar","Return");
		}
	}

	public void PanelLinguaMostra(){
		if(estadoPainelLingua){
			print("estadoPainelLingua==true. mudando para FALSE e esconder Painel Lingua.");
			estadoPainelLingua=false;
		}else{
			print("estadoPainelLingua==false. mudando para TRUE e esconder Painel Lingua.");
			estadoPainelLingua=true;
		}
		//PainelMenuMostra();
		ObjPainelLingua.gameObject.SetActive(estadoPainelLingua);
	}

	public void MudouLingPort(){
		LinguaGame = "portugues"; //"portugues","ingles"
		PanelLinguaMostra();
		if(CenarioAtual=="MenuInicial"){
			objTxtMenuBtJogar.text ="Iniciar jogo"; // Botão de Jogar no menu principal
		}else{
			objTxtMenuBtJogar.text ="Voltar ao jogo"; // Botão de Jogar no menu principal
		}
		objTxtMenuBtCreditos.text="Creditos"; // Botão de Creditos no menu principal
		objTxtMenuBtSair.text="Sair do jogo"; // Botão de Sair do Jogo no menu principal
		objTxtMenuBtPlanetas.text="Escolher planeta"; // Botão Escolher Planetas no menu principal
		objTxtMenuBtDirecao.text="Botões de Direção"; // Botão de direção no menu principal
		objTxtMenuBtLingua.text="Switch to English"; // Botão mudar de Linguia no menu principal
	}
	public void MudouLingIngl(){
		LinguaGame = "ingles"; //"portugues","ingles"
		PanelLinguaMostra();
		if(CenarioAtual=="MenuInicial"){
			objTxtMenuBtJogar.text ="Start game"; // Botão de Jogar no menu principal
		}else{
			objTxtMenuBtJogar.text ="Back in the game"; // Botão de Jogar no menu principal
		}		
		objTxtMenuBtCreditos.text="Credits"; // Botão de Creditos no menu principal
		objTxtMenuBtSair.text="Quit game"; // Botão de Sair do Jogo no menu principal
		objTxtMenuBtPlanetas.text="Choose planet"; // Botão Escolher Planetas no menu principal
		objTxtMenuBtDirecao.text="Direction buttons"; // Botão de direção no menu principal
		objTxtMenuBtLingua.text="Mostrar em Portugues"; // Botão mudar de Linguia no menu principal
	}

	public void CenarioMarteMostra(){
		//Esconder Menu principal.
		PainelPlanetaMostra();
		//Abrir novo cenário.
		IrParaPlaneta("Marte");
	}
	
	public void CenarioLuaMostra(){
		if(nivelJogador>0){
			//Esconder Menu principal.
			PainelPlanetaMostra();
			//Abrir novo cenário.
			IrParaPlaneta("Lua");
		}
	}

	public void CenarioPlutaoMostra(){
		if(nivelJogador>1){
			//Esconder Menu principal.
			PainelPlanetaMostra();
			//Abrir novo cenário.
			IrParaPlaneta("Plutao");
		}
	}

	public void CenarioMercurioMostra(){
		if(nivelJogador>2){
			//Esconder Menu principal.
			PainelPlanetaMostra();
			//Abrir novo cenário.
			IrParaPlaneta("Mercurio");
		}
	}

	public void CenarioVenusMostra(){
		if(nivelJogador>3){
			//Esconder Menu principal.
			PainelPlanetaMostra();
			//Abrir novo cenário.
			IrParaPlaneta("Venus");
		}
	}

	private void IrParaPlaneta(string NovoCenario){
		//if(CenarioAtual!=NovoCenario){
			//CenarioAtual = NovoCenario;
			if(NovoCenario=="Mercurio"){
				//Cada planetas(CENARIO) fica em uma SCENE diferente; 
				LoadScene("mercurio1");
			}else if(NovoCenario=="Venus"){
				//Cada planetas(CENARIO) fica em uma SCENE diferente;
				LoadScene("venus1");
			}else if(NovoCenario=="Lua"){
				//Cada planetas(CENARIO) fica em uma SCENE diferente;
				LoadScene("lua1");
			}else if(NovoCenario=="Marte"){
				//Cada planetas(CENARIO) fica em uma SCENE diferente;
				LoadScene("marte1");
			}else if(NovoCenario=="Plutao"){
				//Cada planetas(CENARIO) fica em uma SCENE diferente;
				LoadScene("plutao1");
			}else{
				//CenarioAtual="";
				print("ERRO - Nenhum Cenario escolhido. NovoCenario=" + NovoCenario);
				LoadScene("MenuInicial");
			}
		//}
	}

	public void QuitGame(){
		Application.Quit();
	}

	private string VerificaLingua(string varTextoBr, string varTextoIng)
	{
		if(LinguaGame=="portugues"){
			return varTextoBr;
		}else{
			return varTextoIng;
		}
	}
	
	
	private void Mudatexto(string varTextoBr, string varTextoIng){
		//novoTexto=VerificaLingua(varTextoBr,varTextoIng);
		//if(novoTexto!=velhoTexto){
		//	velhoTexto=novoTexto
		//	countText.text = velhoTexto
		//}
				//infoText.text = VerificaLingua(varTextoBr,varTextoIng);
				//winText.text = VerificaLingua(varTextoBr,varTextoIng);
	}

	public void LoadScene(string name){
		print("ir para a fase " + name);
		// Usar "SceneManager.LoadScene" ou "Application.LoadLevel"?
		// SceneManager.LoadScene é a maneira mais nova. O SceneManager oferece uma interface melhor para carregar cenas e descobrir quais cenas estão carregadas no momento.
		SceneManager.LoadScene(name);
		//ASSERTA INTERNA: a chamada para OnLevelWasLoaded ficou obsoleta por enquanto, considere removê-la ou interromper a verificação de versão aqui
		
		// SceneManagement.LoadScene(name);
		// SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Additive);
		// SceneManagement.LoadScene(name);
		// Application.LoadLevel é a maneira mais antiga. Está obsoleto. Não conte com ele a longo prazo. Está versão mais antiga não tinha como descobrir quais cenas já estão carregadas. Isso realmente só permite que você carregue uma cena
		// Application.LoadLevel(name);
	}
}