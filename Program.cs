using Google.Apis.Drive.v3;
using Google.Apis.Download;
using Google.Apis.Services;
using System;
using System.IO;

namespace DriveDownloadApiKey
{
    class Program
    {
        // Nome da aplicação (pode ser qualquer nome)
        static string ApplicationName = "Google Drive Download via API_KEY";

        static void Main(string[] args)
        {
            // Substitua pela sua API_KEY obtida no Console de APIs do Google
            string apiKey = "";

            // ID do arquivo que você deseja baixar.
            // Exemplo: "1PzKiHuTp2dpu89dDM6GCS8EcCXXyzzz_"
	    // lembrando que o arquivo deve estar compartilhado de forma publica "Com quem possuir o link"
            string fileId = "";

            // Caminho local para salvar o arquivo baixado
            string destinationFile = "arquivo_baixado.zip";

            Console.WriteLine("Iniciando download do arquivo...");

            // Inicializa o serviço do Google Drive usando API_KEY
            var service = new DriveService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = ApplicationName
            });

            // Chama o método que realiza o download
            DownloadFile(service, fileId, destinationFile);

            Console.WriteLine("Download concluído e salvo em: " + destinationFile);
        }

        /// <summary>
        /// Faz o download de um arquivo do Google Drive utilizando a API com API_KEY.
        /// </summary>
        /// <param name="service">Instância do DriveService autenticado com API_KEY</param>
        /// <param name="fileId">ID do arquivo no Google Drive</param>
        /// <param name="destinationFilePath">Caminho local para salvar o arquivo</param>
        static void DownloadFile(DriveService service, string fileId, string destinationFilePath)
        {
            // Cria uma requisição para obter o arquivo
            var request = service.Files.Get(fileId);

            // Configura o monitoramento do progresso do download
            request.MediaDownloader.ProgressChanged += progress =>
            {
                switch (progress.Status)
                {
                    case DownloadStatus.Downloading:
                        Console.WriteLine("Baixando: {0} bytes baixados.", progress.BytesDownloaded);
                        break;
                    case DownloadStatus.Completed:
                        Console.WriteLine("Download concluído!");
                        break;
                    case DownloadStatus.Failed:
                        Console.WriteLine("Download falhou.");
                        break;
                }
            };

            // Realiza o download, gravando o conteúdo em um MemoryStream
            using (var stream = new MemoryStream())
            {
                request.Download(stream);

                // Reposiciona o ponteiro do stream para o início
                stream.Position = 0;

                // Salva o conteúdo do MemoryStream em um arquivo local
                using (var fileStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fileStream);
                }
            }
        }
    }
}
