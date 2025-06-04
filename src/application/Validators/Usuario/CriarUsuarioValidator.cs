using application.Dtos.Usuario;
using FluentValidation;

namespace application.Validators.Usuario;

public class CriarUsuarioValidator : AbstractValidator<CriarUsuarioDto>
{
    public CriarUsuarioValidator()
    {
        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("Email é obrigatiorio")
            .EmailAddress().WithMessage("Insira um email válido");

        RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório");

        RuleFor(p => p.Senha)
            .NotEmpty().WithMessage("Senha é obrigatório");
    }
}