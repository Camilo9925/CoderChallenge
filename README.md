# 🦆 Sistema de Catalogação de Patos Primordiais

> Um sistema para catalogar e estudar Patos Primordiais usando tecnologia alienígena avançada com drones autônomos.

![Status](https://img.shields.io/badge/Status-%20MissaoUmConcluida-yellow)
![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![C#](https://img.shields.io/badge/C%23-Latest-green)
![License](https://img.shields.io/badge/License-MIT-orange)

---

## 📋 Índice

- [Visão Geral](#visão-geral)
- [Requisitos](#requisitos)
- [Instalação](#instalação)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [API Endpoints](#api-endpoints)
- [Exemplos de Uso](#exemplos-de-uso)
- [Arquitetura](#arquitetura)

---

## 🎯 Visão Geral

O **Sistema de Catalogação de Patos Primordiais** é uma solução backend desenvolvida em **C#** que permite:

✅ **Catalogar Patos Primordiais** com informações detalhadas (altura, peso, mutações, status)  
✅ **Gerenciar Drones** coletores de dados com rastreamento de precisão GPS  
✅ **Simular Buscas** onde drones tentam encontrar e interagir com patos  
✅ **Revelar Super-Poderes** quando drones conseguem provocar patos despertos  
✅ **Medir Batimentos Cardíacos** de patos em transe ou hibernação  
✅ **Converter Unidades** automaticamente (pés→cm, libras→g, jardas→m)

---

## 📦 Requisitos

Antes de começar, certifique-se de ter instalado:

| Requisito | Versão | Link |
|-----------|--------|------|
| **.NET SDK** | 8.0+ | [Download](https://dotnet.microsoft.com/download) |
| **MySQL** | 8.0+ | [Download](https://dev.mysql.com/downloads/mysql/) |
| **Git** | Latest | [Download](https://git-scm.com/) |
| **VS Code**, **Visual Studio** ou outra IDe | Latest | [Download](https://visualstudio.microsoft.com/) |

### Verificar Instalação

```bash
# Verificar .NET
dotnet --version

# Verificar MySQL
mysql --version

# Verificar Git
git --version
```

---

## 🚀 Instalação

### 1️⃣ Clonar o Repositório

```bash
git clone https://github.com/Camilo9925/CoderChallenge
cd CoderChallenge.Api
```

### 2️⃣ Instalar Entity Framework Core Tools

```bash
dotnet tool install --global dotnet-ef
```

### 3️⃣ Restaurar Dependências

```bash
dotnet restore
```

### 4️⃣ Configurar Banco de Dados

Edite o arquivo `appsettings.Development.json`:

```json
{
  "DbConfig": {
    "ConnectionString": "Server=localhost;Port=3306;Database=patos_primordiais;User=root;Password=sua_senha;"
  }
}
```

**Ou use o atalho no Visual Studio:**
- Pressione `CTRL + ,` (VS) ou `CTRL + P` (VS Code)
- Pesquise por `appsettings.Development.json`

### 5️⃣ Criar o Banco de Dados

```bash
# Navegue até a pasta do projeto API
cd CoderChallenge.Api

# Execute a migração
dotnet ef database update -p ../CoderChallenge.Infrastructure
```

### 6️⃣ Executar a Aplicação

```bash
dotnet run
```

A API estará disponível em: `http://localhost:5202/swagger`

---

## 🔌 API Endpoints

### 🚁 **Drones Controller**

#### GET `/api/Drones`
Retorna todos os drones cadastrados.

**Resposta (200 OK):**
```json
{
  "sucesso": true,
  "dados": [
    {
      "id": "84995e93-4e66-4e8c-8213-c50894b8f428",
      "numeroSerie": "DRN-001-AZUL",
      "marca": "AeroTech",
      "fabricante": "SkyWorks Ltd.",
      "paisOrigem": "Brasil",
      "localizacao": {
        "id": "5f12d42c-c334-4ff8-920d-864082d80503",
        "cidade": "São Paulo",
        "pais": "Brasil",
        "latitude": -23.55052,
        "longitude": -46.63331,
        "pontoReferenciaConhecido": "Avenida Paulista",
        "precisao": {
          "id": "b3cbc153-a813-4ae8-9e1b-a3e4639267c4",
          "valor": 1.2,
          "unidadeOriginal": "m",
          "valorEmMetros": 1.2
        }
      },
      "ativo": true,
      "dataCriacao": "2025-10-27T15:15:13",
      "dataDestruicao": null
    }
  ],
  "mensagem": "1 drones encontrados",
  "erros": []
}
```

---

#### POST `/api/Drones`
Cria um novo drone.

- `pontoReferenciaConhecido` (opcional): Caso queira não passar o ponto de referência, apenas excluir do json.

**Body:**
```json
{
  "numeroSerie": "DRN-001-AZUL",
  "marca": "AeroTech",
  "fabricante": "SkyWorks Ltd.",
  "paisOrigem": "Brasil",
  "localizacao": {
    "cidade": "São Paulo",
    "pais": "Brasil",
    "latitude": -23.55052,
    "longitude": -46.63331,
    "precisao": {
      "valor": 1.2,
      "unidadeOriginal": "m",
      "valorEmMetros": 1.2
    },
    "pontoReferenciaConhecido": "Avenida Paulista"
  }
}
```

**Resposta (201 Created):**
```json
{
  "sucesso": true,
  "dados": {
    "id": "84995e93-4e66-4e8c-8213-c50894b8f428",
    "numeroSerie": "DRN-001-AZUL",
    "marca": "AeroTech",
    "fabricante": "SkyWorks Ltd.",
    "paisOrigem": "Brasil",
    "localizacao": {
      "id": "5f12d42c-c334-4ff8-920d-864082d80503",
      "cidade": "São Paulo",
      "pais": "Brasil",
      "latitude": -23.55052,
      "longitude": -46.63331,
      "pontoReferenciaConhecido": "Avenida Paulista",
      "precisao": {
        "id": "b3cbc153-a813-4ae8-9e1b-a3e4639267c4",
        "valor": 1.2,
        "unidadeOriginal": "m",
        "valorEmMetros": 1.2
      }
    },
    "ativo": true,
    "dataCriacao": "2025-10-27T15:15:12.5338675Z",
    "dataDestruicao": null
  },
  "mensagem": "Drone criado com sucesso",
  "erros": []
}
```

---

#### GET `/api/Drones/{id}`
Obtém um drone específico pelo ID.

---

#### GET `/api/Drones/Ativos`
Retorna apenas drones ativos.

---

#### GET `/api/Drones/Destruidos`
Retorna apenas drones destruídos.

---

#### PUT `/api/Drones/{id}`
Atualiza um drone existente.

- `pontoReferenciaConhecido` (opcional): Caso queira não passar o ponto de referência, apenas excluir do json.

**Body:** (preencha todos os campos)
```json
{
  "numeroSerie": "DRN-001-AZUL-UPDATED",
  "marca": "AeroTech",
  "fabricante": "SkyWorks Ltd.",
  "paisOrigem": "Brasil",
  "ativo": true,
  "localizacao": {
    "id": "id-localizacao",
    "cidade": "São Paulo",
    "pais": "Brasil",
    "latitude": -23.55052,
    "longitude": -46.63331,
    "pontoReferenciaConhecido": "Avenida Paulista",
    "precisao": {
      "id": "id-precisao",
      "valor": 1.2,
      "unidadeOriginal": "m",
      "valorEmMetros": 1.2
    }
  }
}
```

**Resposta (200 OK)**

```
{
  "sucesso": true,
  "dados": true,
  "mensagem": "Drone atualizado com sucesso",
  "erros": []
}
```

---

#### DELETE `/api/Drones/{id}`
Deleta um drone pelo id.

---

### 🦆 **Patos Controller**

#### GET `/api/Patos`
Retorna todos os patos cadastrados.

---

#### POST `/api/Patos`
Cria um novo pato primordial.

- `superpoder` (opcional): Se não passar, é gerado um superpoder aleatório no momento em que o drone provoca o pato e descobre o seu super-poder.
- `pontoReferenciaConhecido` (opcional): Caso queira não passar o ponto de referência, apenas excluir do json.
- `statusHibernacao`: Lembre-se de passar valores inteiros(1, 2 e 3), dúvidas verifique o Schema ou logo abaixo da documentação terá o que cada int representa.

**Body (Pato sem Super-Poder):**
```json
{
  "alturaCm": 45,
  "unidadeAltura": "cm",
  "pesoG": 1200,
  "unidadePeso": "g",
  "quantidadeMutacoes": 1,
  "statusHibernacao": 3,
  "superpoder": null,
  "localizacao": {
    "cidade": "Rio de Janeiro",
    "pais": "Brasil",
    "latitude": -22.9068,
    "longitude": -43.1729,
    "precisao": {
      "valor": 3,
      "unidadeOriginal": "m",
      "valorEmMetros": 3
    },
    "pontoReferenciaConhecido": "Praia de Copacabana"
  }
}

```

**Body(Pato com Super-Poder): **
```json
{
  "alturaCm": 50,
  "unidadeAltura": "cm",
  "pesoG": 1500,
  "unidadePeso": "g",
  "quantidadeMutacoes": 2,
  "statusHibernacao": 3,
  "superpoder": {
    "nome": "Grito Sônico",
    "descricao": "Emite um grito que causa dano em área e destrói estruturas",
    "classificacoes": [
      "bélico",
      "raro",
      "alto risco de surdez"
    ]
  },
  "localizacao": {
    "cidade": "São Paulo",
    "pais": "Brasil",
    "latitude": -23.5505,
    "longitude": -46.6333,
    "precisao": {
      "valor": 5,
      "unidadeOriginal": "m",
      "valorEmMetros": 5
    },
    "pontoReferenciaConhecido": "Avenida Paulista"
  }
}

```

**Status de Hibernação:**
- `1` = Hibernacao Profunda
- `2` = Em Transe
- `3` = Desperto

---

#### GET `/api/Patos/{id}`
Obtém um pato específico pelo ID.

---

#### PUT `/api/Patos/{id}`
Atualiza um pato existente.

---

#### DELETE `/api/Patos/{id}`
Deleta um pato.

---

### 🔍 **Busca Pato Controller**

#### POST `/api/BuscaPato/drone/{droneId}`
Executa a operação de busca de pato por um drone.

**Query Parameters:**
- `patoId` (opcional): ID específico do pato. Se não passar, busca aleatório.

**Resposta (Pato em Transe e Hibernação Profunda - Batimentos Medidos):**
```json
{
  "sucesso": true,
  "dados": {
    "mensagem": "Batimentos medidos: 109 BPM",
    "etapa": "medicao_batimentos",
    "patoEncontrado": true,
    "patoId": "9f656d83-b7d4-4e90-ab0e-d19ce9d3aa19",
    "statusPatoEncontrado": "HibernacaoProfunda",
    "droneDestruido": false,
    "batimentosCardiacosMedidos": 109,
    "taxaSucessoCalculada": null,
    "superpoder": null,
    "descricaoFenomeno": "O pato em HibernacaoProfunda apresenta 109 BPM. Seu coração bate de forma constante.",
    "droneNumeroSerie": "DRN-002-PRETO",
    "droneMarca": "AeroTech",
    "droneFabricante": "SkyWorks Ltd.",
    "dronePaisOrigem": "Brasil",
    "alturaCm": 45,
    "pesoG": 1200,
    "localizacao": {
      "id": null,
      "cidade": "Rio de Janeiro",
      "pais": "Brasil",
      "latitude": -22.9068,
      "longitude": -43.1729,
      "pontoReferenciaConhecido": "Praia de Copacabana",
      "precisao": {
        "id": null,
        "valor": 3,
        "unidadeOriginal": "m",
        "valorEmMetros": 3
      }
    }
  },
  "mensagem": "Busca de pato concluída",
  "erros": []
}
```

**Resposta (Pato Desperto - Super-Poder Revelado):**
```json
{
  "sucesso": true,
  "dados": {
    "mensagem": "Super-poder revelado: Grito Sônico",
    "etapa": "provocacao_sucesso",
    "patoEncontrado": true,
    "patoId": "9dea6907-22ab-451f-b1ce-96b3d0b69ad0",
    "statusPatoEncontrado": "Desperto",
    "droneDestruido": false,
    "batimentosCardiacosMedidos": null,
    "taxaSucessoCalculada": 63,
    "superpoder": {
      "id": null,
      "nome": "Grito Sônico",
      "descricao": "Emite um grito que causa dano em área e destrói estruturas",
      "classificacoes": [
        "bélico",
        "raro",
        "alto risco de surdez"
      ]
    },
    "descricaoFenomeno": "O pato foi provocado! Seu super-poder foi revelado!",
    "droneNumeroSerie": "DRN-002-PRETO",
    "droneMarca": "AeroTech",
    "droneFabricante": "SkyWorks Ltd.",
    "dronePaisOrigem": "Brasil",
    "alturaCm": 50,
    "pesoG": 1500,
    "localizacao": {
      "id": null,
      "cidade": "São Paulo",
      "pais": "Brasil",
      "latitude": -23.5505,
      "longitude": -46.6333,
      "pontoReferenciaConhecido": "Avenida Paulista",
      "precisao": {
        "id": null,
        "valor": 5,
        "unidadeOriginal": "m",
        "valorEmMetros": 5
      }
    }
  },
  "mensagem": "Busca de pato concluída",
  "erros": []
}
```

**Resposta (Drone Destruído):**
```json
{
  "sucesso": true,
  "dados": {
    "mensagem": "Drone destruído pelo pato!",
    "etapa": "provocacao_falha",
    "patoEncontrado": true,
    "patoId": "54831e0d-64b8-4eec-92d0-d4d0208ef2ab",
    "statusPatoEncontrado": "Desperto",
    "droneDestruido": true,
    "batimentosCardiacosMedidos": null,
    "taxaSucessoCalculada": 47,
    "superpoder": null,
    "descricaoFenomeno": "O pato contra-atacou com fúria! O drone foi destruído em uma explosão de energia!",
    "droneNumeroSerie": "DRN-002-PRETO",
    "droneMarca": "AeroTech",
    "droneFabricante": "SkyWorks Ltd.",
    "dronePaisOrigem": "Brasil",
    "alturaCm": 50,
    "pesoG": 1500,
    "localizacao": {
      "id": null,
      "cidade": "São Paulo",
      "pais": "Brasil",
      "latitude": -23.5505,
      "longitude": -46.6333,
      "pontoReferenciaConhecido": "Avenida Paulista",
      "precisao": {
        "id": null,
        "valor": 5,
        "unidadeOriginal": "m",
        "valorEmMetros": 5
      }
    }
  },
  "mensagem": "Busca de pato concluída",
  "erros": []
}
```

---

## 📚 Exemplos de Uso

### Exemplo 1: Criar Drone e Pato, depois Buscar
---

## 🏗️ Arquitetura

### Camadas

```
┌─────────────────────────────────────────┐
│         API Layer (Controllers)         │
│  DroneController, PatoController, etc   │
└────────────────┬────────────────────────┘
                 │
┌────────────────▼────────────────────────┐
│      Application Layer (Services)       │
│  DroneService, PatoService, etc         │
└────────────────┬────────────────────────┘
                 │
┌────────────────▼────────────────────────┐
│        Domain Layer (Entities)          │
│  DroneEntity, PatoPrimordialEntity, etc │
└────────────────┬────────────────────────┘
                 │
┌────────────────▼────────────────────────┐
│   Infrastructure Layer (Repository)     │
│  DroneRepository, PatoRepository, etc   │
└─────────────────────────────────────────┘
```

### Padrões Utilizados

- **Clean Architecture**: Separação clara de responsabilidades
- **Onion Pattern**: Dependências apontam para o centro
- **Repository Pattern**: Abstração de acesso a dados
- **Service Pattern**: Lógica de negócio centralizada
- **DTO Pattern**: Transferência de dados entre camadas
- **Mapper Pattern**: Conversão entre entidades e DTOs

---

## 📝 Conversão de Unidades

O sistema suporta conversão automática de unidades:

### Altura
- `cm` ou `centimetro` → centímetros
- `m` ou `metro` → centímetros (× 100)
- `ft` ou `pé` → centímetros (× 30.48)

### Peso
- `g` ou `grama` → gramas
- `kg` ou `quilograma` → gramas (× 1000)
- `lb` ou `libra` → gramas (× 453.592)

### Precisão GPS
- `m` ou `metro` → metros
- `cm` ou `centimetro` → metros (÷ 100)
- `km` ou `quilometro` → metros (× 1000)
- `yd` ou `jarda` → metros (× 0.9144)

---

## Possíveis Erros

### Erro: "Unable to create a 'DbContext'"

**Solução:** Certifique-se de que `appsettings.Development.json` está configurado corretamente.

### Erro: "Connection refused"

**Solução:** Verifique se MySQL está rodando na aba de Serviços do Gerenciador de Tarefas.

### Erro: "Migration pending"

**Solução:** Execute as migrações:
```bash
dotnet ef database update -p ../CoderChallenge.Infrastructure
```

---

## 📄 Licença

Este projeto está licenciado sob a Licença MIT

---

## 👥 Autores

- **Lucas de Oliveira Camilo** - *Desenvolvedor Principal*

---

**Última atualização:** 27 de Outubro de 2025