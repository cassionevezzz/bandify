# 🎸 Bandify

Aplicação web inspirada no [Bandsintown](https://www.bandsintown.com/): uma plataforma para descobrir artistas, acompanhar seus shows e (futuramente) receber notificações e recomendações personalizadas.

Desenvolvida em **ASP.NET Core 8 MVC** com **Entity Framework Core** e **SQLite**.

---

## ✨ Funcionalidades

### Implementadas
- **Página inicial** com cards de *Artistas Populares* e *Eventos Próximos*
- **Busca** por nome de artista ou evento (barra de pesquisa no menu)
- **CRUD de Artistas** — nome, gênero musical, descrição e URL da foto
- **CRUD de Eventos** — nome, local, data e artista associado
- **Autenticação completa** via ASP.NET Identity (cadastro, login, logout, recuperação de senha, 2FA, gerenciamento de conta e dados pessoais)

### Planejadas (modeladas, ainda sem telas)
- ⭐ **Avaliações** de eventos por usuários
- 🔔 **Notificações** (ex.: novo show de um artista seguido)
- 🎯 **Recomendações** por gênero musical
- ❤️ **Artistas favoritos** e histórico de eventos comparecidos por usuário

---

## 🛠️ Tecnologias

| Camada | Tecnologia |
|---|---|
| Framework | ASP.NET Core 8 (MVC + Razor Pages) |
| ORM | Entity Framework Core 8 |
| Banco de dados | SQLite (`app.db`) |
| Autenticação | ASP.NET Core Identity |
| Front-end | Razor Views, Bootstrap, jQuery |

---

## 📁 Estrutura do projeto

```
PB/
├── Areas/Identity/      # Páginas de autenticação (scaffold do Identity)
├── Controllers/
│   ├── HomeController.cs       # Página inicial e busca
│   ├── ArtistasController.cs   # CRUD de artistas
│   └── EventoesController.cs   # CRUD de eventos
├── Data/
│   ├── ApplicationDbContext.cs # DbContext (Identity + entidades do domínio)
│   └── Migrations/             # Migrações do EF Core
├── Models/              # Entidades do domínio
├── ViewModels/          # Modelos específicos das views
├── Views/               # Views Razor (Home, Artistas, Eventoes, Shared)
├── wwwroot/             # Arquivos estáticos (CSS, JS, libs)
├── Program.cs           # Configuração da aplicação
└── appsettings.json     # Connection string e logging
```

---

## 🗃️ Modelo de dados

```
Artista 1 ──── N Evento
   │               │
   │               └── N Avaliacao N ── 1 Usuario
   │                                       │
   └──────── N (favoritos) ────────────────┘

Notificacao    (independente)
Recomendacao   (independente)
```

| Entidade | Campos principais |
|---|---|
| `Artista` | `Nome`, `Genero`, `Descricao`, `PhotoUrl` |
| `Evento` | `Nome`, `Localizacao`, `Data`, `ArtistaId` |
| `Avaliacao` | `Mensagem`, `DataPublicada`, `Usuario`, `Evento` |
| `Usuario` | `Nome`, `Localizacao`, `ArtistasFavoritos`, `EventosComparecidos` |
| `Notificacao` | `TipoNotificao`, `Mensagem`, `DataEnvio` |
| `Recomendacao` | `TipoRecomendacao`, `Genero`, `Nome` |

---

## 🚀 Como executar

### Pré-requisitos
- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- Ferramenta do EF Core, necessária para criar o banco: `dotnet tool install --global dotnet-ef`

### Passos

```bash
# Clonar o repositório
git clone <url-do-repositorio>
cd bandsintown-clone/PB

# Restaurar dependências
dotnet restore

# Aplicar as migrações do EF Core (cria/atualiza o app.db)
dotnet ef database update

# Rodar a aplicação
dotnet run
```

> **Sobre o banco de dados:** o arquivo `app.db`  é gerado localmente pelo comando `dotnet ef database update`, que executa as migrações da pasta `PB/Data/Migrations`. Sem esse passo a aplicação não sobe, pois as tabelas não existem. Para recriar o banco do zero, apague `PB/app.db` (e os arquivos `app.db-shm` e `app.db-wal`, se houver) e rode o comando novamente.

A aplicação ficará disponível em:
- http://localhost:5276
- https://localhost:7003 (perfil `https`: `dotnet run --launch-profile https`)

### Dev Container
O repositório inclui um `.devcontainer` com a imagem `mcr.microsoft.com/devcontainers/dotnet:8.0`, podendo ser aberto diretamente no VS Code (Dev Containers) ou no GitHub Codespaces.

### Visual Studio
Abra `PB.sln` e execute com **F5**.

---

## 🔐 Autenticação

O cadastro exige confirmação de conta (`RequireConfirmedAccount = true`). Como não há serviço de e-mail configurado, após o registro a própria página de confirmação exibe um link para confirmar a conta manualmente — basta clicar nele para ativar o usuário em ambiente de desenvolvimento.

---

## 🗺️ Rotas principais

| Rota | Descrição |
|---|---|
| `/` | Página inicial |
| `/Home/Search?query=...` | Busca de artistas e eventos |
| `/Artistas` | Listagem e gerenciamento de artistas |
| `/Eventoes` | Listagem e gerenciamento de eventos |
| `/Identity/Account/Register` | Cadastro |
| `/Identity/Account/Login` | Login |

---

## ⚠️ Problemas conhecidos

- A página inicial carrega eventos sem incluir o `Artista` relacionado (`.Include`), o que pode causar erro quando há eventos cadastrados.
- O link dos cards de evento na home aponta para o controller `Eventos` em vez de `Eventoes`.
- A edição de eventos não inclui `ArtistaId` no `[Bind]`, perdendo o vínculo com o artista.
---

## 🧭 Próximos passos

- [ ] Corrigir os problemas conhecidos acima
- [ ] Telas de avaliação de eventos
- [ ] Seguir/favoritar artistas
- [ ] Sistema de notificações
- [ ] Recomendações por gênero
- [ ] Restringir cadastro/edição a usuários autenticados (ou administradores)
- [ ] Filtrar "Eventos Próximos" por data e localização do usuário
