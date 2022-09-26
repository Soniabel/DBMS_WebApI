﻿namespace DBMS_WebApI.Infrastructure
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception exception) : base(message, exception)
        {
        }

        public NotFoundException(string name, object id) : base($"Entity {name} ({id}) was not found!")
        {
        }
    }
}
