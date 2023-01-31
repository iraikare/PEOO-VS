using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadeApp
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public int IdUniversidade { get; set; }
        public string Localizacao { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Nome} - {Sigla} - {Localizacao} - Universidade: {IdUniversidade}";
        }
    }
}
