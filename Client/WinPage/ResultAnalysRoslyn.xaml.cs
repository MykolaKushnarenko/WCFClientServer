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
using Client.CodeCompare;

namespace Client.WinPage
{
    /// <summary>
    /// Interaction logic for ResultAnalysRoslyn.xaml
    /// </summary>
    public partial class ResultAnalysRoslyn : Window
    {
        private DAnalysClassObject[] resultRoslyn = null;
        public ResultAnalysRoslyn(ResultCompareObject resultuCompareObject)
        {
            resultRoslyn = resultuCompareObject.DeteilAnalysRoslyn;
            InitializeComponent();
            InitTextAnalysis();
        }
        public void InitTextAnalysis()
        {

            foreach (var classInfo in resultRoslyn)
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = $"Class: {classInfo.ClassName}";
                if (classInfo.BaseClasses != "")
                {
                    item.Items.Add(new Label()
                    {
                        Content = $"Inherited: {classInfo.BaseClasses}"
                    });
                }

                if (classInfo.HasError)
                {
                    foreach (var errorString in classInfo.Error)
                    {
                        item.Items.Add(new Label()
                        {
                            Content = $"Error: {classInfo.BaseClasses}"
                        });
                    }
                }
                foreach (var method in classInfo.AllMethod)
                {
                    
                    TreeViewItem newMethodInfo = new TreeViewItem()
                    {
                        Header = $"Method: {method.Name}"
                    };
                    StackPanel stackPanel = new StackPanel(); 
                    foreach (var TypeInMethd in method.AllTypeInMethod)
                    {
                        stackPanel.Children.Add(new Label()
                        {
                            Content = $"Type: {TypeInMethd}",
                        });
                    }

                    newMethodInfo.Items.Add(stackPanel);
                    item.Items.Add(newMethodInfo);
                }
                TreeView.Items.Add(item);
            }
        }
    }
}
