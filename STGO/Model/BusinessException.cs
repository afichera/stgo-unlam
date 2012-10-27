using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class BusinessException : Exception
    {
        public BusinessException(String msgError)
            : base(msgError)
        {

        }
    }
}
