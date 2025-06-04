using application.Dtos.Auth;
using application.Dtos.Usuario;
using application.Exceptions;
using application.Interfaces;
using application.Utils;
using application.Validators.Usuario;
using AutoMapper;
using data.Infra.PG.Entities;
using infra.PG.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace application.Services;

public class UsuarioService : BaseService, IUsuarioService
{
    private readonly IUsuarioRepository _repository;
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;
    public UsuarioService(IUsuarioRepository repository, IMapper mapper, IAuthService authService, IUserInfo user) : base(user)
    {
        _repository = repository;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<UsuarioAutenticadoDto> CriarUsuario(CriarUsuarioDto dto)
    {
        Validate(new CriarUsuarioValidator(), dto);

        dto.Email = dto.Email.Trim();

        if (await _repository.BuscarPorSlug(dto.Email) != null)
        {
            throw CustomException.BadRequest(new { error = "Este email já está em uso" });
        }

        var usuario = _mapper.Map<UsuarioEntity>(dto);

        var senha = BC.HashPassword(dto.Senha);

        usuario.Senha = senha;

        await _repository.Criar(usuario);
        return _authService.GenerateJWT(usuario);
    }

    public async Task<UsuarioDto> AlterarUsuario(CriarUsuarioDto dto)
    {
        var produtor = GetUserSlug() ?? throw CustomException.ErroAutenticacao(new { error = "Erro ao tentar atualizar o produtor." });

        dto.Email = dto.Email.Trim();

        if (await _repository.BuscarPorSlug(dto.Email) != null)
        {
            throw CustomException.BadRequest(new { error = "Este email já está em uso" });
        }

        var usuario = await _repository.BuscarPorSlug(produtor);
        var senha = BC.HashPassword(dto.Senha);

        usuario.Email = dto.Email;
        usuario.Nome = dto.Nome;
        usuario.Senha = senha;

        await _repository.Alterar(usuario);

        return _mapper.Map<UsuarioDto>(usuario);
    }

    public async Task<UsuarioDto> BuscarInfo()
    {
        var slug = GetUserSlug();
        var produtor = await _repository.BuscarPorSlug(slug);
        return _mapper.Map<UsuarioDto>(produtor);
    }
}