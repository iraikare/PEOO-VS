using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadeApp
{
    class NDepartamento
    {
        private static List<Departamento> deps = new List<Departamento>();

        public static void Inserir(Departamento d)
        {
            Abrir();
            int id = 0;
            foreach (Departamento obj in deps)
                if (obj.Id > id) id = obj.Id;
            d.Id = id + 1;
            deps.Add(d);
            Salvar();
        }
        public static List<Departamento> Listar()
        {
            Abrir();
            return deps;
        }
        public static void Atualizar(Departamento d)
        {
            Abrir();
            foreach (Departamento obj in deps)
                if (obj.Id == d.Id)
                {
                    obj.Nome = d.Nome;
                    obj.Sigla = d.Sigla;
                    obj.Localizacao = d.Localizacao;
                    obj.IdUniversidade = d.IdUniversidade;
                }
            Salvar();
        }

        public static void Excluir(Departamento d)
        {
            Abrir();
            Departamento x = null;
            foreach (Departamento obj in deps)
                if (obj.Id == d.Id) x = obj;
            if (x != null) deps.Remove(x);
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Departamento>));
                f = new StreamReader("./deps.xml");
                deps = (List<Departamento>)xml.Deserialize(f);
            }
            catch
            {
                deps = new List<Departamento>();
            }
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Departamento>));
            StreamWriter f = new StreamWriter("./deps.xml", false);
            xml.Serialize(f, deps);
            f.Close();
        }
        public static void CadastrarDepartamento(Departamento d, Universidade u)
        {
            d.IdUniversidade = u.Id;
            Atualizar(d);
        }
        public static List<Departamento> Listar(Universidade u)
        {
            Abrir();
            List<Departamento> listadep = new List<Departamento>();
            foreach (Departamento obj in deps)
                if (obj.IdUniversidade == u.Id) listadep.Add(obj);
            return listadep;
        }
    }
}
