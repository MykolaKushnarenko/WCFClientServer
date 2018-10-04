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
using Client.WinPage;
using Ionic.Zip;


namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _nameUser { get; set; }
        private ServiceContractClient client { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            client = new ServiceContractClient();
            GridContentAction.Children.Add(new AddingSubmit(Result, false, client));
            Visibility = Visibility.Hidden;
            AutificationWindow();
        }

        private void AutificationWindow()
        {
            AuthorizationWindow login = new AuthorizationWindow(VisibilityAfterUutification, CloseProgram, SetName, SetImageProfile);
            login.ShowDialog();
            NameUser.Text = _nameUser;
        }
        private void LoOutBut_OnClick(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void OpemMenuButton_OnClick(object sender, RoutedEventArgs e)
        {
            OpemMenuButton.Visibility = Visibility.Collapsed;
            CloseMenuButton.Visibility = Visibility.Visible;
            UserPhoto.Visibility = Visibility.Visible;
        }

        private void CloseMenuButton_OnClick(object sender, RoutedEventArgs e)
        {
            OpemMenuButton.Visibility = Visibility.Visible;
            CloseMenuButton.Visibility = Visibility.Collapsed;
            UserPhoto.Visibility = Visibility.Collapsed;
        }


        private void ListViewMenu_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            switch (index)
            {
                case 0:
                    GridContentAction.Children.Clear();
                    GridContentAction.Children.Add(new AddingSubmit(Result, false, client));
                    break;
                case 1:
                    GridContentAction.Children.Clear();
                    GridContentAction.Children.Add(new AddingSubmit(Result, true, client));
                    break;
                case 2:
                    GridContentAction.Children.Clear();
                    GridContentAction.Children.Add(new DataBasesSubmitList(Result));
                    break;
                case 3:
                    GridContentAction.Children.Clear();
                    GridContentAction.Children.Add(new HistoryPage());
                    break;
            }
            MoveOnSecectItem(index);
        }

        private void MoveOnSecectItem(int indexItem)
        {
            TransitionContentSlide.OnApplyTemplate();
            GridSelection.Margin = new Thickness(0, ((indexItem * 75)), 0, 0);
        }

        private void Result(ResultCompareObject resultList)
        {
            ResultPage result = new ResultPage(resultList);


            //textCode.ToolTip = db.GetInfoSubm(true);
            //textCode2.ToolTip = db.GetInfoSubm(false);

            GridContentAction.Children.Clear();
            GridContentAction.Children.Add(result);

        }

        private void Title_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => this.DragMove();

        private void HelpButt_OnClick(object sender, RoutedEventArgs e)
        {
            GridContentAction.Children.Clear();
            GridContentAction.Children.Add(new HelpPage());
        }

        private void VisibilityAfterUutification() => this.Visibility = Visibility.Visible;

        private void CloseProgram() => this.Close();

        private void AccountInfo_OnClick(object sender, RoutedEventArgs e)
        {
            GridContentAction.Children.Clear();
            GridContentAction.Children.Add(new ChangeUserInfo(_nameUser, SetImageProfile));
        }

        private void SetName(string name) => _nameUser = name;

        private void SetImageProfile(ImageSource image) => ProfilImage.Source = image;
    }
}
