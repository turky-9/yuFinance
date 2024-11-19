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
using yuFinance.app;
using yuFinance.context;
using yuFinance.model;

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
        public TrMasterApp TrApp { get; private set; }
        public KmkMasterApp KmkApp { get; private set; }

        public const string MSG_TITLE = "yuFinance";
        public const string EXEC_OK = "登録しました";

        public MainWindow()
        {
            InitializeComponent();
            var kmk = System.IO.Path.Combine(UtlConfig.BasePath, UtlConfig.GetSetting("KmkMaster"));
            var tr = System.IO.Path.Combine(UtlConfig.BasePath, UtlConfig.GetSetting("TrMaster"));
            var jnl = System.IO.Path.Combine(UtlConfig.BasePath, UtlConfig.GetSetting("Journal"));

            this.Builder = new FromFileBuilder(kmk, tr, jnl);
            this.Storer = new ToFileStorer(kmk, tr, jnl);
            this.Context = this.Builder.Build();
            this.TrApp = new TrMasterApp(this.Context);
            this.KmkApp = new KmkMasterApp(this.Context);

            this.dgTr.ItemsSource = this.TrApp.GetList();
            this.dgKmk.ItemsSource = this.KmkApp.GetList();

            this.InitComboBox();
        }

        private void InitComboBox()
        {
            var ksrc = new List<KeyValuePair<EKmkKbn, string>>();
            ksrc.Add(new KeyValuePair<EKmkKbn, string>(EKmkKbn.Assets, "資産"));
            ksrc.Add(new KeyValuePair<EKmkKbn, string>(EKmkKbn.Liabilities, "負債"));
            ksrc.Add(new KeyValuePair<EKmkKbn, string>(EKmkKbn.Equity, "資本"));
            ksrc.Add(new KeyValuePair<EKmkKbn, string>(EKmkKbn.Revenue, "収益"));
            ksrc.Add(new KeyValuePair<EKmkKbn, string>(EKmkKbn.Expenses, "費用"));
            this.cbKmkInpKKbn.ItemsSource = ksrc;

            var dcsrc = new List<KeyValuePair<EDrCrKbn, string>>();
            dcsrc.Add(new KeyValuePair<EDrCrKbn, string>(EDrCrKbn.Debtor, "借方"));
            dcsrc.Add(new KeyValuePair<EDrCrKbn, string>(EDrCrKbn.Creditor, "貸方"));
            this.cbKmkInpDCKbn.ItemsSource = dcsrc;

        }

        private void BtnKmkInpExec_Click(object sender, RoutedEventArgs e)
        {
            var cd = this.txtKmkInpCd.Text;
            var nm = this.txtKmkInpName.Text;
            var kkbn = this.cbKmkInpKKbn.SelectedValue == null ? EKmkKbn.None : (EKmkKbn)this.cbKmkInpKKbn.SelectedValue; 
            var dckbn = this.cbKmkInpDCKbn.SelectedValue == null ? EDrCrKbn.None : (EDrCrKbn)this.cbKmkInpDCKbn.SelectedValue;
            var order = this.txtKmkInpOrder.Text;

            var result = this.KmkApp.InsKmk(cd, nm, kkbn, dckbn, order);

            switch (result)
            {
                case Success<DatKmk> x:
                    this.Context.Store(this.Storer);
                    MessageBox.Show(EXEC_OK, MSG_TITLE, MessageBoxButton.OK, MessageBoxImage.None);
                    break;
                case Faild x:
                    MessageBox.Show(x.Error, MSG_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }
    }
}
