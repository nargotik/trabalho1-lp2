

# Relatório Trabalho Prático LP1
A aplicação a ser desenvolvida no decorrer deste trabalho prático tem como finalidade a gestão de parques informáticos de uma ou várias entidades.

É a realização deste trabalho realizar uma abordagem de Aprendizagem de técnicas e métodos de Programação Orientada por Objectos, 
assim como a utilização de ferramentas e métodos de trabalho colaborativo.

__Autores do Trabalho:__
- ___Daniel Torres (<a17442@alunos.ipca.pt>)___
- ___Oscar Silva (<a14383@alunos.ipca.pt>)___

[![CodeFactor](https://www.codefactor.io/repository/github/nargotik/trabalho1-lp2/badge)](https://www.codefactor.io/repository/github/nargotik/trabalho1-lp2)
[![Build Status](https://travis-ci.com/nargotik/trabalho1-lp2.svg?token=qNfqiYyxNzmWoPqpyHnZ&branch=master)](https://travis-ci.com/nargotik/trabalho1-lp2)
<div style="page-break-after: always;"></div>

## Introdução
A escolha do tema a desenvolver no trabalho prende-se com a necessidade cada vez maior das empresas de 
desenvolverem metodologias para o controle do seu espólio material e virtual.

- A aplicação deverá:
  - Ser abstracta o suficiente para a reutilização de código para outros sectores/aplicações.
  - Ter uma visão Macro e Micro de todo o inventário presente na Entidade.
    - Listagem de equipamentos
    - Listagem por tipo de Equipamentos
    - Listagem por ano de fabrico
    - Listagem por fabricante 
    - ...
  - Adição/Remoção/Edição de Items no Inventário

Foi pensado em criar um Interface de utilizador por Windows/Consola no entanto ainda será um grande desafio aprender WPF

Não tendo sido possível a aprendizagem de WPF e ao aprofundamento de outras técnicas à frente faladas
o projecto UI.Win apenas foi deixado como prova de conceito, assim como não foi muito desenvolvido o UI.Cli.

Foi primordialmente focado o desenvolvimento de capacidades de trabalho em grupo e automatizadas, assim como a funcionalidade de uma livraria (DLL) que poderá ser reutilizada em outros contextos.

No entanto todos os métodos e classes foram testados usando testes unitários que podem ser vistos no projecto de Tests.

Os resultados a obter com o desenvolvimento desta solução é criação de uma aplicação versátil e adaptativa às 
necessidades das diferentes entidades e deverá potencializar uma melhor organização do parque informáticos.
<div style="page-break-after: always;"></div>

## Método de Trabalho adoptado
Para o desenvolvimento deste trabalho, utilizamos uma metodologia que permite 
a todos os membros do grupo desenvolvam simultaneamente a aplicação e que haja um 
controle de versões desenvolvidas através do Git. 

Permite ainda dividir a carga de trabalho pois permite que cada elemento do grupo 
desenvolva uma classe específica da aplicação.

O GitHub em conjunto com outras ferramentas que serão abordadas mais à frente no tópico de Ferramentas/Serviços de Desenvolvimento 
trazem uma enorme mais valia à produção de Software.

Algumas ferramentas utilizadas:
- Travis-ci
  - Travis CI é um serviço de integração contínua 
- Codefector
  - Analisador automático de syntax de código
<div style="page-break-after: always;"></div>

## Estrutura de Ficheiros
- __./Libs/Folder/...__
  - Pasta que contem exemplos de items, esta pasta irá gerar dll's a serem utilizadas pelo ITGestão
- __./ITGEstao/__
  - Projecto (VS 2017) de um dll ITGestao.dll que pode ser reutilizada
- __./Tests/__
  - Projecto de testes unitários
- __./UI.Cli/__
  - Interface de Utilizador (Linha de Comandos)
- __./UI.Win/__
  - Interface Utilizador (Windows) 
    - Apenas serve como prova de conceito da forma que foi dividido o UI da parte Lógica
- __./Utils/__
  - Vários Utilitários a serem usados
- __ITgestao.sln__
  - Solução (VS 2017)
- __diagram.png__
  - Diagrama de classes do projecto ITGestao
- __readme.md__
  - Relatório
- __.travis.yml__
  - Ficheiro de compilação automática e Testes GIT
- __LICENSE__
  - Licença de Utilização
<div style="page-break-after: always;"></div>

## Ferramentas / Serviços utilizados
### Travis-CI

Em resumo o *Travis-CI* é um serviço no qual nos é permitido correr uma instância de software (ex docker) de forma a que sejam feitos testes de compilação e testes unitários à solução.

Travis-CI (Continuous Improvement) é um serviço de melhoria continua de código e analise do mesmo.

Para a utilização deste serviço com C# tivemos de mudar a framework de testes de [MSTest](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest) para a ferramenta [NUnit Framework - Unit Testing](https://nunit.org/)
pois a execução de testes em ambiente Linux/MacOsx é incompativel com a ferramenta MSTest.

__Ficheiro de Configuração .travis.yml__
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
A configuração do *Travis-CI* é feita através de um ficheiro que é deixado na raiz do projecto (**.travis.yml**) de forma a informar ao agent do *Travis-CI* quais as configurações necessárias para correr/testar a nossa solução.

O ficheiro de configuração do nosso trabalho utiliza Linux e mono para compilar e testar a aplicação, de notar que de momento não é possivel realizar testes em WPF de forma que o subprojecto WPF é removido do travis antes de iniciar a execução.

O *Travis-CI* é capaz de correr os mais variados ambientes quer de sistemas operativos quer de pacotes já feitos [MultiOS](https://docs.travis-ci.com/user/multi-os/) / [Docker](https://docs.travis-ci.com/user/docker/).

#### Funcionamento:
O *Travis-CI* efectua testes de forma configurável pelo administrador do repositório.

Preferimos utilizar o *Travis-CI* para confirmar os pull requests para o branch master e para testar c compilação do branch master.

Desta forma sempre que for efectuado um pull request ao master do repositório o *Travis-CI* automaticamente inicia os testes como podem ver na imagem abaixo:

![Pull Request Testing](https://github.com/nargotik/trabalho1-lp2/blob/master/Doc/img/pull_request_testing.png?raw=true)

Após a finalização dos testes é dado o "__ok__" para se efectuar o merge no repositório, cabe sempre a quem efectua a manutenção do repositório a decisão final se quer efectuar um merge que falhou à sua responsabilidade.
![Pull Request Testing](https://github.com/nargotik/trabalho1-lp2/blob/master/Doc/img/pull_request_testing_okmerge.png?raw=true)

No dashboard do *Travis-CI* podemos ver o log assim como o tempo utilizado nos testes:
![Pull Request Testing](https://github.com/nargotik/trabalho1-lp2/blob/master/Doc/img/pull_request_test_ok.png?raw=true)
Log dos testes:
![Pull Request Testing](https://github.com/nargotik/trabalho1-lp2/blob/master/Doc/img/pull_request_unit_summary_ok.png?raw=true)

Log com exemplo de falhas nos testes.
![Falha nos testes](https://github.com/nargotik/trabalho1-lp2/blob/master/Doc/img/pull_request_unit_summary_fail.png?raw=true)
O *Travis-CI* fornece ainda uma pequena imagem dinâmica que está presente na introdução do nosso trabalho que indica se o projecto está com os testes em "passing" ou "fail".
<div style="page-break-after: always;"></div>

### CodeFactor
O CodeFactor é um serviço de analise de syntax de código de forma a que sejam cumpridas algumas regras básicas de realização de código.

Este serviço é importante, principalmente se quisermos manter um projecto com muitos programadores onde uniformizamos a forma como é colocado o código no projecto, garantindo assim desta forma homogeneidade dessas regras básicas de código.

Existem muitos outros serviços deste género, no entanto verificamos que este era de momento o que mais se enquadrava para a linguagem c#.

Este tipo de testes pode também ser efectuado de forma manual no Travis-CI, no entanto seria necessário fazer testes bem mais complexos que os unitários para testar problemas comuns de syntax.

![Codefactor Print1](https://github.com/nargotik/trabalho1-lp2/blob/master/Doc/img/codefacor1.png?raw=true)

![Codefactor Print2](https://github.com/nargotik/trabalho1-lp2/blob/master/Doc/img/codefacor2.png?raw=true)

<div style="page-break-after: always;"></div>

## Diagrama de Objectos
![Diagrama de Classes](https://github.com/nargotik/trabalho1-lp2/blob/master/diagram.png?raw=true)

<div style="page-break-after: always;"></div>

## Classes


 - Item
     - ClasseName:Item (*Extensões de Item*)
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
A classe Item é a classe abstracta que define e cria os objectos do tipo Item.
É a classe "pai" responsável por armazenar e tratar um objecto do tipo Item o mais genérico possível.
Esta classe têm dois métodos **static** muito importantes de forma a que qualquer filho possa informar a classe base
que existe mais um tipo de child.

1. Atributos
	- (__*id*__) - Valor único que identifica o item (id do item);
	- (__*idCliente*__) - Valor identifica o cliente ao qual pertence o item;
	- (__*idLocalizacao*__) - Valor que identifica a localização do item.
	
2. Métodos
    - (__*AddAuthorizedType(object  _obj)*__) - Permite adicionar um novo tipo de item autorizado;
      - Este método utiliza a classe *__Config__* para armazenar na aplicação transversalmente o estado dos items autorizados.
    - (__*Type AuthorizedType(object  _obj)*__) - Devolve o tipo do objecto colocado como parâmetro se for um objecto autorizado.
      - Este método utiliza a classe *__Config__* para verificar se o objecto está na lista dos autorizados.

---
#### Extensões de Item (ClasseName:Item)
Todas as classes que estendam de Item devem informar a classe Item que existe um novo tipo de Item que será tratado pelo inventário.

Esta tipo de objectos deverão ser sealed de forma a que não hajam mais extensões do mesmo, a menos que para tal seja necessário extender.

```c#
public ClasseName(...) : base(...)
        {
            Item.AddAuthorizedType(this);
```

---
#### Genérico (Generico:Item)
É um objecto que estenderá *__Item__*.



É a classe que trata da informação de um item genérico.

---
#### Computador (Computador:Item)
É um objecto que estenderá *__Item__*.

Esta classe irá criar items do tipo Computador.

Ainda não está definido na altura do desenvolvimento deste relatório os atributos, deverão ser do tipo: RAM/CPU...

1. __Métodos/Construtores__
	- (__*Computador(...)*__) - Construtor que cria um objeto do tipo Computador.

---
#### Rede (Rede:Item)
É um objecto que extenderá *__Item__*.

Esta classe irá criar items do tipo Rede.

Ainda não está definido na altura do desenvolvimento deste relatório os atributos, deverão ser do tipo: ENDEREÇO/TIPO(Switch/router)...

1. __Métodos/Construtores__
	- (__*Rede(...)*__) - Construtor que cria um objeto do tipo Rede.


---

### Inventário
O Objecto Inventário está encarregue de armazenar e tratar objectos do tipo __*Item*__.

Foi utilizada padrão singleton com múltiplas instancias pelo id da entidade de inventário.
Para utilizar a class apenas é necessário:
```c#
// Instancia com entidade = 0 por defeito
Inventario.getInstance().metodo; 
...
// Instancia com entidade = 10
Inventario.getInstance(10).metodo;
```

De salientar que o armazenamento dos dados é feito automaticamente quando se 
adiciona/edita/remove um item com os métodos privados __SaveData()__ e __LoadData()__.

O inventário foi desenvolvido de forma a poder ser reutilizado nas mais variadas áreas, sendo
a abordagem feita o mais abstracta possível de forma a que o mesmo tanto armazene computadores 
como fruta ou viaturas.

1. __Atributos__
	- (__*entidade*__) - Valor que identifica uma entidade da instancia do inventário;
	- (__*itens*__) - Lista de objectos do tipo Item;
2. __Métodos__
	- __*Adiciona(...)*__ - Método que adiciona um objecto ao inventário;
	- __*Remove(...)*__ - Método que elimina um objecto do inventário;
	- __*GetItemById(...)*__ - Método que devolve um objecto do inventário pelo ID
    - __*RemoveItemById(...)*__ - Método que remove um objecto do inventário pelo ID
    - __*RemoveAll(...)*__ - Método que remove todos os items do inventário
    - __*Edita(...)*__ - Método que edita um objecto do inventário
3. __Testes Unitários__
    - Foram desenvolvidos vários testes unitários básicos unitários de forma a que qualquer modificação na classe
obedeça às regras do desenvolvimento.
---
### Config
O Objectivo desta classe é armazenar informação necessária para o runtime da aplicação de forma a que qualquer 
classe que necessite de informação sobre a aplicação posso consumir informação da mesma.

Algumas das informações pensadas a colocar nesta classe futuramente.
- Directório Actual
- Directório de Armazenamento dos ficheiros de dados persistentes.
- Tipos de item autorizados pela aplicação ITGestao.dll a serem tratados pelo __Inventário__

Optou-se pela utilização do Padrão Singleton nesta classe de forma que só exista uma só 
instancia da classe config sendo que a mesma é inicializada na primeira vez que é chamada.

```c#
public sealed class Config {
	private Config()
	{
	// Código a correr na inicialização da classe
	(...)
	}
	private static Config instance = null;
	public static Config Instance
	{
		get
		{
			// A classe não está instanciada
			if (instance == null)
				instance = new Config();
			// Se a classe está instanciada retorna a instancia.
			return instance;
		}
	}
(...)
}
```
---
### Exceptions
Classe que permite lidar com erros que ocorrem durante a execução da aplicação.

Algumas das excepções já tratadas:
- ID duplicado;
- ID inválido;
- Tentativa de iniciação de objecto com argumentos em falta. 
---
### Menu
Foi criada uma classe de forma a podermos agilizar os menus no UI.Cli

Para tal utilizamos também Delegates de forma a que uma opção de um Menu tivesse um acção (Action) atribuída (Callback).

### MenuOpcao
É uma classe que armazena opções do menu e respectivos Actions

<div style="page-break-after: always;"></div>

## Bibliografia / Referências
- [Padrão Singleton](https://pt.wikipedia.org/wiki/Singleton)
- [Testes Unitários - Unit Testing](https://docs.microsoft.com/en-us/visualstudio/test/unit-test-basics?view=vs-2019)
- [Windows Presentation Foundation](https://docs.microsoft.com/en-us/dotnet/framework/wpf/)
- [CodeFactor](https://www.codefactor.io/)
- [Travis-ci](https://travis-ci.org/)
- [NUnit Framework - Unit Testing](https://nunit.org/)
- [GitHub](https://github.com/)
- [DEVHINTS.IO](https://devhints.io/)
- [Docker Hub](https://hub.docker.com/)
- [AppVeyor](https://www.appveyor.com/)
- [CoverAlls.IO](https://coveralls.io/)