namespace GerenciamentoColaboradoresEmpresa.Domain.Models.Entities
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
        public bool Ativo { get; set; } = true;
        public int? InformacoesEmpresaId { get; set; }
    }
}
