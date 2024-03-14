namespace LifeLinkAPI.Domain.Exceptions;

public class MedicalRecordNotFoundException : Exception
{
    public MedicalRecordNotFoundException()
    {
    }

    public MedicalRecordNotFoundException(string message) 
        : base(message)
    {
    }
    
    public MedicalRecordNotFoundException(string message, Exception inner) 
        : base(message, inner)
    {
    }
}