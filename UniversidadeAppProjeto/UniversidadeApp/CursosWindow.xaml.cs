using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UniversidadeApp
{
    /// <summary>
    /// Lógica interna para CursosWindow.xaml
    /// </summary>
    public partial class CursosWindow : Window
    {
        public CursosWindow()
        {
            InitializeComponent();
        }

        private void InserirClick(object sender, RoutedEventArgs e)
        {
            Curso c = new Curso();
            c.Id = int.Parse(txtId.Text);
            c.Nome = txtNome.Text;
            c.Duracao = txtDuracao.Text;
            c.Codigo = txtCodigo.Text;
            NCurso.Inserir(c);
            ListarClick(sender, e);
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listCursos.ItemsSource = null;
            listCursos.ItemsSource = NCurso.Listar();
        }

        private void AtualizarClick(object sender, RoutedEventArgs e)
        {
            Curso c = new Curso();
            c.Id = int.Parse(txtId.Text);
            c.Nome = txtNome.Text;
            c.Duracao = txtDuracao.Text;
            c.Codigo = txtCodigo.Text;
            NCurso.Atualizar(c);
            ListarClick(sender, e);
        }

        private void ExcluirClick(object sender, RoutedEventArgs e)
        {
            Curso c = new Curso();
            c.Id = int.Parse(txtId.Text);
            NCurso.Excluir(c);
            ListarClick(sender, e);
        }

        private void listCursos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listCursos.SelectedItem != null)
            {
                Curso obj = (Curso)listCursos.SelectedItem;
                txtId.Text = obj.Id.ToString();
                txtNome.Text = obj.Nome;
                txtDuracao.Text = obj.Duracao;
                txtCodigo.Text = obj.Codigo;
            }
        }
    }
}
