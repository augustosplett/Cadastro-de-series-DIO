using System.Collections.Generic;
using Teste.Interfaces;

namespace Teste
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie entidade)
        {
            throw new System.NotImplementedException();
        }

        public void Exclui(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insere(Serie entidade)
        {
            throw new System.NotImplementedException();
        }

        public List<Serie> Lista()
        {
            throw new System.NotImplementedException();
        }

        public int ProximoId()
        {
            throw new System.NotImplementedException();
        }

        public Serie RetornaPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }

}