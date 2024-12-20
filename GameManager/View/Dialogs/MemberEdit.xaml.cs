
using GameManager.ViewModel;
using System.Windows;
using System.Windows.Input;




namespace GameManager.View.Dialogs;

public partial class MemberEdit : Window
{
   

    public MemberEdit(MembersViewModel membersViewModel)
    {


        InitializeComponent();

        DataContext = membersViewModel;

        
    }

    
    private void MoveWindow(object sender, MouseButtonEventArgs e)
    {
        if (e.ButtonState == MouseButtonState.Pressed)
        {
            this.DragMove();
        }
    }

    private void Button_Exit(object sender, RoutedEventArgs e)
    {

        this.Close();

    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}
