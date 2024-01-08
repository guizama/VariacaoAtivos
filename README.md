# Variação do Ativo

**(Leia até o final)**

Este desafio consiste em consultar a variação do preço de um ativo a sua escolha nos últimos 30 pregões. Você deverá apresentar o percentual de variação de preço de um dia para o outro e o percentual desde o primeiro pregão apresentado.

| Dia   | Data          |  Valor    | Variação em relaçào a D-1     | Variação em relação a primeira data
|-      | -             | -         | -                             | - 
|2      |  01/01/2021   |  R$ 1,00  | -                             | -
|3      |  02/01/2021   |  R$ 1,10  | 10%                           | 10%
|4      |  03/01/2021   |  R$ 1,05  | -4,54%                        | 5%
|5      |  04/01/2021   |  R$ 1,90  | 80,95%                        | 90%

Para este desafio, iremos utilizar a API do Yahoo Finance https://finance.yahoo.com/ 

Como sistemas de backend implementar a solução em **.NET Core ou Ruby**. Para mobile, utilizar **linguagens nativas e flutter**.

## Backend
1. Consultar o preço do ativo na API do Yahoo Finance (este é um exemplo da consulta do ativo PETR4 https://query2.finance.yahoo.com/v8/finance/chart/PETR4.SA)
2. Armazenar as informações em uma base de dados a sua escolha.
3. Implementar uma API que consulte as informações na sua base de dados, retorne o valor do ativo nos últimos 30 pregões e apresente a variação do preço no período. Você deverá considerar o valor de abertura (*chart.result.indicators.quote.open*)
4. Disponibilizar seu código aqui no Github

## Sobre a avaliação
:bangbang: :bangbang:  Utilize os recursos disponíveis na linguagem que você está se candidatando:
* Padrões de projetos 
* Arquiteturas
* Testes unitários
* Configuração de deploy

Seja criativo. Esperamos proatividade no desenvolvimento da solução. Tudo isso será levado em consideração na avaliação da sua prova, assim como a disponibilização do seu código fonte e o tempo necessário para a realização da prova.

## Importante
### Sobre a API
Os valores estrão estruturados em vetores, desta forma, você precisará casar a data do pregão (*chart.result.timestamp*) com o valor de abertura (*chart.result.indicators.quote.open*) através do indice do vetor.

### Sobre a entrega
:heavy_exclamation_mark: Use sua criatividade para estruturar sua solução. Importante manter uma documentação clara de como deveremos proceder para executar sua aplicação (__crie um arquivo MD e inclua no seu repositório__), sendo assim, importante disponibilizar os scripts de banco de dados e demais recursos utilizados e como utilizá-los. :heavy_exclamation_mark: 

#### ATENÇÃO
:heavy_exclamation_mark: Seu código deverá ser disponibilizado em um repositório no Github
