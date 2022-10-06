using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CadastroAluno.Models;


namespace TesteAlunos.Test
{
    public class AlunoTest
    {


        [Theory]
        [InlineData("Joao", "T91")]
        [InlineData("J", " ")]
        [InlineData(" ", "%")]
        [InlineData("", "¨*/*")]
        public void AtualizarOsDados_EverificaExatamenteOqueFoiGravado_RetornaOqueFoiGravado(string nome, string turma)
        {
            //Arrange
            Aluno aluno = new Aluno();
            aluno.Nome = "Joao";
            aluno.Turma = "T92";

            //Act
            aluno.AtualizarDados(nome, turma);

            //Assert
            Assert.Equal(aluno.Nome, nome);
            Assert.Equal(aluno.Turma, turma);
        }


        //Teste Falho pois o método está somente Notas acimas de 5 e não iguais a 5
        [Fact]
        public void UtilizaOmetodoDeValidacaoEvalidaSeAmediaEMaior_RetornaVerdadeiro()
        {
            //Arrange
            Aluno aluno = new Aluno();
            


            //Act
            var result = aluno.VerificaAprovacao();

            //Assert
            Assert.True(result);
        }


        //O método AtualizaMedia() deve atualizar a propriedade Media com o novo valor recebido.

        [Theory]
        [InlineData(5.9)]
        [InlineData(9.6)]
        public void Utiliza_O_metodoAtualizaMedia_E_valida_Se_Os_Valores_Foram_Alterados(Double media)
        {
            //Arrange
            Aluno aluno = new Aluno();
            aluno.Media = 4.0;


            //Act
            aluno.AtualizaMedia(media);

            //Assert
            Assert.Equal(aluno.Media, media);
        }

    }
}
