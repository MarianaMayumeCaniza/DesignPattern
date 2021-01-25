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

        
    }
}