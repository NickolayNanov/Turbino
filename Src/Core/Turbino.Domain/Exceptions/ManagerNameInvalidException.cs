namespace Turbino.Domain.Exceptions
{
    using System;
    using Turbino.Common.GlobalContants;

    public class ManagerNameInvalidException : Exception
    {
        public ManagerNameInvalidException(Exception ex)
            : base(DomainContants.ManagerExceptionMessage, ex)
        {
        }
    }
}
