
# Relat�rio Trabalho Pr�tico LP1
A aplica��o a ser desenvolvida no decorrer deste trabalho pr�tico tem como finalidade a gest�o de parques inform�ticos de uma ou v�rias entidades.

� a realiza��o deste trabalho realizar uma abordagem de Aprendizagem de t�cnicas e m�todos de Programa��o Orientada por Objectos, 
assim como a utiliza��o de ferramentes e m�todos de trabalho colaborativo.

__Autores do Trabalho:__
- ___Daniel Torres (<a17442@alunos.ipca.pt>)___
- ___Oscar Silva (<a14383@alunos.ipca.pt>)___

[![CodeFactor](https://www.codefactor.io/repository/github/nargotik/trabalho1-lp2/badge)](https://www.codefactor.io/repository/github/nargotik/trabalho1-lp2)
[![Build Status](https://travis-ci.com/nargotik/trabalho1-lp2.svg?token=qNfqiYyxNzmWoPqpyHnZ&branch=master)](https://travis-ci.com/nargotik/trabalho1-lp2)

## Introdu��o
A escolha do tema a desenvolver no trabalho prende-se com a necessidade cada vez maior das empresas de 
desenvolverem metodologias para o controle do seu esp�lio material e virtual.

- A aplica��o dever�:
  - Ser abstrata o suficiente para a reutiliza��o de codigo para outros setores/aplica��es.
  - Ter uma vis�o Macro e Micro de todo o invent�rio presente na Entidade.
    - Listagem de equipamentos
    - Listagem por tipo de Equipamentos
    - Listagem por ano de fabrico
    - Listagem por fabricante 
    - ...
  - Adi��o/Remo��o/Edi��o de Items no Invent�rio

Foi pensado em criar um Interface de utilizador por Windows/Consola no entanto ainda ser� um grande desafio aprender WPF

Os resultados a obter com o desenvolvimento desta solu��o � cria��o de uma aplica��o vers�til e adaptativa �s 
necessidades das diferentes entidades e dever� potencializar uma melhor organiza��o do parque inform�ticos.

## M�todo de Trabalho adotado
Para o desenvolvimento deste trabalho, utilizamos uma metodologia que permite 
a todos os membros do grupo desenvolvam simultaneamente a aplica��o e que haja um 
controle de vers�es desenvolvidas atrav�s do Git. 

Permite ainda dividir a carga de trabalho pois permite que cada elemento do grupo 
desenvolva uma classe espec�fica da aplica��o.

## Estrutura de Ficheiros
- __./ITGEstao/__
  - Projecto (VS 2017) de um dll ITGestao.dll que pode ser reutilizada
- __./Tests/__
  - Projecto de testes unit�rios
- __./UI.Cli/__
  - Interface de Utilizador (Linha de Comandos)
- __./UI.Win/__
  - Interface Utilizador (Windows)
- __./Utils/__
  - V�rios Utilit�rios a serem usados
- __ITgestao.sln__
  - Solu��o (VS 2017)
- __diagram.png__
  - Diagrama de classes do projecto ITGestao
- __readme.md__
  - Relat�rio
- __LICENSE__
  - Licen�a de Utiliza��o


## Diagrama de Objectos
![Diagrama de Classes](https://github.com/nargotik/trabalho1-lp2/blob/master/diagram.png?raw=true)


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
 - Cliente
 - Clientes
 - Config
 - Exceptions
 
---

### Item
A classe Item � a classe abstrata que define e cria os objetos do tipo Item.
� a classe "pai" respons�vel por armazenar e tratar um objeto do tipo Item o mais gen�rico poss�vel.
Esta classe t�m dois m�todos **static** muito importantes de forma a que qualquer filho possa informar a classe base
que existe mais um tipo de child.

1. Atributos
	- (__*id*__) - Valor �nico que identifica o item (id do item);
	- (__*idCliente*__) - Valor identifica o cliente ao qual pertence o item;
	- (__*idLocalizacao*__) - Valor que identifica a localiza��o do item.
	
2. M�todos
    - (__*AddAuthorizedType(object  _obj)*__) - Permite adicionar um novo tipo de item autorizado;
      - Este metodo utiliza a classe *__Config__* para armazenar na aplica��o transversalmente o estado dos items autorizados.
    - (__*Type AuthorizedType(object  _obj)*__) - Devolve o tipo do objecto colocado como parametro se f�r um objecto autorizado.
      - Este m�todo utiliza a classe *__Config__* para verificar se o objecto est� na lista dos autorizados.

---
#### Extens�es de Item (ClasseName:Item)
Todas as classes que extendam de Item devem informar a classe Item que existe um novo tipo de Item que ser� tratado pelo invent�rio.

Esta tipo de objetos dever�o ser sealed de forma a que n�o hajam mais extens�es do mesmo, a menos que para tal seja necess�rio extender.

```c#
public ClasseName(...) : base(...)
        {
            Item.AddAuthorizedType(this);
```

---
#### Gen�rico (Generico:Item)
� um objecto que extender� *__Item__*.



� a classe que trata da informa��o de um item gen�rico.

---
#### Computador (Computador:Item)
� um objecto que extender� *__Item__*.

Esta classe ir� criar items do tipo Computador.

Ainda n�o est� definido na altura do desenvolvimento deste relat�rio os atributos, dever�o ser do tipo: RAM/CPU...

1. __M�todos/Construtores__
	- (__*Computador(...)*__) - Construtor que cria um objeto do tipo Computador.

---
#### Rede (Rede:Item)
� um objecto que extender� *__Item__*.

Esta classe ir� criar items do tipo Rede.

Ainda n�o est� definido na altura do desenvolvimento deste relat�rio os atributos, dever�o ser do tipo: ENDERECO/TIPO(Switch/router)...

1. __M�todos/Construtores__
	- (__*Rede(...)*__) - Construtor que cria um objeto do tipo Rede.


---

### Invent�rio
O Objeto Invent�rio est� encarregue de armazenar e tratar objetos do tipo __*Item*__.

1. __Atributos__
	- (__*empresa*__) - Valor que identifica uma empresa da instancia do invent�rio;
	- (__*itens*__) - Lista de objetos do tipo Item;
2. __M�todos__
	- __*Adiciona(...)*__ - M�todo que adiciona um objeto ao invent�rio;
	- __*Remove(...)*__ - M�todo que elimina um objeto do invent�rio;
	- __*Edita(...)*__ - M�todo que edita um objeto do invent�rio

---
### Cliente
O Objecto Cliente define e cria os objetos do tipo Cliente.

Os atributos deste objeto ainda n�o foram desenvolvidos na totalidade.

1. __Atributos__
	- (__*id*__) - Valor �nico de identifica um cliente;
	- (__*nome*__) - Primeiro nome do cliente;
	- (__*apelido*__) - Apelido do cliente.
---
### Clientes
A classe Clientes � a classe que encarregue de armazenar objetos do tipo __*Cliente*__.

1. __Atributos__
	- clientes- Lista de objetos do tipo Cliente;

2. __M�todos__
	- __*Adiciona(...)*__ - M�todo que adiciona um cliente � lista;
	- __*Remove(...)*__ - M�todo que elimina um cliente da lista;
	- __*Edita(...)*__ - M�todo que edita um cliente da lista;

---
### Config


O Objectivo desta classe � armazenar informa��o necess�ria para o runtime da aplica��o de forma a que qualquer 
classe que necessite de informa��o sobre a aplica��o posso consumir informa��o da mesma.

Algumas das informa��es pensadas a colocar nesta classe futuramente.
- Directorio Actual
- Directorio de Armazenamento dos ficheiros de dados persistentes.
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

Algumas das exce��es j� tratadas:
- ID duplicado;
- ID inv�lido;
- Tentativa de inicia��o de objeto com argumentos em falta. 

---

## Bibliografia / Refer�ncias
- [Padr�o Singleton](https://pt.wikipedia.org/wiki/Singleton)
- [Testes Unit�rios - Unit Testing](https://docs.microsoft.com/en-us/visualstudio/test/unit-test-basics?view=vs-2019)
- [Windows Presentation Foundation](https://docs.microsoft.com/en-us/dotnet/framework/wpf/)
