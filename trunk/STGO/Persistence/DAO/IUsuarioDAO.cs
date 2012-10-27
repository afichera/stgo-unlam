using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Persistence.DAO
{
    public interface IUsuarioDAO
    {
        
        Usuario getFindByEmail(String email);

        long login(String email, String password);
    }
}
