# Projeto TechCycle _ FunCoders

<br>

## Resumo do projeto:
> - Em parceria do SENAI de Informática com a empresa ThoughtWorks, fomos responsáveis por desenvolver o projeto de classificados. Primeiramente, a empresa implementou uma politica que visa repasar os computadores que atingiram seu fim de vida útil (normalmente são computadores que são distribuidos para seus funcionarios, e recolhidos a cada 2 anos e 6 meses), aos colobadores interessados nesses equipamentos, elaborando um sistema de anuncio onde possam divulgar estes computadores, e os mesmos colaboradores possam adquiri-los manifestando seu interesse.

<br>
<br>


## Identidade visual:

> - Logo tipo:

<br>

![logogit](https://user-images.githubusercontent.com/54751039/68480794-65dff900-0214-11ea-83ca-25bb49f4a71e.png)

<br>

> - Paleta de cores:

<br>

![paleta](https://user-images.githubusercontent.com/54751039/68481676-9c1e7800-0216-11ea-9aa3-a4bc99b1d4f4.jpg)

<br>

> - Tipografia:

<br>

![tipografia](https://user-images.githubusercontent.com/54751039/68485566-4f3e9f80-021e-11ea-8fb6-222b7aafd422.jpg)

<br>

## Requisitos do projeto:

<br>

> -	Cadastro de novos usuários - onde o usuário fará seu cadastro e o administrador aprovará esse cadastro.
> - Cadastro de equipamentos - onde o administrador irá cadastrar os equipamentos em fim de vida útil.
> - Editar equipamentos cadastrados - o administrador poderá editar os dados de equipamentos já cadastrados.
> - Manifestar interesse em um equipamento - ao visualizar um equipamento o usuário poderá manifestar interesse de compra dos equipamentos.
> - Aprovação de interesse - o administrador aprovará de acordo com os padrões da política quem dos interessados é elegível de compra. 
> - Comentar sobre o produto - o usuário poderá fazer perguntas ao administrador sobre o equipamento desejado e o administrador poderá respondê-las.
> - Editar perfil - O usuário poderá fazer pequenas alterações no seu perfil como alterar sua senha ou alterar sua foto de perfil.

<br>
<br>

## Modelagem banco de dados:

<br>

> - MERS (Modelo Entidade de Relacionamento):

<br>

![mer](https://user-images.githubusercontent.com/54751039/68487952-cfff9a80-0222-11ea-9c99-3b1e64ed6baf.jpg)

<br>

> - Diagrama de banco de dados:

<br>

![diagrama](https://user-images.githubusercontent.com/54751039/68488189-443a3e00-0223-11ea-8317-ec3ba0f11a89.jpg)

<br>
<br>

## Conceitos utilizados:

> - * JwToken
> - * API Rest
<br>

![Api](https://user-images.githubusercontent.com/54751039/68501740-a0aa5700-023d-11ea-9e95-3bf68c1cc540.png)

<br>
<br>

### Conceito de JwT token:

> - O JSON Web Token (JWT) é um padrão aberto ( RFC 7519 ) que define uma maneira compacta e independente de transmitir com segurança informações entre partes como um objeto JSON.

<br>

## Utilização de Token e API Rest:

##### Estrutura de um Json
```
{
  "identificacao": "1",
  "nome": "Joaozinho",
  "idade": "15"
}

```
> - Confira a estrutura em [Jwt.io](https://jwt.io/)

<br>

#### Como definir uma rota na url
```C#
[HttpGet("esta/e/uma/url")]
public Usuario MetodoUtilizado(){

    return oQueVoceQuiser;
}
```
<br>

#### Métodos HTTP para acessar o sistema

> - Post   (Cadastro)
> - Get    (Busca)
> - Put    (Alteração)
> - Delete (Deletar)
> - Todos esses métodos fazem parte do conceito de CRUD - Create Remove Update e Delete;

<br>

#### Conceito de autenticação:
> - A ideia nesta implementação é de que os clientes com autorização para consumir a API possuem uma chave de acesso, o login do usuário é feito através de usuário, senha e chave de acesso. Ao validar estas informações o sistema retorna um token para o usuário e este token deve ser usado nas próximas requisições.

<br>

#### Exemplo de Autenticação:
```C#
[HttpGet("esta/e/uma/url")]
[Authorization(Roles = "Administrador")]
public async Usuario MetodoUtilizado(){

    return oQueVoceQuiser;
}
`
```