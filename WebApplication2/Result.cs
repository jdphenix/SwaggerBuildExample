namespace WebApplication2
{ 
    public record Result<T>(T? Value, ProblemDetails? Error);
}