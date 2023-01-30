using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadeApp
{
    class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Duracao { get; set; }
        public int Codigo { get; set; }
        public int IdDepartamento { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Nome} - {Duracao} - {Codigo} - Departamento: {IdDepartamento}";
        }
    }
}
