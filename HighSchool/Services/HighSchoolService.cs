using System.Text.Json;
using HighSchool.Models;

namespace HighSchool.Services
{
    public class HighSchoolService
    {
        private readonly IHttpContextAccessor _session;
        private readonly string personagemFile = @"Data\personagens.json";
        private readonly string habilidadesFile = @"Data\habilidades.json";


    }
}