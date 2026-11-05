namespace ImcMvvm.Models;

public class Persona
{
    public double Peso { get; set; }
    public double Estatura { get; set; }

    public double CalcularImc()
    {
        return Peso / (Estatura * Estatura);
    }
}
