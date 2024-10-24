using System;
using System.Drawing;

public class CirculoColoridoPreenchido : CirculoColorido
{
    // Nova propriedade para armazenar a cor de preenchimento
    public Color CorPreenchimento { get; set; }

    // Construtor padrão com cor preta e preenchimento branco
    public CirculoColoridoPreenchido() : base()
    {
        CorPreenchimento = Color.White;
    }

    // Construtor que aceita coordenadas, raio, cor de borda e cor de preenchimento
    public CirculoColoridoPreenchido(double x, double y, double r, string corBorda, Color corPreenchimento)
        : base(x, y, r, corBorda)
    {
        CorPreenchimento = corPreenchimento;
    }

    // Sobrescrevendo o método ToString para incluir a cor de preenchimento
    public override string ToString()
    {
        return base.ToString() + $" preenchimento={CorPreenchimento.Name}";
    }
}