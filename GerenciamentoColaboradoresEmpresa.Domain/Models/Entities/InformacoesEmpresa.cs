namespace GerenciamentoColaboradoresEmpresa.Domain.Models.Entities
{
    public class InformacoesEmpresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public ICollection<Colaborador> Colaboradores { get; set; }
    }
}
