using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Services.Service;
using Services.ServiceImpl;

namespace Services.Util
{
    public class ServiceLocator
    {
        private static ServiceLocator instance;

        public IEmpresaService EmpresaService { get; set; }
        public IParametroService ParametroService { get; set; }
        public IRolService RolService { get; set; }
        public IRegistracionService RegistracionService { get; set; }
        public ISalaService SalaService { get; set; }
        public ITurnoService TurnoService { get; set; }
        public IUsuarioService UsuarioService { get; set; }

        private ServiceLocator()
        {
            this.EmpresaService = new EmpresaService();
            this.ParametroService = new ParametroService();
            this.RegistracionService = new RegistracionService();
            this.RolService = new RolService();
            this.SalaService = new SalaService();
            this.TurnoService = new TurnoService();
            this.UsuarioService = new UsuarioService();
        }

        public static ServiceLocator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceLocator();
                }
                return instance;
            }
        }



    }
}
