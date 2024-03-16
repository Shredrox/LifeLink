namespace LifeLinkAPI.Domain.Exceptions;

public class LabTestNotFoundException : Exception
{
    public LabTestNotFoundException()
    {
    }

    public LabTestNotFoundException(string message) 
        : base(message)
    {
    }
    
    public LabTestNotFoundException(string message, Exception inner) 
        : base(message, inner)
    {
    }
}