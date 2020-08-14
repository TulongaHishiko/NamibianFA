using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamibianFA.Domain.Abstract
{
    public enum ErrorMessagesEnum
    {
        EntityNull = 1,
        ModelValidation = 2,
        AuthUserDoesNotExists = 3,
        AuthWrongCredentials = 4,
        AuthCannotCreate = 5,
        AuthCannotDelete = 6,
        AuthCannotUpdate = 7,
        AuthNotValidInformations = 8,
        AuthCannotRetrieveToken = 9
    }
}
