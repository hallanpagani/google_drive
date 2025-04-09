# Download de Arquivo do Google Drive via API_KEY

## Introdução

Este é um projeto de console em C# que demonstra como baixar arquivos públicos do Google Drive utilizando a API do Google Drive e uma API_KEY.  
O sistema permite realizar downloads diretos — por exemplo, de um arquivo de 300 MB — sem a necessidade de autenticação via OAuth.

## Descrição

O sistema utiliza uma API_KEY para acessar a API do Google Drive e efetuar o download de um arquivo que esteja configurado como público.  
Durante o processo, o progresso do download é exibido no console e o arquivo é salvo localmente (por padrão, com o nome `arquivo_baixado.bin`).

## Requisitos

- [.NET 5.0 ou superior](https://dotnet.microsoft.com/download)
- Conexão com a Internet
- Uma API_KEY obtida no [Google Cloud Console](https://console.developers.google.com/)
- API do Google Drive habilitada para o projeto no Google Cloud Console
- O arquivo no Google Drive deve estar configurado como público

## Configuração

### 1. Obter a API_KEY

- Acesse o [Google Cloud Console](https://console.developers.google.com/).
- Crie um novo projeto ou selecione um projeto existente.
- No menu da biblioteca de APIs, habilite a **API do Google Drive**.
- Na seção **Credenciais**, clique em "Criar credenciais" e selecione **API_KEY**.
- Copie a API_KEY gerada, pois ela será utilizada no sistema.

### 2. Clonar ou criar o projeto

- **Clonando o repositório (se disponível):**
  ```bash
  git clone <URL_DO_REPOSITORIO>
  cd <NOME_DO_PROJETO>

- Ou baixe o projeto e abra o projeto no **Visual Studio Code** (ou utilize outro editor de sua preferência).

### 2.1 

- No arquivo Program.cs, substitua o valor da variável apiKey pela sua API_KEY obtida no Google Cloud Console.
Atualize a variável fileId com o ID do arquivo público que você deseja baixar.
Caso necessário, ajuste o nome e o caminho do arquivo de destino definido na variável destinationFile.

### 3. Dependências
dotnet restore

- Esse comando irá restaurar todas as dependências listadas, incluindo o Google.Apis.Drive.v3.
Porém, se a referência ao pacote não estiver presente no arquivo do projeto, será necessário executar o comando:

dotnet add package Google.Apis.Drive.v3

### 4. Rodar
```bash
dotnet build
dotnet run




