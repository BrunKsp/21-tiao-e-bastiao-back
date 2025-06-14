using application.Dtos.IA;

namespace application.Interfaces;

public interface IIAService
{
    Task SalvarRespostaIa(RespostaIADto dto);
}