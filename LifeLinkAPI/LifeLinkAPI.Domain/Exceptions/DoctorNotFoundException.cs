namespace LifeLinkAPI.Domain.Exceptions;

public class DoctorNotFoundException : Exception
{
    public DoctorNotFoundException()
    {
    }

    public DoctorNotFoundException(string message) 
        : base(message)
    {
    }
    
    public DoctorNotFoundException(string message, Exception inner) 
        : base(message, inner)
    {
    }
}