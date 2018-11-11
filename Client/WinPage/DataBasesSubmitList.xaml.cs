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
using Client.SenderObject;

namespace Client.WinPage
{
    /// <summary>
    /// Interaction logic for DataBasesSubmitList.xaml
    /// </summary>
    public partial class DataBasesSubmitList : UserControl
    {
        public Action<ResultCompareObject> _resultMethod;
        private ServiceContractClient _client;
        public DataBasesSubmitList(Action<ResultCompareObject> method, ServiceContractClient client)
        {
            _client = client;
            _resultMethod = method;
            InitializeComponent();
            LoadListSubmit();
        }

        private  void LoadListSubmit()
        {
            string[] submitsFromDb = _client.GetListSubmit();
            foreach (var submit in submitsFromDb)
            {
                SubmitList.Items.Add(submit);
            }
            //DataExchangeWithServer getAllSubmit = new DataExchangeWithServer("GetListSubmit", "GET", "", "application/json", true);
            //string result = await getAllSubmit.SendToServer();
            //if (result == null) return;
            //List<string> listSubm = JsonConvert.DeserializeObject<List<string>>(result);
            //foreach (string submit in listSubm)
            //{
            //    SubmitList.Items.Add(submit);
            //}
        }

        private void SubmitList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string wordFromItemsList = SubmitList.SelectedValue.ToString();
            string[] get = wordFromItemsList?.Split(new char[] { '|' });
            ResultCompareObject result = _client.SearchFromListSubmit(get[get.Length - 1]);
            //DataExchangeWithServer getResultCompareFromSubmitList = new DataExchangeWithServer("SearchFromListSubmit", "POST", $"tagForSearch={get[get.Length - 1]}", "application/x-www-form-urlencoded", true);
            //string result = await getResultCompareFromSubmitList.SendToServer();
            //if (result == null) return;
            _resultMethod(result);


        }
    }
}
