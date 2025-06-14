namespace application.Dtos.Questionario
{
    public class QuestionarioRespondidoDto
    {
        public string Tema { get; set; }
        public List<RespostaQuestaoDto> Questoes { get; set; }
    }
}