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

        private async void UpdateHistoryList()
        {
            string[] history = await _client.GetListHistoryAsync();
            foreach (var log in history)
            {
                FileListCompil.Items.Add(log);
            }
            //DataExchangeWithServer getHistory = new DataExchangeWithServer("GetListHistory", "GET", "", "application/json", true);
            //string result = await getHistory.SendToServer();
            //if (result == null) return;
            //List<string> listHistory = JsonConvert.DeserializeObject<List<string>>(result);
            //FileListCompil.Items.Clear();
            //foreach (var desc in listHistory)
            //{
            //    FileListCompil.Items.Add(desc);
            //}
        }
    }
}
