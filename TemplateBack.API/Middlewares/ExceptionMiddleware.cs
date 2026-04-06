/* Global error handler — catches all unhandled exceptions, returns clean JSON */

using System.Net;
using System.Text.Json;
namespace TemplateBack.TemplateBack.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate m_Next;
    private readonly ILogger<ExceptionMiddleware> m_Logger;

    public ExceptionMiddleware(RequestDelegate p_Next, ILogger<ExceptionMiddleware> p_Logger)
    {
        m_Next = p_Next;
        m_Logger = p_Logger;
    }

    public async Task InvokeAsync(HttpContext p_Context)
    {
        try
        {
            await m_Next(p_Context);
        }
        catch (KeyNotFoundException v_Ex)
        {
            await HandleExceptionAsync(p_Context, v_Ex, HttpStatusCode.NotFound);
        }
        catch (ArgumentException v_Ex)
        {
            await HandleExceptionAsync(p_Context, v_Ex, HttpStatusCode.BadRequest);
        }
        catch (Exception v_Ex)
        {
            m_Logger.LogError(v_Ex, "Unhandled exception");
            await HandleExceptionAsync(p_Context, v_Ex, HttpStatusCode.InternalServerError);
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext p_Context,
        Exception p_Exception,
        HttpStatusCode p_StatusCode)
    {
        p_Context.Response.ContentType = "application/json";
        p_Context.Response.StatusCode = (int)p_StatusCode;

        await p_Context.Response.WriteAsync(JsonSerializer.Serialize(new
        {
            statusCode = (int)p_StatusCode,
            message    = p_Exception.Message
        }));
    }
}
