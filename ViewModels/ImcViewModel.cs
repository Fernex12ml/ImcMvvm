using System;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using ImcMvvm.Models;

namespace ImcMvvm.ViewModels;

public class ImcViewModel : INotifyPropertyChanged
{
    public string PesoTexto { get; set; } = "";
    public string EstaturaTexto { get; set; } = "";

    private string resultado = "Ingresa tus datos.";
    public string Resultado
    {
        get { return resultado; }
        set
        {
            if (resultado != value)
            {
                resultado = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Resultado)));
            }
        }
    }

    public ICommand CalcularCommand { get; }

    public ImcViewModel()
    {
        CalcularCommand = new Command(Calcular);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void Calcular()
    {
        double peso;
        bool pesoValido = double.TryParse(PesoTexto, out peso);
        if (pesoValido == false || !double.IsFinite(peso) || peso <= 0)
        {
            Resultado = "Escribe un peso válido mayor que cero.";
            return;         }

        double estatura;
        bool estaturaValida = double.TryParse(EstaturaTexto, out estatura);
        if (estaturaValida == false || !double.IsFinite(estatura) || estatura <= 0)
        {
            Resultado = "Escribe una estatura válida en metros.";
            return;
        }

        Persona persona = new Persona();
        persona.Peso = peso;
        persona.Estatura = estatura;

        double imc = persona.CalcularImc();

        if (!double.IsFinite(imc))
        {
            Resultado = "Revisa el peso y la estatura.";
            return;
        }

        Resultado = "Tu IMC es: " + imc.ToString("F2");
    }
}
