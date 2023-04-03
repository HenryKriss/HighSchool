using HighSchool.Models;
namespace HighSchool.Services
{
    public interface IHighSchoolService
    {
        List<Personagem> GetPersonagens();
        List<Habilidade> GetHabilidades();
        Personagem GetPersonagem(int Numero);
        HighSchoolDto GetHighSchoolDto();
        DetailsDto GetDetailedPersonagem(int Numero);
        Habilidade GetHabilidade(string Nome);
    }
}