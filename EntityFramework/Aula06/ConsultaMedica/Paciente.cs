public class Paciente{

    public int PacienteId {get; set;}

    public string Nome { get; set; } = null!;

    public int CPF { get; set; }

    public DateTime DataNascimento { get; set; } 
    public List<Consulta> Consultas { get; set; } = new List<Consulta>();

}