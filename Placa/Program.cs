using DesignPatternSamples.Application.Repository;
using System;
using System.Collections.Generic;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public class DetranVerificadorDebitosFactory : IDetranVerificadorDebitosFactory
    {
        private readonly IServiceProvider _ServiceProvider;
        private readonly IDictionary<string, Type> _Repositories = new Dictionary<string, Type>();

        public DetranVerificadorDebitosFactory(IServiceProvider serviceProvider)
        {
            _ServiceProvider = serviceProvider;
        }

        public IDetranVerificadorDebitosRepository Create(string placa)
        {
            IDetranVerificadorDebitosRepository result = null;

            if (_Repositories.TryGetValue(placa, out Type type))
            {
                result = _ServiceProvider.GetService(type) as IDetranVerificadorDebitosRepository;
            }

            return result;
        }
        private readonly ILogger _Logger;

        public IDetranVerificadorDebitosRepository(ILogger<IDetranVerificadorDebitosRepository> logger)
        {
            _Logger = logger;
        }

        public Task<IEnumerable<DebitoVeiculo>> ConsultarDebitos(Veiculo veiculo)
        {
            _Logger.LogDebug($"Consultando débitos do veículo placa {veiculo.Placa} para o estado de SP.");
            return Task.FromResult<IEnumerable<DebitoVeiculo>>(new List<DebitoVeiculo>() { new DebitoVeiculo() });
        }

        
    }
}