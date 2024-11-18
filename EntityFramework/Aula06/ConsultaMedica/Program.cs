using System;

public class Program{

    public static void Main{

        using (var context = new ConsultaContext()){

            var medico1 = new Medico {Nome = 'Roberto', Especialidade = 'Otorrino', CRM = 123456};
            var medico2 = new Medico {Nome = 'Claudio', Especialidade = 'Cabeça-Pescoço', CRM = 234567};
            var medico3 = new Medico {Nome = 'Carla', Especialidade = 'Ginecologista', CRM = 345678};
            var medico4 = new Medico {Nome = 'Eduarda', Especialidade = 'Cardiologista', CRM = 456789};

            context.Medico.AddRange(medico1, medico2, medico3, medico4);

            var paciente1 = new Paciente {Nome = 'Maria', CPF = 123456, DataNascimento = new DateTime(2003/09/22)};
            var paciente2 = new Paciente {Nome = 'João', CPF = 897764, DataNascimento = new DateTime(2006/10/14)};
            var paciente3 = new Paciente {Nome = 'Tais', CPF = 098754, DataNascimento = new DateTime(1989/06/12)};
            var paciente4 = new Paciente {Nome = 'Guilherme', CPF = 213459, DataNascimento = new DateTime(1978/05/30)};

            context.Paciente.AddRange(paciente1, paciente2, paciente3, paciente4);

            var consulta1 = new Consulta(DataConsulta = new DateTime(2024/11/30), MedicoId = medico.MedicoId, PacienteId = paciente.PacienteId);
            var consulta2 = new Consulta(DataConsulta = new DateTime(2024/12/03), MedicoId = medico.MedicoId, PacienteId = paciente.PacienteId);
            var consulta3 = new Consulta(DataConsulta = new DateTime(2024/11/06), MedicoId = medico.MedicoId, PacienteId = paciente.PacienteId);
            var consulta4 = new Consulta(DataConsulta = new DateTime(2024/12/08), MedicoId = medico.MedicoId, PacienteId = paciente.PacienteId);

            context.Consulta.AddRange(consulta1, consulta2, consulta3, consulta4);

            context.SaveChanges();

        }

        Console.WriteLine("Dados inseridos com sucesso!"); 
    }
}