using GameManager.Model;
using Microsoft.Extensions.Options;
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

namespace GameManager.View.UserControl;

    /// <summary>
    /// Interaction logic for MembersView.xaml
    /// </summary>
    public partial class MembersView
    {
        public MembersView()
        {
            InitializeComponent();

        //Loaded += MembersView_Loaded;
    }

    /*
    private async void MembersView_Loaded(object sender, RoutedEventArgs e)
    {

        using var db = new ManagerContext();

        var members = db.Members.ToList();


        MemberDataGrid.ItemsSource = members;

    }*/
}

