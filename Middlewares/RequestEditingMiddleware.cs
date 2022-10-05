namespace AspNetCoreApp.Middewares
{
  public class RequestEditingMiddleware
  {
    private RequestDelegate _requestDelegate;
    public RequestEditingMiddleware(RequestDelegate requestDelegate)
    {
      _requestDelegate = requestDelegate;
    }
    public async Task Invoke(HttpContext context){
      if (context.Request.Path.ToString() == "/yavuz")
        await context.Response.WriteAsync("hosgeldin yavuz");
      else
        await _requestDelegate.Invoke(context);
    }

  }
}