# Varia��o do Ativo

**(Leia at� o final)**

Este desafio consiste em consultar a varia��o do pre�o de um ativo a sua escolha nos �ltimos 30 preg�es. Voc� dever� apresentar o percentual de varia��o de pre�o de um dia para o outro e o percentual desde o primeiro preg�o apresentado.

| Dia   | Data          |  Valor    | Varia��o em rela��o a D-1     | Varia��o em rela��o a primeira data
|-      | -             | -         | -                             | - 
|2      |  01/01/2021   |  R$ 1,00  | -                             | -
|3      |  02/01/2021   |  R$ 1,10  | 10%                           | 10%
|4      |  03/01/2021   |  R$ 1,05  | -4,54%                        | 5%
|5      |  04/01/2021   |  R$ 1,90  | 80,95%                        | 90%

Para este desafio, iremos utilizar a API do Yahoo Finance https://finance.yahoo.com/ 

Como sistemas de backend implementar a solu��o em **.NET Core ou Ruby**. Para mobile, utilizar **linguagens nativas e flutter**.

## Backend
1. Consultar o pre�o do ativo na API do Yahoo Finance (este � um exemplo da consulta do ativo PETR4 https://query2.finance.yahoo.com/v8/finance/chart/PETR4.SA)
2. Armazenar as informa��es em uma base de dados a sua escolha.
3. Implementar uma API que consulte as informa��es na sua base de dados, retorne o valor do ativo nos �ltimos 30 preg�es e apresente a varia��o do pre�o no per�odo. Voc� dever� considerar o valor de abertura (*chart.result.indicators.quote.open*)
4. Disponibilizar seu c�digo aqui no Github

## Sobre a avalia��o
:bangbang: :bangbang:  Utilize os recursos dispon�veis na linguagem que voc� est� se candidatando:
* Padr�es de projetos 
* Arquiteturas
* Testes unit�rios
* Configura��o de deploy

Seja criativo. Esperamos proatividade no desenvolvimento da solu��o. Tudo isso ser� levado em considera��o na avalia��o da sua prova, assim como a disponibiliza��o do seu c�digo fonte e o tempo necess�rio para a realiza��o da prova.

## Importante
### Sobre a API
Os valores estr�o estruturados em vetores, desta forma, voc� precisar� casar a data do preg�o (*chart.result.timestamp*) com o valor de abertura (*chart.result.indicators.quote.open*) atrav�s do indice do vetor.

### Sobre a entrega
:heavy_exclamation_mark: Use sua criatividade para estruturar sua solu��o. Importante manter uma documenta��o clara de como deveremos proceder para executar sua aplica��o (__crie um arquivo MD e inclua no seu reposit�rio__), sendo assim, importante disponibilizar os scripts de banco de dados e demais recursos utilizados e como utiliz�-los. :heavy_exclamation_mark: 

#### ATEN��O
:heavy_exclamation_mark: Seu c�digo dever� ser disponibilizado em um reposit�rio no Github
