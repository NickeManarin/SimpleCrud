namespace SimpleCrud.Application.Interfaces
{
    public interface IResponse
    {
        int Status { get; set; }

        int Code { get; set; }
    }
}