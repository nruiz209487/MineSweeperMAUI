using Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

public class ManejadoraColumnas : INotifyPropertyChanged
{
    private ObservableCollection<ObservableCollection<Casilla>> _columnas = new();

    public ObservableCollection<ObservableCollection<Casilla>> Columnas
    {
        get => _columnas;
        set
        {
            if (_columnas != value)
            {
                _columnas = value;
                OnPropertyChanged(nameof(Columnas));
            }
        }
    }
    /// <summary>
    /// Actualiza los listados de columnas
    /// </summary>
    /// <param name="indice"></param>
    /// <param name="minas"></param>
    public void ActualizarColumna(int indice, List<Casilla> minas)
    {
        while (_columnas.Count <= indice)
        {
            _columnas.Add(new ObservableCollection<Casilla>());
        }

        ObservableCollection<Casilla> columna = _columnas[indice];
        columna.Clear();

        foreach (Casilla x in minas)
        {
            columna.Add(x);
        }

        OnPropertyChanged(nameof(Columnas));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
