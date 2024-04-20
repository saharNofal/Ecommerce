using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Exceptions
{
    public class NotSoundException:Exception
    {
        public NotSoundException(string name, object key):base($"{name} {key} is not found")
        {

        }
    }
}
