using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class Middlewares{

    private readonly RequestDelegate _next;

   
    public Middlewares(RequestDelegate _next){
        this._next = _next;
    }

   public async Task Invoke(HttpContext context){
        await context.Response.WriteAsync("{nameof(FirstMiddleware)} in. \r\n");
        await _next(context);
        await context.Response.WriteAsync("{nameof(FirstMiddleware)} out. \r\n");
    }
}