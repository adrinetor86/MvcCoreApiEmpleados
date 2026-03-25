using Microsoft.AspNetCore.Mvc;
using MvcCoreApiEmpleados.Services;
using NugetApiModels.Models;

namespace MvcCoreApiEmpleados.Controllers;

public class EmpleadosController : Controller
{
    private ServiceEmpleados _serviceEmpleados;

    public EmpleadosController(ServiceEmpleados service)
    {
        _serviceEmpleados = service;
    }
    
    
    public async Task<IActionResult> Index()
    {
        List<string> oficios = await _serviceEmpleados.GetOficiosAsync();
        List<Empleado> empleados= await _serviceEmpleados.GetEmpleadosAsync();
        ViewData["OFICIOS"] = oficios;
        return View(empleados);
    }
}