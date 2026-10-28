using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LoginAvalonia.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private bool _isLoggedIn = false;
    
    [ObservableProperty]
    private string _greeting = "Benvenuto! Effettua l'accesso.";
    
    [ObservableProperty]
    private string _username = string.Empty;
    
    [ObservableProperty]
    private string _buttonText = "LOGIN";
    
    [RelayCommand]
    private void ExecuteLogin()
    {
        if (!_isLoggedIn)
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                Greeting = "Per favore, inserisci un nome!";
                return;
            }

            Greeting = $"Benvenuto/a {Username}";
            ButtonText = "LOGOUT";
            _isLoggedIn = true;
        }
        else
        {
            Greeting = "Arrivederci!";
            Username = string.Empty; 
            ButtonText = "LOGIN";
            _isLoggedIn = false;
        }
    }
}