# 📚 Clube da Leitura

Sistema desenvolvido em C# para gerenciamento de um **Clube da Leitura**, permitindo o controle de caixas, revistas, amigos e empréstimos.

---

## 📌 Descrição

O sistema funciona via **console** e permite ao usuário realizar todas as operações necessárias para gerenciar um acervo de revistas, incluindo:

- Cadastro e organização de caixas
- Controle de revistas
- Cadastro de amigos
- Gerenciamento de empréstimos e devoluções
- Persistência de dados em arquivo JSON

---

## ⚙️ Funcionalidades

### 🗃️ Gestão de Caixas
- Cadastrar caixas (com etiqueta, cor e dias de empréstimo)
- Editar caixas
- Excluir caixas (apenas se não houver revistas)
- Visualizar caixas cadastradas

---

### 📖 Gestão de Revistas
- Cadastrar revistas dentro de caixas
- Editar revistas
- Excluir revistas
- Visualizar revistas por caixa

---

### 👥 Gestão de Amigos
- Cadastrar amigos
- Editar dados dos amigos
- Excluir amigos (somente se não tiver empréstimos ativos)
- Visualizar lista de amigos

---

### 🔄 Gestão de Empréstimos
- Registrar empréstimos de revistas
- Registrar devoluções
- Visualizar empréstimos
- Verificação automática de atrasos

---

## 💾 Persistência de Dados

Os dados são armazenados no arquivo:

usuario.json

Utilizando a biblioteca:

System.Text.Json

O sistema:
- Salva automaticamente após alterações
- Carrega os dados ao iniciar

---

## 🔐 Login

O sistema possui autenticação simples:

Usuário: Gustavo  
Senha: 1234

---

## 🧱 Estrutura do Projeto

### 🔹 Classe `Program`
Responsável por:
- Menu principal
- Navegação entre funcionalidades
- Controle geral do sistema
- Persistência dos dados

---

### 🔹 Classe `Usuario`
Classe principal que gerencia:
- Caixas
- Amigos
- Empréstimos

Contém toda a lógica de negócio do sistema.

---

### 🔹 Classe `Caixa`
Representa uma caixa de revistas:
- Etiqueta
- Cor (com suporte a cores no terminal)
- Dias de empréstimo
- Lista de revistas

---

### 🔹 Classe `Revista`
Representa uma revista:
- Título
- Número da edição
- Ano de publicação
- Status (Disponível / Indisponível)

---

### 🔹 Classe `Amigo`
Representa um amigo:
- Nome
- Nome do responsável
- Telefone

---

### 🔹 Classe `Emprestimo`
Representa um empréstimo:
- Amigo
- Revista
- Data do empréstimo
- Data de devolução
- Status:
  - Aberto
  - Atrasado
  - Concluído

---

## 🧠 Regras de Negócio

- ❌ Não é possível excluir:
  - Caixas com revistas
  - Amigos com empréstimos ativos

- 📕 Uma revista:
  - Só pode ser emprestada se estiver **Disponível**

- 👤 Um amigo:
  - Não pode ter mais de **um empréstimo ativo**

- ⏱️ Empréstimos:
  - Têm prazo baseado na caixa
  - São automaticamente marcados como **Atrasados**

---

## ▶️ Como Executar

1. Compile o projeto:
```
dotnet build
```

2. Execute:
```
dotnet run
```

---

## 📋 Exemplo de Uso

1. Criar uma caixa  
2. Adicionar revistas  
3. Cadastrar um amigo  
4. Realizar um empréstimo  
5. Registrar devolução  

---

## 🛠️ Tecnologias Utilizadas

- C#
- .NET
- System.Text.Json

---

## 📌 Observações

- Interface baseada em console
- Uso de cores ANSI para melhor visualização
- Tratamento básico de erros com `try/catch`
