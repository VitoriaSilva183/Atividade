[README (1).md](https://github.com/user-attachments/files/28285824/README.1.md)
# Sistema de Controle de Acesso

Sistema de autenticação e controle de acesso por níveis para ambientes hospitalares, desenvolvido em C#. Permite gerenciar o acesso de usuários a diferentes áreas físicas com base em perfis de permissão.

---

## Funcionalidades

- **Autenticação segura** com hash SHA-256 das senhas
- **Controle de acesso por área** (Recepção, Cirurgia, Servidor)
- **Três níveis de permissão** (Visitante, Funcionário, Administrador)
- **Histórico de acessos** com data, hora, usuário, área e resultado
- **Cadastro de novos usuários** exclusivo para administradores

---

## Níveis de Acesso

| Nível | Perfil       | Áreas Permitidas                    |
|-------|--------------|-------------------------------------|
| 1     | Visitante    | Recepção                            |
| 2     | Funcionário  | Recepção, Cirurgia                  |
| 3     | Administrador| Recepção, Cirurgia, Servidor        |

---

## Como Executar

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) instalado (versão 6.0 ou superior)

### Passos

```bash
# Clone o repositório
git clone <url-do-repositorio>
cd controle-de-acesso

# Compile e execute
dotnet run
```

---

## Usuário Padrão (Admin)

O sistema já vem com um administrador pré-cadastrado:

| Campo   | Valor         |
|---------|---------------|
| Usuário | `Adminvitoria` |
| Senha   | `admin7559`   |
| Nível   | 3 (Admin)     |

> ⚠️ Recomenda-se alterar as credenciais padrão antes de usar em produção.

---

## Fluxo de Uso

1. Insira usuário e senha no login
2. Escolha uma das opções disponíveis:
   - `1` — Solicitar acesso a uma área
   - `2` — Cadastrar novo usuário *(somente Admin)*
   - `3` — Visualizar histórico de acessos *(somente Admin)*
   - `0` — Sair do sistema
3. Ao solicitar acesso, informe a área desejada: `Recepcao`, `Cirurgia` ou `Servidor`
4. O sistema registra automaticamente o resultado (AUTORIZADO ou NEGADO) no histórico

---

## Estrutura do Código

```
Program.cs
├── Main()              → Loop principal: login e menu de opções
├── Usuario (classe)    → Modelo com nome, hash da senha e nível
├── GerarHash()         → Gera hash SHA-256 da senha em Base64
├── usuarios (lista)    → Armazena usuários em memória
└── historico (lista)   → Armazena registros de acesso em memória
```

---

## Segurança

- As senhas nunca são armazenadas em texto puro — apenas o hash SHA-256 é salvo
- O acesso às opções administrativas é validado por nível antes de qualquer operação

---

## Limitações

- Os dados (usuários e histórico) são armazenados apenas em memória e são perdidos ao encerrar o programa
- Não há persistência em banco de dados ou arquivo
- Não há limite de tentativas de login

---

## Possíveis Melhorias Futuras

- Persistência de dados com banco de dados ou arquivo JSON
- Bloqueio de conta após tentativas de login inválidas
- Interface gráfica (WinForms ou Web)
- Log exportável em CSV ou TXT
- Suporte a recuperação de senha
