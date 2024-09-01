using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ExternalServices
{
    public interface ISmtp
    {
        public Task<bool> EnviarEmailAsync(string para, string assunto, string mensagem);

    }
}
