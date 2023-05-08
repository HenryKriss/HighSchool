namespace HighSchool.Models
{
public class Personagem
    {
        // Atributos
        public int Numero { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<string> Habilidades { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }

        public string Imagem { get; set; }
        
        // Método Construtor
        public Personagem()
        {
            Habilidades = new List<string>();
        }
    }
}