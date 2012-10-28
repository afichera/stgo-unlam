using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Persistence.DAO
{
    public interface IUsuarioDAO:ICommonDAO<Usuario>
    {
        
        Usuario getFindByEmail(String email);

        long login(String email, String password);
    }
}
