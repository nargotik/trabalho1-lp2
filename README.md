
# Relatório Trabalho Prático LP1
A aplicação a ser desenvolvida no decorrer deste trabalho prático tem como finalidade a gestão de parques informáticos de uma ou várias entidades.

- ___Daniel Torres (<a17442@alunos.ipca.pt>)___
- ___Oscar Daniel Moreira Silva (<a14383@alunos.ipca.pt>)___

## Introdução
A escolha do tema a desenvolver no trabalho prende-se com a necessidade cada vez maior das empresas de desenvolverem metodologias para o controle do seu espólio material.

- A aplicação a desenvolver deverá permitir a adição de novos equipamentos ao inventário, a sua remoção e a pesquisa de equipamentos através do campo ID. Terá que ser capaz ainda de dividir o material consoante o seu tipo.
- A gestão de equipamentos deverá ser feita na lista equipamentos que estará declarada na classe Inventario.
- A aplicação deve ainda ser versátil de modo a adaptar-se às necessidades das empresas.

Os resultados a obter com o desenvolvimento desta solução é criação de uma aplicação versátil e adaptativa às necessidades das diferentes entidades e deverá potencializar uma melhor organização do parque informáticos.
## Método de Trabalho adotado
Para o desenvolvimento deste trabalho, utilizamos uma metodologia que permite a todos os membros do grupo desenvolvam simultaneamente a aplicação e que haja um controle de versões desenvolvidas através do Git. 
Permite ainda dividir a carga de trabalho pois permite que cada elemento do grupo desenvolva uma classe específica da aplicação.



## Diagrama de Objectos
![Diagrama de Classes](https://github.com/nargotik/trabalho1-lp2/blob/master/diagram.png?raw=true)


## Classes


 - Item
	 - Rede
	 - Computador
	 - Generico
 - Inventario
 
 - Localizacao
 - Localizacoes
 - Cliente
 - Clientes
 - Config
 - Exceptions
 
---

### Item
A classe Item é a classe que define e cria os objetos do tipo Item.
É a classe responsável por armazenar e tratar um objeto do tipo Item o mais genérico possível.

1. Atributos
	- id - Valor único que identifica o item;
	- idCliente - Valor único que identifica o cliente;
	- idLocalizacao - Valor que identifica a localização do objeto.
	
2. Métodos
	- Item() - Construtor que permite a adição de um objeto sem passagem de argumentos;
	 - Item(TipoItem  _tipo, int  _id  =  10) - Construtor que permite a adição de um objeto com a passagem dos argumentos _Tipo e _id;
	- AddAuthorizedType(object  _obj) - Método que permite adicionar um novo tipo de objeto autorizado;
	- Type  AuthorizedType(object  _obj) - ??

##### Computador
É uma subclasse de Item.
É a classe que trata da informação de um computador.

1. Métodos
	- Computador(int  _id  =  0, string  _serial  =  "123") - Método que adiciona um objeto do tipo Computador e que insere um serial a esse objeto

##### Rede
É uma subclasse de Item.
É a classe que trata da informação de um dispositivo de rede.

1. Métodos
	- Rede(int  _id  =  0, string  _serial  =  "0") - Método que adiciona um objeto do tipo Rede e que insere um serial a esse objeto

##### Genérico
É uma subclasse de Item.
É a classe que trata da informação de um item que não se enquadra nas restantes "categorias" definidas.

1. Métodos
	- Generico(int  _id  =  0, string  _serial  =  "123") - ??
---
### Inventário
A classe Inventário é a classe que encarregue de armazenar os itens.

1. Atributos
	- empresa - Valor único que identifica uma empresa;
	- itens - Lista de objetos do tipo Item;
2. Métodos
	- Adiciona(object  _obj) - Método que adiciona um objeto ao inventário;
	- Remove(object  _obj) - Método que elimina um objeto do inventário;
	- Edita(object  _obj) - Método que edita um objeto do inventário

---
### Cliente
A classe Cliente é a classe que define e cria os objetos do tipo Cliente.

1. Atributos
	- id - Valor único de identifica um cliente;
	- nome - Primeiro nome do cliente;
	- apelido - Apelido do cliente.
---
### Clientes
A classe Clientes é a classe que encarregue de armazenar objetos do tipo Cliente.

1. Atributos
	- clientes- Lista de objetos do tipo Cliente;

2. Métodos
	- Adiciona(object  _obj) - Método que adiciona um cliente à lista clientes;
	- Remove(object  _obj) - Método que elimina um cliente à lista clientes;
	- Edita(object  _obj) - Método que edita um cliente à lista clientes

---
### Config
Classe de configurações ??

---
### Exceptions
Classe que permite lidar com erros que ocorrem durante a execução da aplicação.

Algumas das exceções já tratadas:
- ID duplicado;
- ID inválido;
- Tentativa de iniciação de objeto com argumentos em falta. 

---

## Bibliografia / Referências

- 
- 

