# Exchange Challenger

Este é um desafio de conversão de moeda para um processo seletivo.

### Tech

Tecnologias e libs utilizadas:

* .Net Core 3.1
* Fluent Assertions
* Polly
* MongoDB
* Docker
* JWT
* Swashbuckle
* Serilog

### Executando

Gerar a imagem docker a partir da raiz do projeto.

```sh
docker build -t exchangechallenge .
```

Para executar...

```sh
docker run -d -p 8080:80 {mais as variaveis de ambiente abaixo}
```

### Variaveis de Ambiente


| Var | Descrição |
| ------ | ------ |
| JWT_AUDIENCE | Audience JWT |
| JWT_SECRET | Secret JWT |
| JWT_ISSUER | Issuer JWT |
| CATEGORY_COLLECTION | Coleção das categorias no MongoDB |
| CATEGORY_DATABASE | Database das categorias no MongoDB |
| CATEGORY_CONN_STRING | Connection String para o MongoDB |
| EXCHANGE_RATES_URL | Url do Exchange Rates | 