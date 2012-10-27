using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence.DAO;
using Persistence.DAOImpl;

namespace Persistence.Util
{
    public class DAOLocator
    {
        private static DAOLocator instance;

        public IEmpresaDAO EmpresaDAO { get; set; }
        public IParametroDAO ParametroDAO { get; set; }
        public IRegistracionDAO RegistracionDAO { get; set; }
        public IRolDAO RolDAO { get; set; }
        public ISalaDAO SalaDAO { get; set; }
        public ITurnoDAO TurnoDAO { get; set; }
        public IUsuarioDAO UsuarioDAO { get; set; }

        private DAOLocator()
        {
            this.EmpresaDAO = new EmpresaDAO();
            this.ParametroDAO = new ParametroDAO();
            this.RegistracionDAO = new RegistracionDAO();
            this.RolDAO = new RolDAO();
            this.SalaDAO = new SalaDAO();
            this.TurnoDAO = new TurnoDAO();
            this.UsuarioDAO = new UsuarioDAO();
        }

        public static DAOLocator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAOLocator();
                }
                return instance;
            }
        }
    }
}
