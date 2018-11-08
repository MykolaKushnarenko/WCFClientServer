using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using Client.CodeCompare;
using Client.ObjectPararm;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using UserControl = System.Windows.Controls.UserControl;

namespace Client.WinPage
{
    /// <summary>
    /// Interaction logic for AddingSubmit.xaml
    /// </summary>
    public partial class AddingSubmit : UserControl
    {
        private Action<ResultCompareObject> _swichToResutl;
        private bool _search;
        private string _path;
        private ResultCompareObject _resultCompare;
        private List<string> _codeList;
        private ServiceContractClient _client;
        private Action _onBlur;
        private Action _offBlur;
        private string _solutionPath;
        public AddingSubmit(Action<ResultCompareObject> methodResult, bool isSearch, ServiceContractClient client, Action onBlure,Action offBlure)
        {
            _swichToResutl = methodResult;
            _resultCompare = new ResultCompareObject();
            _codeList = new List<string>();
            _search = isSearch;
            _client = client;
            _onBlur = onBlure;
            _offBlur = offBlure;
            InitializeComponent();
            PrintCompilName(CsharpLanguage.Content.ToString());
        }
        private string FileName => System.IO.Path.GetFileName(_path);
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ToggleButton button = (ToggleButton)sender;
            string name = button.Name;
            switch (name)
            {
                case "CsharpLanguage":
                    JavaLanguage.IsChecked = false;
                    CppLanguage.IsChecked = false;
                    CompilName.Items.Clear();
                    PrintCompilName(CsharpLanguage.Content.ToString());
                    break;
                case "JavaLanguage":
                    CsharpLanguage.IsChecked = false;
                    CppLanguage.IsChecked = false;
                    CompilName.Items.Clear();
                    PrintCompilName(JavaLanguage.Content.ToString());
                    break;
                case "CppLanguage":
                    CsharpLanguage.IsChecked = false;
                    JavaLanguage.IsChecked = false;
                    CompilName.Items.Clear();
                    PrintCompilName(CppLanguage.Content.ToString());
                    break;
            }
        }

        private void PrintCompilName(string lang)
        {

            string[] compileType =_client.GetComipeType(lang);
            foreach (var typeCompil in compileType)
            {
                CompilName.Items.Add(typeCompil);
            }

        }

        private string FileFolderDialog(string filter)
        {
            string res = "";
            OpenFileDialog myDialog = new OpenFileDialog
            {
                Filter = filter,
                CheckFileExists = true,
                Multiselect = true
            };
            if (myDialog.ShowDialog() == true)
            {
                res = myDialog.FileName;
            }

            return res;
        }
        private void AddFile_OnClick(object sender, RoutedEventArgs e)
        {
            if (CompilName.SelectedIndex == -1)
            {
                MessageBox.Show("Сhoose a type of compilation", "LOOK!", MessageBoxButton.OK);
                return;
            }

            string filter ="Исходные коды(*.cs;*.java;*.cpp;*.c)|*.cs;*.java;*.cpp;*.c" + "|Все файлы (*.*)|*.* ";
            string result = FileFolderDialog(filter);
            if (result != "")
            {
                _path = result;
                LoadFileToBD.Visibility = Visibility.Visible;
            }
            
        }

        private void LoadFileToBD_OnClick(object sender, RoutedEventArgs e)
        {
            string typeCompiler = (string)CompilName.SelectedItem;
            string lang = "";
            if (CsharpLanguage.IsChecked == true)
            {
                lang = (string)CsharpLanguage.Content;
            }
            else if (CppLanguage.IsChecked == true)
            {
                lang = (string)CppLanguage.Content;
            }
            else if (JavaLanguage.IsChecked == true)
            {
                lang = (string)JavaLanguage.Content;
            }
            
            LoadWindow load = new LoadWindow(GetParams(typeCompiler), ref _resultCompare);
            load.ShowDialog();
            if (_search && !(CompareMy.IsChecked ?? true))
            {
                _swichToResutl(_resultCompare);
            }
            else if (_search && (CompareMy.IsChecked ?? true))
            {
                LoadAlgorithmReflection myAlgorithmReflection = new LoadAlgorithmReflection(_resultCompare);
                myAlgorithmReflection.LocalCompareRun();
                _swichToResutl(_resultCompare);
            }
            else
            {
                CsharpLanguage.IsChecked = true;
                NameAuthor.Text = "Имя и Фамилия";
                Description.Text = "Краткое описание";
            }
        }

        private byte[] GetCode()
        {
            StreamReader file = new StreamReader(_path);
            byte[] code = file.CurrentEncoding.GetBytes(file.ReadToEnd());
            return code;
        }

        private void FullAnalysis_OnClick(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK && IsSLNFile(folder.SelectedPath))
            {
                _solutionPath = folder.SelectedPath;
            }
        }

        private bool IsSLNFile(string path)
        {
            string[] files = new DirectoryInfo(path).GetFiles("*.sln", SearchOption.AllDirectories)
                .Select(f => f.FullName).ToArray();
            if (files.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private LoadWindowParam GetParams(string typeCompiler)
        {
            LoadWindowParam param2 = new LoadWindowParam()
            {
                Name = NameAuthor.Text,
                Description = Description.Text,
                TypeCompile = typeCompiler,
                IsSearch = _search,
                Code = GetCode(),
                FileName = FileName,
                SolutionPath = _solutionPath,
                CompareLocal = CompareMy.IsChecked ?? true,
                Client = _client,
                OnBlur = _onBlur,
                OffBlur = _offBlur
            };
            //LoadWindowParam param = new LoadWindowParam(NameAuthor.Text, Description.Text, typeCompiler, _search, GetCode(), FileName, ref _resultCompare, CompareMy.IsChecked ?? true, _client, _onBlur, _offBlur);
            return param2;
        }
    }
}
