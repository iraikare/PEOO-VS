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
    class NCurso
    {
        private static List<Curso> cursos = new List<Curso>();

        public static void Inserir(Curso c)
        {
            Abrir();
            int id = 0;
            foreach (Curso obj in cursos)
                if (obj.Id > id) id = obj.Id;
            c.Id = id + 1;
            cursos.Add(c);
            Salvar();
        }
        public static List<Curso> Listar()
        {
            Abrir();
            return cursos;
        }
        public static void Atualizar(Curso c)
        {
            Abrir();
            foreach (Curso obj in cursos)
                if (obj.Id == c.Id)
                {
                    obj.Nome = c.Nome;
                    obj.Duracao = c.Duracao;
                    obj.Codigo = c.Codigo;
                    obj.IdDepartamento = c.IdDepartamento;
                }
            Salvar();
        }

        public static void Excluir(Curso c)
        {
            Abrir();
            Curso x = null;
            foreach (Curso obj in cursos)
                if (obj.Id == c.Id) x = obj;
            if (x != null) cursos.Remove(x);
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Curso>));
                f = new StreamReader("./cursos.xml");
                cursos = (List<Curso>)xml.Deserialize(f);
            }
            catch
            {
                cursos = new List<Curso>();
            }
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Curso>));
            StreamWriter f = new StreamWriter("./cursos.xml", false);
            xml.Serialize(f, cursos);
            f.Close();
        }
        public static void CadastrarCurso(Curso c, Departamento d)
        {
            c.IdDepartamento = d.Id;
            Atualizar(c);
        }
        public static List<Curso> Listar(Departamento d)
        {
            Abrir();
            List<Curso> listacursos = new List<Curso>();
            foreach (Curso obj in cursos)
                if (obj.IdDepartamento == d.Id) listacursos.Add(obj);
            return listacursos;
        }
    }
}
