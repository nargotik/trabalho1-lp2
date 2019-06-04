

# Relat�rio Trabalho Pr�tico LP1
A aplica��o a ser desenvolvida no decorrer deste trabalho pr�tico tem como finalidade a gest�o de parques inform�ticos de uma ou v�rias entidades.

� a realiza��o deste trabalho realizar uma abordagem de Aprendizagem de t�cnicas e m�todos de Programa��o Orientada por Objectos, 
assim como a utiliza��o de ferramentas e m�todos de trabalho colaborativo.

__Autores do Trabalho:__
- ___Daniel Torres (<a17442@alunos.ipca.pt>)___
- ___Oscar Silva (<a14383@alunos.ipca.pt>)___

[![CodeFactor](https://www.codefactor.io/repository/github/nargotik/trabalho1-lp2/badge)](https://www.codefactor.io/repository/github/nargotik/trabalho1-lp2)
[![Build Status](https://travis-ci.com/nargotik/trabalho1-lp2.svg?token=qNfqiYyxNzmWoPqpyHnZ&branch=master)](https://travis-ci.com/nargotik/trabalho1-lp2)
<div style="page-break-after: always;"></div>

## Introdu��o
A escolha do tema a desenvolver no trabalho prende-se com a necessidade cada vez maior das empresas de 
desenvolverem metodologias para o controle do seu esp�lio material e virtual.

- A aplica��o dever�:
  - Ser abstracta o suficiente para a reutiliza��o de c�digo para outros sectores/aplica��es.
  - Ter uma vis�o Macro e Micro de todo o invent�rio presente na Entidade.
    - Listagem de equipamentos
    - Listagem por tipo de Equipamentos
    - Listagem por ano de fabrico
    - Listagem por fabricante 
    - ...
  - Adi��o/Remo��o/Edi��o de Items no Invent�rio

Foi pensado em criar um Interface de utilizador por Windows/Consola no entanto ainda ser� um grande desafio aprender WPF

N�o tendo sido poss�vel a aprendizagem de WPF e ao aprofundamento de outras t�cnicas � frente faladas
o projecto UI.Win apenas foi deixado como prova de conceito, assim como n�o foi muito desenvolvido o UI.Cli.

Foi primordialmente focado o desenvolvimento de capacidades de trabalho em grupo e automatizadas, assim como a funcionalidade de uma livraria (DLL) que poder� ser reutilizada em outros contextos.

No entanto todos os m�todos e classes foram testados usando testes unit�rios que podem ser vistos no projecto de Tests.

Os resultados a obter com o desenvolvimento desta solu��o � cria��o de uma aplica��o vers�til e adaptativa �s 
necessidades das diferentes entidades e dever� potencializar uma melhor organiza��o do parque inform�ticos.
<div style="page-break-after: always;"></div>

## M�todo de Trabalho adoptado
Para o desenvolvimento deste trabalho, utilizamos uma metodologia que permite 
a todos os membros do grupo desenvolvam simultaneamente a aplica��o e que haja um 
controle de vers�es desenvolvidas atrav�s do Git. 

Permite ainda dividir a carga de trabalho pois permite que cada elemento do grupo 
desenvolva uma classe espec�fica da aplica��o.

O GitHub em conjunto com outras ferramentas que ser�o abordadas mais � frente no t�pico de Ferramentas/Servi�os de Desenvolvimento 
trazem uma enorme mais valia � produ��o de Software.

Algumas ferramentas utilizadas:
- Travis-ci
  - Travis CI � um servi�o de integra��o cont�nua 
- Codefector
  - Analisador autom�tico de syntax de c�digo
<div style="page-break-after: always;"></div>

## Estrutura de Ficheiros
- __./Libs/Folder/...__
  - Pasta que contem exemplos de items, esta pasta ir� gerar dll's a serem utilizadas pelo ITGest�o
- __./ITGEstao/__
  - Projecto (VS 2017) de um dll ITGestao.dll que pode ser reutilizada
- __./Tests/__
  - Projecto de testes unit�rios
- __./UI.Cli/__
  - Interface de Utilizador (Linha de Comandos)
- __./UI.Win/__
  - Interface Utilizador (Windows) 
    - Apenas serve como prova de conceito da forma que foi dividido o UI da parte L�gica
- __./Utils/__
  - V�rios Utilit�rios a serem usados
- __ITgestao.sln__
  - Solu��o (VS 2017)
- __diagram.png__
  - Diagrama de classes do projecto ITGestao
- __readme.md__
  - Relat�rio
- __.travis.yml__
  - Ficheiro de compila��o autom�tica e Testes GIT
- __LICENSE__
  - Licen�a de Utiliza��o
<div style="page-break-after: always;"></div>

## Ferramentas / Servi�os utilizados
### Travis-CI

Em resumo o *Travis-CI* � um servi�o no qual nos � permitido correr uma inst�ncia de software (ex docker) de forma a que sejam feitos testes de compila��o e testes unit�rios � solu��o.

Travis-CI (Continuous Improvement) � um servi�o de melhoria continua de c�digo e analise do mesmo.

Para a utiliza��o deste servi�o com C# tivemos de mudar a framework de testes de [MSTest](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest) para a ferramenta [NUnit Framework - Unit Testing](https://nunit.org/)
pois a execu��o de testes em ambiente Linux/MacOsx � incompativel com a ferramenta MSTest.

__Ficheiro de Configura��o .travis.yml__
```yaml
language: csharp
solution: ITgestao.sln

install:
  - sudo apt-get install nunit-console
  - nuget restore ITgestao.sln
  - nuget install NUnit.framework
  - nuget install NUnit
  - nuget install NUnit3TestAdapter
  - nuget install NUnit.Runners -Version 3.7.0 -OutputDirectory testrunner

script:
  - rm -rf ./UI.Win
  - xbuild /p:Configuration=Release ITgestao.sln
  - mono ./testrunner/NUnit.ConsoleRunner.3.7.0/tools/nunit3-console.exe ./Tests/bin/Release/Tests.dll
```
A configura��o do *Travis-CI* � feita atrav�s de um ficheiro que � deixado na raiz do projecto (**.travis.yml**) de forma a informar ao agent do *Travis-CI* quais as configura��es necess�rias para correr/testar a nossa solu��o.

O ficheiro de configura��o do nosso trabalho utiliza Linux e mono para compilar e testar a aplica��o, de notar que de momento n�o � possivel realizar testes em WPF de forma que o subprojecto WPF � removido do travis antes de iniciar a execu��o.

O *Travis-CI* � capaz de correr os mais variados ambientes quer de sistemas operativos quer de pacotes j� feitos [MultiOS](https://docs.travis-ci.com/user/multi-os/) / [Docker](https://docs.travis-ci.com/user/docker/).

#### Funcionamento:
O *Travis-CI* efectua testes de forma configur�vel pelo administrador do reposit�rio.

Preferimos utilizar o *Travis-CI* para confirmar os pull requests para o branch master e para testar c compila��o do branch master.

Desta forma sempre que for efectuado um pull request ao master do reposit�rio o *Travis-CI* automaticamente inicia os testes como podem ver na imagem abaixo:

![Pull Request Testing](https://github.com/nargotik/trabalho1-lp2/blob/master/Doc/img/pull_request_testing.png?raw=true)

Ap�s a finaliza��o dos testes � dado o "__ok__" para se efectuar o merge no reposit�rio, cabe sempre a quem efectua a manuten��o do reposit�rio a decis�o final se quer efectuar um merge que falhou � sua responsabilidade.
![Pull Request Testing](https://github.com/nargotik/trabalho1-lp2/blob/master/Doc/img/pull_request_testing_okmerge.png?raw=true)

No dashboard do *Travis-CI* podemos ver o log assim como o tempo utilizado nos testes:
![Pull Request Testing](https://github.com/nargotik/trabalho1-lp2/blob/master/Doc/img/pull_request_test_ok.png?raw=true)
Log dos testes:
![Pull Request Testing](https://github.com/nargotik/trabalho1-lp2/blob/master/Doc/img/pull_request_unit_summary_ok.png?raw=true)

Log com exemplo de falhas nos testes.
![Falha nos testes](https://github.com/nargotik/trabalho1-lp2/blob/master/Doc/img/pull_request_unit_summary_fail.png?raw=true)
O *Travis-CI* fornece ainda uma pequena imagem din�mica que est� presente na introdu��o do nosso trabalho que indica se o projecto est� com os testes em "passing" ou "fail".
<div style="page-break-after: always;"></div>

### CodeFactor
O CodeFactor � um servi�o de analise de syntax de c�digo de forma a que sejam cumpridas algumas regras b�sicas de realiza��o de c�digo.

Este servi�o � importante, principalmente se quisermos manter um projecto com muitos programadores onde uniformizamos a forma como � colocado o c�digo no projecto, garantindo assim desta forma homogeneidade dessas regras b�sicas de c�digo.

Existem muitos outros servi�os deste g�nero, no entanto verificamos que este era de momento o que mais se enquadrava para a linguagem c#.

Este tipo de testes pode tamb�m ser efectuado de forma manual no Travis-CI, no entanto seria necess�rio fazer testes bem mais complexos que os unit�rios para testar problemas comuns de syntax.

![Codefactor Print1](https://github.com/nargotik/trabalho1-lp2/blob/master/Doc/img/codefacor1.png?raw=true)

![Codefactor Print2](https://github.com/nargotik/trabalho1-lp2/blob/master/Doc/img/codefacor2.png?raw=true)

<div style="page-break-after: always;"></div>

## Diagrama de Objectos
![Diagrama de Classes](https://github.com/nargotik/trabalho1-lp2/blob/master/diagram.png?raw=true)

<div style="page-break-after: always;"></div>

## Classes


 - Item
     - ClasseName:Item (*Extens�es de Item*)
     - Generico:Item
	 - Rede:Item
	 - Computador:Item
     - ...
 - Inventario
 - Localizacao
 - Localizacoes
 - Config
 - Exceptions
 - Menu
 - MenuOpcao
 
---

### Item
A classe Item � a classe abstracta que define e cria os objectos do tipo Item.
� a classe "pai" respons�vel por armazenar e tratar um objecto do tipo Item o mais gen�rico poss�vel.
Esta classe t�m dois m�todos **static** muito importantes de forma a que qualquer filho possa informar a classe base
que existe mais um tipo de child.

1. Atributos
	- (__*id*__) - Valor �nico que identifica o item (id do item);
	- (__*idCliente*__) - Valor identifica o cliente ao qual pertence o item;
	- (__*idLocalizacao*__) - Valor que identifica a localiza��o do item.
	
2. M�todos
    - (__*AddAuthorizedType(object  _obj)*__) - Permite adicionar um novo tipo de item autorizado;
      - Este m�todo utiliza a classe *__Config__* para armazenar na aplica��o transversalmente o estado dos items autorizados.
    - (__*Type AuthorizedType(object  _obj)*__) - Devolve o tipo do objecto colocado como par�metro se for um objecto autorizado.
      - Este m�todo utiliza a classe *__Config__* para verificar se o objecto est� na lista dos autorizados.

---
#### Extens�es de Item (ClasseName:Item)
Todas as classes que estendam de Item devem informar a classe Item que existe um novo tipo de Item que ser� tratado pelo invent�rio.

Esta tipo de objectos dever�o ser sealed de forma a que n�o hajam mais extens�es do mesmo, a menos que para tal seja necess�rio extender.

```c#
public ClasseName(...) : base(...)
        {
            Item.AddAuthorizedType(this);
```

---
#### Gen�rico (Generico:Item)
� um objecto que estender� *__Item__*.



� a classe que trata da informa��o de um item gen�rico.

---
#### Computador (Computador:Item)
� um objecto que estender� *__Item__*.

Esta classe ir� criar items do tipo Computador.

Ainda n�o est� definido na altura do desenvolvimento deste relat�rio os atributos, dever�o ser do tipo: RAM/CPU...

1. __M�todos/Construtores__
	- (__*Computador(...)*__) - Construtor que cria um objeto do tipo Computador.

---
#### Rede (Rede:Item)
� um objecto que extender� *__Item__*.

Esta classe ir� criar items do tipo Rede.

Ainda n�o est� definido na altura do desenvolvimento deste relat�rio os atributos, dever�o ser do tipo: ENDERE�O/TIPO(Switch/router)...

1. __M�todos/Construtores__
	- (__*Rede(...)*__) - Construtor que cria um objeto do tipo Rede.


---

### Invent�rio
O Objecto Invent�rio est� encarregue de armazenar e tratar objectos do tipo __*Item*__.

Foi utilizada padr�o singleton com m�ltiplas instancias pelo id da entidade de invent�rio.
Para utilizar a class apenas � necess�rio:
```c#
// Instancia com entidade = 0 por defeito
Inventario.getInstance().metodo; 
...
// Instancia com entidade = 10
Inventario.getInstance(10).metodo;
```

De salientar que o armazenamento dos dados � feito automaticamente quando se 
adiciona/edita/remove um item com os m�todos privados __SaveData()__ e __LoadData()__.

O invent�rio foi desenvolvido de forma a poder ser reutilizado nas mais variadas �reas, sendo
a abordagem feita o mais abstracta poss�vel de forma a que o mesmo tanto armazene computadores 
como fruta ou viaturas.

1. __Atributos__
	- (__*entidade*__) - Valor que identifica uma entidade da instancia do invent�rio;
	- (__*itens*__) - Lista de objectos do tipo Item;
2. __M�todos__
	- __*Adiciona(...)*__ - M�todo que adiciona um objecto ao invent�rio;
	- __*Remove(...)*__ - M�todo que elimina um objecto do invent�rio;
	- __*GetItemById(...)*__ - M�todo que devolve um objecto do invent�rio pelo ID
    - __*RemoveItemById(...)*__ - M�todo que remove um objecto do invent�rio pelo ID
    - __*RemoveAll(...)*__ - M�todo que remove todos os items do invent�rio
    - __*Edita(...)*__ - M�todo que edita um objecto do invent�rio
3. __Testes Unit�rios__
    - Foram desenvolvidos v�rios testes unit�rios b�sicos unit�rios de forma a que qualquer modifica��o na classe
obede�a �s regras do desenvolvimento.
---
### Config
O Objectivo desta classe � armazenar informa��o necess�ria para o runtime da aplica��o de forma a que qualquer 
classe que necessite de informa��o sobre a aplica��o posso consumir informa��o da mesma.

Algumas das informa��es pensadas a colocar nesta classe futuramente.
- Direct�rio Actual
- Direct�rio de Armazenamento dos ficheiros de dados persistentes.
- Tipos de item autorizados pela aplica��o ITGestao.dll a serem tratados pelo __Invent�rio__

Optou-se pela utiliza��o do Padr�o Singleton nesta classe de forma que s� exista uma s� 
instancia da classe config sendo que a mesma � inicializada na primeira vez que � chamada.

```c#
public sealed class Config {
	private Config()
	{
	// C�digo a correr na inicializa��o da classe
	(...)
	}
	private static Config instance = null;
	public static Config Instance
	{
		get
		{
			// A classe n�o est� instanciada
			if (instance == null)
				instance = new Config();
			// Se a classe est� instanciada retorna a instancia.
			return instance;
		}
	}
(...)
}
```
---
### Exceptions
Classe que permite lidar com erros que ocorrem durante a execu��o da aplica��o.

Algumas das excep��es j� tratadas:
- ID duplicado;
- ID inv�lido;
- Tentativa de inicia��o de objecto com argumentos em falta. 
---
### Menu
Foi criada uma classe de forma a podermos agilizar os menus no UI.Cli

Para tal utilizamos tamb�m Delegates de forma a que uma op��o de um Menu tivesse um ac��o (Action) atribu�da (Callback).

### MenuOpcao
� uma classe que armazena op��es do menu e respectivos Actions

<div style="page-break-after: always;"></div>

## Bibliografia / Refer�ncias
- [Padr�o Singleton](https://pt.wikipedia.org/wiki/Singleton)
- [Testes Unit�rios - Unit Testing](https://docs.microsoft.com/en-us/visualstudio/test/unit-test-basics?view=vs-2019)
- [Windows Presentation Foundation](https://docs.microsoft.com/en-us/dotnet/framework/wpf/)
- [CodeFactor](https://www.codefactor.io/)
- [Travis-ci](https://travis-ci.org/)
- [NUnit Framework - Unit Testing](https://nunit.org/)
- [GitHub](https://github.com/)
- [DEVHINTS.IO](https://devhints.io/)
- [Docker Hub](https://hub.docker.com/)
- [AppVeyor](https://www.appveyor.com/)
- [CoverAlls.IO](https://coveralls.io/)