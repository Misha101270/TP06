using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06.Models;

namespace TP06.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    

    public IActionResult Privacy()
    {
        return View();
    }
    [HttpPost]
    public IActionResult registrarJugador(Jugador jugador)
    {
        
        BD bd = new BD();
        if(bd.ExisteJugador(jugador.nombreUsuario))
        {
            ViewBag.Mensaje = "El jugador ya existe en la base de datos.";
            return View("Registrarse");
        }
        else
        {
            bd.Registrarse(jugador);
             HttpContext.Session.SetString("Nombre", jugador.nombreUsuario);
            HttpContext.Session.SetString("contraseña", jugador.contraseña);
        }
       
        return RedirectToAction("Login");
    }
    public IActionResult Registrarse()
    {
        return View();
    }
    
    public IActionResult Login(string nombreUsuario, string contraseña)
    {
        BD bd = new BD();
        if(bd.loguearse(nombreUsuario, contraseña) != null)
        {
            if(bd.buscarSalaActual(nombreUsuario, contraseña) == "1")
       {
            return RedirectToAction("Sala1");
       }
        else if(bd.buscarSalaActual(nombreUsuario, contraseña) == "0")
       {
            return RedirectToAction("Sala1");
       }
       else if(bd.buscarSalaActual(nombreUsuario, contraseña) == "2")
       {
            return RedirectToAction("Sala2");
       }
       else if(bd.buscarSalaActual(nombreUsuario, contraseña) == "3")
       {
            return RedirectToAction("Sala3");
       }
       else if(bd.buscarSalaActual(nombreUsuario, contraseña) == "4")
       {
            return RedirectToAction("Sala4");
       }
       else if(bd.buscarSalaActual(nombreUsuario, contraseña) == "5")
       {
            return RedirectToAction("Final");
       }
        } 
            return View();
    }
    //action que guarde la partida en la base de datos y muestre la vista de la sala correspondiente
    public IActionResult Sala1()
    {
        BD bd = new BD();
        bd.GuardarPartida(new Jugador { estado = "En progreso", salaActual = "1", nombreUsuario = HttpContext.Session.GetString("Nombre"), contraseña = HttpContext.Session.GetString("contraseña") });
        return View();
    }
    public IActionResult Sala2(Jugador jugador)
    {
        BD bd = new BD();
        bd.GuardarPartida(new Jugador { estado = "En progreso", salaActual = "2", nombreUsuario = HttpContext.Session.GetString("Nombre"), contraseña = HttpContext.Session.GetString("contraseña") });
        return View();
    }
    public IActionResult Sala3()
    {
        BD bd = new BD();
        bd.GuardarPartida(new Jugador { estado = "En progreso", salaActual = "3", nombreUsuario = HttpContext.Session.GetString("Nombre"), contraseña = HttpContext.Session.GetString("contraseña") });
        return View();
    }
    public IActionResult Sala4()
    {
        BD bd = new BD();
        bd.GuardarPartida(new Jugador { estado = "En progreso", salaActual = "4", nombreUsuario = HttpContext.Session.GetString("Nombre"), contraseña = HttpContext.Session.GetString("contraseña") });
        return View();
    }
    public IActionResult Final()
    {
        BD bd = new BD();
        bd.GuardarPartida(new Jugador { estado = "Finalizada", salaActual = "5", nombreUsuario = HttpContext.Session.GetString("Nombre"), contraseña = HttpContext.Session.GetString("contraseña") });
        return View();
    }

    public IActionResult Logout()
    {
        int? jugadorId = HttpContext.Session.GetInt32("JugadorId");
        int? salaActual = HttpContext.Session.GetInt32("SalaActual");
        
        return RedirectToAction("Index");
    }
    
    
   
}
