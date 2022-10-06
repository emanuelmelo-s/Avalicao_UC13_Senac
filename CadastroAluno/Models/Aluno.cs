namespace CadastroAluno.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Turma { get; set; }
        public double Media { get; set; }

        public void AtualizarDados(string nome, string turma)
        {
            Nome = nome;
            Turma = turma;
        }

        public bool VerificaAprovacao() 
            => Media > 5;
        //Deveria verificar se a aprovação é pela média igual a 5 ou Maior que 5

        public void AtualizaMedia(double novaMedia)
        {
            Media = novaMedia;
        }
    }
}
