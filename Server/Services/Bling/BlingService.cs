using Newtonsoft.Json.Linq;
using eCommerce.Shared.Models;
using LiteDB;

namespace eCommerce.Server.Services.Bling;

public class BlingService
{
    private readonly LiteDatabase _db;
   
    public BlingService(LiteDatabase db)
    {
        _db = db;
    }

    public async Task<JobFilaResponse> EnviarProdutos(string loja)
    {

            var caminhoArquivoJson = loja;
        var objectId = ObjectId.NewObjectId();

        var job = new JobFila
        {
            Id = objectId,
            Tipo = TipoJob.Bling,
            Status = StatusJob.Pendente,
            DataCriacao = DateTime.Now,
            CaminhoArquivoProduto = caminhoArquivoJson
        };

        _db.GetCollection<JobFila>("jobs").Insert(job);

        return new JobFilaResponse
        {
            Id = job.IdString,
            Status = job.Status,
            Tipo = job.Tipo,
            DataCriacao = job.DataCriacao,
            CaminhoArquivoProduto = job.CaminhoArquivoProduto,
            Mensagem = job.Mensagem
        };
    }  
}