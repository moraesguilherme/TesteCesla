namespace GerenciamentoColaboradoresEmpresa.Api.Models.Entities
{
    public class ColaboradorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
        public bool Ativo { get; set; }
        public int? InformacoesEmpresaId { get; set; }
    }
}
