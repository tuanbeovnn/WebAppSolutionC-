namespace IntegrationDtos;

public class Response
{
    public virtual bool Success { get; set; }
    public string Message { get; set; }

    public Response()
    {
        
    }
    public Response(bool success)
    {
        this.Success = success;
    }
}
public class Response<T>:Response
{
    public virtual bool Success { get; set; }
    public string Message { get; set; }

    public Response()
    {
        
    }
    public Response(bool success)
    {
        this.Success = success;
    }
}


public class SuccessResponse<T> : Response<T>
{
    public override bool Success => base.Success;

    public SuccessResponse() : base(true)
    {
    }

    public T Data { get; set; }
}