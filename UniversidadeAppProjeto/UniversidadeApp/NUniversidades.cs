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
    class NUniversidades
    {
        private static List<Universidade> unis = new List<Universidade>();

        public static void Inserir(Universidade u)
        {
            Abrir();
            int id = 0;
            foreach (Universidade obj in unis)
                if (obj.Id > id) id = obj.Id;
            u.Id = id + 1;
            unis.Add(u);
            Salvar();
        }
        public static List<Universidade> Listar()
        {
            Abrir();
            return unis;
        }
        public static void Atualizar(Universidade u)
        {
            Abrir();
            foreach (Universidade obj in unis)
                if (obj.Id == u.Id)
                {
                    obj.Nome = u.Nome;
                    obj.Sigla = u.Sigla;
                }
            Salvar();
        }

        public static void Excluir(Universidade u)
        {
            Abrir();
            Universidade x = null;
            foreach (Universidade obj in unis)
                if (obj.Id == u.Id) x = obj;
            if (x != null) unis.Remove(x);
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Universidade>));
                f = new StreamReader("./unis.xml");
                unis = (List<Universidade>)xml.Deserialize(f);
            }
            catch
            {
                unis = new List<Universidade>();
            }
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Universidade>));
            StreamWriter f = new StreamWriter("./unis.xml", false);
            xml.Serialize(f, unis);
            f.Close();
        }
    }
}
