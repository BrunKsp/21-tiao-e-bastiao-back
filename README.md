# 💻 Code Race 2025 - Tião e Bastião

## 👥 Integrantes
| Nome Completo | Função no Projeto |
|---------------|-------------------|
|Bruno Siqueira| Desenvolvedor Backend|
|Vitor Schumacher| Desenvolvedor Frontend |

---

## 🎯 Tema / Área do Problema
> Educação Digital / Avaliação Formativa Inteligente

---

## ❓ Problema a Ser Resolvido
> No cenário educacional brasileiro, há uma carência de ferramentas que consigam avaliar de forma contínua e personalizada o desempenho lógico dos alunos. Professores enfrentam dificuldades para acompanhar o progresso individual, e alunos carecem de feedback objetivo que ajude no aprendizado real — não apenas em notas finais.

---

## 💡 Descrição da Solução Proposta
Nossa aplicação é uma **API REST inteligente para avaliação lógica**, construída em .NET 8, que recebe respostas de questionários e calcula **pontuações médias por aluno**, organizadas por questionários.  
Os dados dos alunos e questões são armazenados em **PostgreSQL**, enquanto os resultados e análises são persistidos em **MongoDB**, permitindo **consultas agregadas e flexíveis** para professores e dashboards.

Essa arquitetura híbrida viabiliza análises rápidas e detalhadas do desempenho acadêmico de cada aluno ao longo do tempo.

---

## 🧱 Estrutura da Solução
```
Raiz do Projeto/
├── Api/               # Controllers e Endpoints
├── Application/       # Regras de negócio, serviços, DTOs
├── Crosscutting/      # Injeção de dependências e configurações
├── Data/              # Conexões e mapeamento para PostgreSQL e MongoDB
├── Infra/             # Repositórios e consultas em ambos os bancos
```
---

## 🛠 Tecnologias Utilizadas

- **.NET 8 (C#)** – Framework principal
- **PostgreSQL** – Armazenamento de dados relacionais
- **MongoDB** – Armazenamento de documentos flexíveis
- **Entity Framework Core** – ORM para PostgreSQL
- **MongoDB.Driver** – Driver oficial para C#
- **Swagger (Swashbuckle)** – Documentação da API
- **Docker** – Contêineres para banco e app
- **AutoMapper** – Mapeamento de DTOs e entidades
- **FluentValidation** – Validação de modelos

---

## ▶️ Instruções de Instalação e Execução

### 1. Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/) (opcional para banco)
- PostgreSQL rodando (porta 5432)
- MongoDB rodando (porta 27017)

### 2. Configuração

Edite o arquivo `.env` com suas credenciais:

```json
MONGO_DB_CONNECTION=mongodb://mongodb:mongodb@localhost:27017/?retryWrites=true&connectTimeoutMS=10000&authMechanism=SCRAM-SHA-256
MONGO_DB_DATABASE=code_race

DB_APP_USERNAME=admin
DB_APP_PASSWORD=admin
DB_APP_HOST=localhost
DB_APP_PORT=5432
DB_APP_DATABASE=apps
```

### 3. Execução

```bash
dotnet restore
dotnet build
dotnet run --project Api
```

A API estará disponível em: [http://localhost:5001/swagger](http://localhost:5001/swagger)

---

## 🧪 Exemplos de Endpoints

- `GET /api/exemplo` – Lista dados da entidade X
- `POST /api/exemplo` – Cria novo registro
- `GET /api/exemplo/busca?termo=` – Busca combinada em Mongo e PostgreSQL

---

## 📦 Documentação Técnica

- Swagger UI: [http://localhost:5001/swagger](http://localhost:5001/swagger)
- README com explicação de arquitetura, instalação e uso
- Diagrama de arquitetura (opcional)

---

## 📈 Modelo de Negócio

> Público-alvo: escolas, professores de ensino médio, cursos preparatórios

Pode ser integrado a plataformas LMS ou apps de reforço escolar

O backend pode gerar dados para dashboards personalizados e relatórios de desempenho

Foco educacional com potencial de impacto social em avaliações formativas

---

## 📣 Pitch

> Aplicação educacional simples, robusta e acessível, que permite a professores acompanhar o desempenho lógico dos alunos com clareza. Em vez de apenas aplicar testes, o sistema transforma respostas em dados úteis para personalizar o ensino — tudo de forma rápida, segura e integrada.

---

## ✅ Status da Aplicação

- [x] Backend funcional com conexão dupla (Mongo + Postgre)
- [x] Endpoints para envio de questionários e relatório por aluno
- [x] Estrutura limpa, testada e documentada com Swagger
- [x] Pronto para consumo por frontend educacional

---

## 🏁 Observações Finais

> Este projeto foi desenvolvido em 10 horas durante o Code Race 2025. Todo o código e ideias aqui apresentados são originais da equipe.
