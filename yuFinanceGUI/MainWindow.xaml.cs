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

using yuFinance;

namespace yuFinanceGUI
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public IContextBuilder Builder { get; private set; }
        public IContextStorer Storer { get; private set; }
        public Context Context { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            var kmk = System.IO.Path.Combine(UtlConfig.BasePath, UtlConfig.GetSetting("KmkMaster"));
            var tr = System.IO.Path.Combine(UtlConfig.BasePath, UtlConfig.GetSetting("TrMaster"));
            var jnl = System.IO.Path.Combine(UtlConfig.BasePath, UtlConfig.GetSetting("Journal"));

            this.Builder = new FromFileBuilder(kmk, tr, jnl);
            this.Storer = new ToFileStorer(kmk, tr, jnl);
            this.Context = this.Builder.Build();

            var trapp = new TrMasterApp(this.Context);
            var result = trapp.AddTr(new First(), "001", "hoge co.ltd");

            switch(result)
            {
                case Success<bool> x:
                    this.Context.Store(this.Storer);
                    break;
                case Faild x:
                    Console.Out.WriteLine(x.Error);
                    break;
            }
        }
    }
}
