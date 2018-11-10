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
        private ResultCompareObject _resultCompare;
        public LoadWindow(LoadWindowParam param, ref ResultCompareObject resultCompare)
        {
            InitializeComponent();
            _param = param;
            _resultCompare = resultCompare;
            _param.OnBlur();
            Load();
        }
        private async void Load()
        {
           
            AddingCodeObject sendParams = new AddingCodeObject()
            {
                Name = _param.Name,
                Description = _param.Description,
                CompileType = _param.TypeCompile,
                IsSearch = _param.IsSearch,
                FileMane = _param.FileName,
                Code = _param.Code,
                CompareLocal = _param.CompareLocal,
                IsAllAnalysis = _param.RoslynAnalysis

            };
            if (_param.SolutionPath != null)
            {
                MemoryStream memoryStream;
                using (memoryStream = new MemoryStream())
                {
                    using (ZipFile zip = new ZipFile())
                    {
                        zip.AddDirectory(_param.SolutionPath);
                        zip.Save(memoryStream);
                    }

                    memoryStream.Seek(0, SeekOrigin.Begin);
                    sendParams.Solution = memoryStream.ToArray();
                    sendParams.IsAllAnalysis = true;
                }
            }
            
            //DataExchangeWithServer getCompilName = new DataExchangeWithServer("AddCode", "POST", JsonConvert.SerializeObject(sendParams), "application/json", true);
            //string result = await getCompilName.SendToServer();
            //if (result == null) return;
            //FillTheListBackResult(JsonConvert.DeserializeObject<ResultCompareObject>(result));
            ResultCompareObject result = await _param.Client.AddCodeAsync(sendParams);
            _param.OffBlur();
            FillTheListBackResult(result);
            this.Close();
        }

        private void FillTheListBackResult(ResultCompareObject resultFromSerrver)
        {
            _resultCompare.ChildCodeText = resultFromSerrver.ChildCodeText;
            _resultCompare.MainCodeText = resultFromSerrver.MainCodeText;
            _resultCompare.ResultCompare = resultFromSerrver.ResultCompare;
            _resultCompare.TokkingChildCode = resultFromSerrver.TokkingChildCode;
            _resultCompare.TokkingMainCode = resultFromSerrver.TokkingMainCode;
            _resultCompare.IsLocalCompare = resultFromSerrver.IsLocalCompare;
            _resultCompare.DeteilAnalysRoslyn = resultFromSerrver.DeteilAnalysRoslyn;
        }
    }
}
