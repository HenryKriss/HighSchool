using System.Text.Json;
using HighSchool.Models;

namespace HighSchool.Services
{
    public class HighSchoolService
    {
        private readonly IHttpContextAccessor _session;
        private readonly string personagemFile = @"Data\personagens.json";
        private readonly string habilidadesFile = @"Data\habilidades.json";

        public HighSchoolService(IHttpContextAccessor session)
        {
            _session = session;
            PopularSessao();
        }

        public List<Personagem> GetPersonagens()
        {
            PopularSessao();
            var personagens = JsonSerializer.Deserialize<List<Personagem>>
                (_session.HttpContext.Session.GetString("Personagens"));
            return personagens;
        }

        public List<Habilidade> GetHabilidades()
        {
            PopularSessao();
            var habilidades = JsonSerializer.Deserialize<List<Habilidade>>
                (_session.HttpContext.Session.GetString("Habilidades"));
                return habilidades;
        }

        public Personagem GetPersonagem(int Numero)
        {
            var personagens = GetPersonagens();
            return personagens.Where(p => p.Numero == Numero).FirstOrDefault();
        }

        public HighSchoolDto GetHighSchoolDto()
        {
            var galera = new HighSchoolDto()
            {
                Personagens = GetPersonagens(),
                Habilidades = GetHabilidades()
            };
            return galera;
        }

        public DetailsDto GetDetailedPersonagem(int Numero)
        {
            var personagens = GetPersonagens();
            var galerinha = new DetailsDto()
            {
                Current = personagens.Where(p => p.Numero == Numero)
                .FirstOrDefault(),
                Prior = personagens.OrderByDescending(p => p.Numero)
                .FirstOrDefault(p => p.Numero < Numero),
                Next = personagens.OrderBy(p => p.Numero)
                .FirstOrDefault(p => p.Numero > Numero),
            };
            return galerinha;
        }

        public Habilidade GetHabilidade(string Nome)
        {
            var habilidades = GetHabilidades();
            return habilidades.Where(t => t.Nome == Nome).FirstOrDefault();
        }

        private void PopularSessao()
        {
            if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Habilidades")))
            {
                _session.HttpContext.Session
                    .SetString("Personagens", LerArquivo(personagemFile));
                _session.HttpContext.Session
                    .SetString("Habilidades", LerArquivo(habilidadesFile));
            }
        }

        private string LerArquivo(string fileName)
        {
            using (StreamReader leitor = new StreamReader(fileName))
            {
                string dados = leitor.ReadToEnd();
                return dados;
            }
        }

    }
}