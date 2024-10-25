using _01_mvcCEP.Models;
using System.Collections.Concurrent;
namespace _01_mvcCEP.Services;

public class CEPMemoryService : ICEPServices
{
    private readonly ConcurrentDictionary<string, CEPViewModel> listaDeCEPs = new ConcurrentDictionary<string, CEPViewModel>();
    CEPViewModel? ICEPServices.buscaCEPs(string cep)
    {
        CEPViewModel? searchresult;
       listaDeCEPs.TryGetValue(cep, out searchresult);
       return searchresult;
    }

    void ICEPServices.cadastraCEPS(CEPViewModel p)
    {
        listaDeCEPs.TryAdd(p.CEP, p);
    }

    IEnumerable<CEPViewModel> ICEPServices.listaCEPs()
    {
        return listaDeCEPs.Values;
    }

    public CEPMemoryService(){
        CEPViewModel aux =new CEPViewModel{
                CEP= " 91910290",
                Bairro= "Camaqua",
                Cidade="Porto Alegre",
                UF= "RS",
                Logradouro="Rua Marechal Hermes, 55"
            };
        listaDeCEPs.TryAdd(aux.CEP, aux);

        aux =new CEPViewModel{
                CEP= " 90050240",
                Bairro= "Tristeza",
                Cidade="Porto Alegre",
                UF= "RJ",
                Logradouro="Rua Dinarte Campao, 44"
            };
        listaDeCEPs.TryAdd(aux.CEP, aux);

        aux =new CEPViewModel{
                CEP= " 91298348",
                Bairro= "Copacabana",
                Cidade="São Paulo",
                UF= "SP",
                Logradouro="Rua Bonita,1234"
            };
        listaDeCEPs.TryAdd(aux.CEP, aux);
      
    }
}