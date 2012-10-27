using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Services.Service
{
    public interface IUsuarioService
    {
        long login(String email, String password);

        Usuario getFindByEmail(String email);
    }
}
