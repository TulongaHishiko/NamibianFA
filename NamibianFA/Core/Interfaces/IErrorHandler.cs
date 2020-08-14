using CenoredIMS.Domain.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenoredIMS.Core.Interfaces
{
    public interface IErrorHandler
    {
        string GetMessage(ErrorMessagesEnum message);
        string ErrorIdentityResult(IdentityResult result);
    }
}
