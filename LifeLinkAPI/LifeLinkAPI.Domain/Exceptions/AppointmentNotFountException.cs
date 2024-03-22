namespace LifeLinkAPI.Domain.Exceptions;

public class AppointmentNotFountException : Exception
{
    public AppointmentNotFountException()
    {
    }

    public AppointmentNotFountException(string message) 
        : base(message)
    {
    }
    
    public AppointmentNotFountException(string message, Exception inner) 
        : base(message, inner)
    {
    }
}