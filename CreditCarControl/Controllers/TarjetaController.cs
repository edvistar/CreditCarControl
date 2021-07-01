using CreditCarControl.Models;
using CreditCarControl.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CreditCarControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
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
                    var lst = db.Tarjeta.OrderByDescending(d => d.Id).ToList();
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
        public IActionResult Add(Tarjeta oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (CreditCardControlContext db = new CreditCardControlContext())
                {
                    Tarjeta oTarjeta = new Tarjeta();
                    oTarjeta.NumeroTarjeta = oModel.NumeroTarjeta;
                    oTarjeta.CupoDisponible = oModel.CupoDisponible;
                    oTarjeta.CupoAvance = oModel.CupoAvance;
                    oTarjeta.FechaCorte = oModel.FechaCorte;
                    oTarjeta.FechaCobro = oModel.FechaCobro;
                    oTarjeta.IdCompra = oModel.IdCompra;
                    oTarjeta.IdPago = oModel.IdPago;

                    db.Tarjeta.Add(oTarjeta);
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
        public IActionResult Edit(Tarjeta oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (CreditCardControlContext db = new CreditCardControlContext())
                {
                    Tarjeta oTarjeta = db.Tarjeta.Find(oModel.Id);
                    oTarjeta.NumeroTarjeta = oModel.NumeroTarjeta;
                    oTarjeta.CupoDisponible = oModel.CupoDisponible;
                    oTarjeta.CupoAvance = oModel.CupoAvance;
                    oTarjeta.FechaCorte = oModel.FechaCorte;
                    oTarjeta.FechaCobro = oModel.FechaCobro;
                    oTarjeta.IdCompra = oModel.IdCompra;
                    oTarjeta.IdPago = oModel.IdPago;
                    db.Entry(oTarjeta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Tarjeta oTarjeta = db.Tarjeta.Find(Id);
                    db.Remove(oTarjeta);
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
