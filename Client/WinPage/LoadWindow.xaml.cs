using System;
using System.Collections.Generic;
using System.IO;
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
using Client.CodeCompare;
using Client.ObjectPararm;
using Client.SenderObject;
using Ionic.Zip;

namespace Client.WinPage
{
    /// <summary>
    /// Interaction logic for LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : Window
    {
        private LoadWindowParam _param;
        public LoadWindow(LoadWindowParam param)
        {
            InitializeComponent();
            _param = param;
            Load();
        }
        private async void Load()
        {
            MemoryStream memoryStream;
            using (memoryStream = new MemoryStream())
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddDirectory(@"C:\Users\nikok\source\repos\Epam");
                    zip.Save(memoryStream);
                }

                memoryStream.Seek(0, SeekOrigin.Begin);
            }

            AddingCodeObject sendParams = new AddingCodeObject()
            {
                Name = _param.Name,
                Description = _param.Description,
                CompileType = _param.TypeCompile,
                IsSearch = _param.IsSearch,
                FileMane = _param.FileName,
                Code = _param.Code,
                CompareLocal = _param.CompareLocal,
                Solution = memoryStream.ToArray()

            };
            //DataExchangeWithServer getCompilName = new DataExchangeWithServer("AddCode", "POST", JsonConvert.SerializeObject(sendParams), "application/json", true);
            //string result = await getCompilName.SendToServer();
            //if (result == null) return;
            //FillTheListBackResult(JsonConvert.DeserializeObject<ResultCompareObject>(result));
            ResultCompareObject result = await _param.Client.AddCodeAsync(sendParams);
            FillTheListBackResult(result);
            this.Close();
        }

        private void FillTheListBackResult(ResultCompareObject resultFromSerrver)
        {
            resultFromSerrver.ChildCodeText = resultFromSerrver.ChildCodeText;
            resultFromSerrver.MainCodeText = resultFromSerrver.MainCodeText;
            resultFromSerrver.ResultCompare = resultFromSerrver.ResultCompare;
            resultFromSerrver.TokkingChildCode = resultFromSerrver.TokkingChildCode;
            resultFromSerrver.TokkingMainCode = resultFromSerrver.TokkingMainCode;
            resultFromSerrver.IsLocalCompare = resultFromSerrver.IsLocalCompare;
        }
    }
}
