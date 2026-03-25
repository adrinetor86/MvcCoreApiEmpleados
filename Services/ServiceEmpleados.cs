using System.Net.Http.Headers;
using NugetApiModels.Models;

namespace MvcCoreApiEmpleados.Services;

public class ServiceEmpleados
{
    private string _ApiUrl;

    private MediaTypeWithQualityHeaderValue _header;

    public ServiceEmpleados(IConfiguration configuration)
    {
        _ApiUrl = configuration.GetValue<string>("ApiUrls:ApiEmpleados");
        _header = new MediaTypeWithQualityHeaderValue("application/json");
    }
    public async Task<List<Empleado>> GetEmpleadosAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            string request = "api/Empleados";
            client.BaseAddress = new Uri(_ApiUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(_header);
            HttpResponseMessage response= await client.GetAsync(request);

            if (response.IsSuccessStatusCode == true)
            {
                List<Empleado> data= await response.Content.ReadAsAsync<List<Empleado>>();
                return data;
            }
            else
            {
                return null;
            }
        }
    }     
    
    public async Task<List<Empleado>> GetEmpleadosOficioAsync(string oficio)
    {
        using (HttpClient client = new HttpClient())
        {
            string request = "/api/Empleados/EmpleadosByOficio/"+oficio;
            client.BaseAddress = new Uri(_ApiUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(_header);
            HttpResponseMessage response= await client.GetAsync(request);

            if (response.IsSuccessStatusCode == true)
            {
                List<Empleado> data= await response.Content.ReadAsAsync<List<Empleado>>();
                return data;
            }
            else
            {
                return null;
            }
        }
    }  
    
    public async Task<List<string>> GetOficiosAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            string request = "api/Empleados/Oficios";
            client.BaseAddress = new Uri(_ApiUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(_header);
            HttpResponseMessage response= await client.GetAsync(request);

            if (response.IsSuccessStatusCode == true)
            {
                List<string> data= await response.Content.ReadAsAsync<List<string>>();
                return data;
            }
            else
            {
                return null;
            }
        }
    }

    
    
}