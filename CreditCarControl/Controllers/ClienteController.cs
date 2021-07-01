using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using CreditCarControl.Models;
using CreditCarControl.Models.Response;
using CreditCarControl.Models.Request;

namespace CreditCarControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            try
            {

                using (CreditCardControlContext db = new CreditCardControlContext())
                {
                    var lst = db.Cliente.OrderByDescending(d =>d.Id).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;

                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (CreditCardControlContext db = new CreditCardControlContext())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Nombre = oModel.Nombre;
                    oCliente.Documento = oModel.Documento;
                    oCliente.IdTarjeta = oModel.IdTarjeta;
                    db.Cliente.Add(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (CreditCardControlContext db = new CreditCardControlContext())
                {
                    Cliente oCliente = db.Cliente.Find(oModel.Id);
                    oCliente.Nombre = oModel.Nombre;
                    oCliente.Documento = oModel.Documento;
                    oCliente.IdTarjeta = oModel.IdTarjeta;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (CreditCardControlContext db = new CreditCardControlContext())
                {
                    Cliente oCliente = db.Cliente.Find(Id);
                    db.Remove(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
