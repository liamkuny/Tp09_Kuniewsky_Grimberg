using System;
namespace Tp09_Kuniewsky_Grimberg.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tp09_Kuniewsky_Grimberg.Models;


[ApiController]
[Route("[controller]")]
public class MonumentosController : ControllerBase
{
    [HttpGet]
   public IActionResult Get(){
    List<Monumento> lista = BD.ObtenerMonumentos();
    return Ok(lista);
   }

   [HttpGet("{id}")]
   public IActionResult Get(int id){

    if(id < 1){
        return BadRequest();
    }

    Monumento c = BD.ObtenerMonumento(id);

    if(c == null){
        return NotFound();
    }
    else{
        return Ok(c);
    }

    
   }

    [HttpPost]
    public IActionResult Post(Monumento c){
        if(c.Nombre == "" ||c.Foto == "" || c.Barrio=="" ||c.FechaFundacion >= DateTime.Now ||c.Info== ""|| c.IdCategoria<1){
            return BadRequest();
        }
        
        BD.AgregarMonumento(c.Nombre, c.Foto,c.Barrio,c.FechaFundacion,c.Info,c.IdCategoria);
        return Ok();
    }


   [HttpDelete("{id}")]
   public IActionResult Delete(int id){
    if(id < 1){
        return BadRequest();
    }
    Monumento c = BD.ObtenerMonumento(id);

    if(c == null) {
        return NotFound();
    }

    BD.EliminarMonumento(id);
    return Ok();
   }

   [HttpPut("{id}")]
    public IActionResult Put(int id, Monumento c)
    {
        if (id < 1)
        {
            return BadRequest();
        }
        
        if (BD.ObtenerMonumento(id) == null)
        {
            return NotFound();
        }

        BD.ModificarMonumento(id, c);
        return Ok();
    }
 [HttpPatch("{id}")]
    public IActionResult Patch(int id, Monumento c)
    {
        if (id < 1)
        {
            return BadRequest();
        }
        Monumento M=BD.ObtenerMonumento(id);
        if (M == null)
        {
            return NotFound();
        }
        if (M.Nombre == null)
        {
            c.Nombre = M.Nombre;
        }
        if (c.Foto == null)
        {
            c.Foto = M.Foto;
        }
        if (c.Barrio == null)
        {
            c.Barrio = M.Barrio;
        }
        if (c.FechaFundacion == null)
        {
            c.FechaFundacion = M.FechaFundacion;
        }
        if (c.Info == null)
        {
            c.Info = M.Info;
        }
        
        BD.ModificarMonumento(id, c);
        return Ok();
    }

}