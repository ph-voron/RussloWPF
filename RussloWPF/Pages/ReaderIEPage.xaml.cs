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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RussloWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReaderIEPage.xaml
    /// </summary>
    public partial class ReaderIEPage : Page
    {
        public ReaderIEPage()
        {
            InitializeComponent();
        }
        //
        public void Navigate()
        {
            Web.Navigate("https://new.pikabu.ru");
        }
    }
}
