using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.DAO
{
    public interface IBaseDAO
    {
        bool conectar();

        String cadenaConexion();

        void comenzarTransaccion();

        void finalizarTransaccion();

        void cancelarTransaccion();



    }
}
