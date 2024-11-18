public class Consulta{

    public int ConsultaId {get; set;}
    public DateTime DataConsulta {get; set;}
    public int MedicoId {get; set;}
    public int PacienteId {get; set;}
    public Medico Medico { get; set; } = null!; // Propriedade de navegação
    public Paciente Paciente { get; set; } = null!; // Propriedade de navegação

}