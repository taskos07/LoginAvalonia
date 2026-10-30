using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LoginAvalonia.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private bool _utenteAutenticato;

    [ObservableProperty] private string _messaggioBenvenuto = "Effettua l'accesso.";
    [ObservableProperty] private string _nomeUtente = string.Empty;
    [ObservableProperty] private string _testoPulsante = "ACCEDI";
    

    [RelayCommand]
    private void EseguiLogin()
    {
        if (!_utenteAutenticato)
        {
            if (string.IsNullOrWhiteSpace(NomeUtente))
            {
                MessaggioBenvenuto = "Inserisci un nome";
                return;
            }

            MessaggioBenvenuto = $"Benvenuto/a, {NomeUtente}!";
            TestoPulsante = "ESCI";
            _utenteAutenticato = true;
        }
        else
        {
            MessaggioBenvenuto = "Arrivederci";
            NomeUtente = string.Empty; 
            TestoPulsante = "ACCEDI";
            _utenteAutenticato = false;
        }
    }
    public MainViewModel()
    {
        InitializeComponent();
        Nomi.ItemsSource = new string[]
                {"Nome1", "Nome2"}
            .OrderBy(x => x);
    }
}