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
using Client.CodeCompare;

namespace Client.WinPage
{
    /// <summary>
    /// Interaction logic for HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : UserControl
    {
        private ServiceContractClient _client;
        public HistoryPage(ServiceContractClient client)
        {
            _client = client;
            InitializeComponent();
            UpdateHistoryList();
        }

        private void UpdateHistoryList()
        {
            string[] history = _client.GetListHistory();
            foreach (var log in history)
            {
                FileListCompil.Items.Add(log);
            }
        }
    }
}
