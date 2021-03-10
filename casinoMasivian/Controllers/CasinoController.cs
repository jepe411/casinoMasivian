using casinoMasivian.DATA;
using casinoMasivian.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
namespace casinoMasivian.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CasinoController : ControllerBase
    {  
        [HttpPost("createRoulette")]
        public ActionResult CreateRoulette()
        {
            try
            {
                DataRoulette data = new DataRoulette();
                int a = data.getRoulette().Count() + 1;
                DTO.Roulette roulette = new DTO.Roulette { Id = a };
                data.Create(roulette);
                return Ok(roulette.Id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("OpenRoulette/{id}")]     
        public ActionResult OpenRoulette(int id)
        {
            try
            {
                DataRoulette data = new DataRoulette();
                DTO.Roulette roulette = data.getRouletteById(id);
                if (roulette == null)
                {
                    return Ok("La ruleta no existe");
                }
                else if (roulette.isOpen)
                {
                    return Ok("La ruleta ya está abierta");
                }
                else
                {
                    roulette.isOpen = true;
                    data.updateRouletteState(roulette);
                    return Ok("La ruleta " + id + " se ha abierto");
                }
            }
            catch (Exception e)           
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("closeRoulette/{id}")]
        public  ActionResult<List<Bet>> closeRoulette(int id)
        {
            try
            {
                DataBet data = new DataBet();
                DataRoulette dataRoulett = new DataRoulette();
                data.closeBet(id);
                Roulette roulette = new Roulette();
                roulette = dataRoulett.getRouletteById(id);
                roulette.isOpen = false;
                dataRoulett.updateRouletteState(roulette);
                List<Bet> returnList = (List<Bet>)data.getBets();
                return (returnList); 
            }
            catch (Exception e)
            {
                return (List<Bet>)null;
            }

        }
        [HttpGet("getRoulettes")]
        public ActionResult<List<Roulette>> getRoulettes()
        {
            try
            {
                DataRoulette dataRoulett = new DataRoulette();               
                List<Roulette> returnList = (List<Roulette>)dataRoulett.getRoulette();
                return (returnList);
            }
            catch (Exception e)
            {
                return (List<Roulette>)null;
            }

        }
        [HttpPost("createBet")]
        public IActionResult CreateBet(Bet bet, [FromHeader(Name = "userId")] string UserId)
        {
            try
            {
                bet.userId = Convert.ToInt32(UserId);
                String message = validations(bet);
                if (message !="")                
                    return Ok(message);                            
                else
                {
                    DataBet data = new DataBet();
                    data.Create(bet);
                    return Ok("Apuesta creada exitosamente");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        private string validations(Bet bet)
        {           
            bool color = validateColor(bet);
            bool number = validateNumber(bet);
            bool intervalNumber = validateintervalNumber(bet);
            bool maxBet = validateMaxBet(bet);
            bool rouletteIsOpen = validateRouletteIsOpen(bet);
            bool user = validateUser(bet.userId);
            bool userAmount = validateUserAmount(bet);
            if (!user)
                return "El usuario no existe";
            else if (!userAmount)
                return "No tiene el dinero necesario para apostar";
            else if (color && number)
                return "Solo se puede apostar a color o a número";
            else if (!color && !number)
                return "Debe ingresar un color o un número";
            else if (!intervalNumber && !color)
                return "Debe ingresar un número entre 0 y 36";
            else if (!maxBet)
                return "Debe apostar un valor entre 1 y 10.000 USD";
            else if (!rouletteIsOpen)
                return "La ruleta no existe o está cerrada";
            else
                return "";
        }
        private bool validateUserAmount(Bet bet)
        {
            DataUser data = new DataUser();
            User userObj = data.getUserById(bet.userId);
            if (userObj != null)
            {
                if (bet.amount <= userObj.amount)
                    return true;
                return false;
            }
            return false;
        }
        private bool validateUser(int user)
        {
            DataUser data = new DataUser();
            User userObj= data.getUserById(user);
            if (userObj != null)
                return true;
            return false;
        }
        private bool validateRouletteIsOpen(Bet bet)
        {
            DataRoulette data = new DataRoulette();
            DTO.Roulette roulette = data.getRouletteById(bet.IdRoulette);
            if (roulette != null)
            {
                if (roulette.isOpen)
                    return true;
                return false;
            }
            else
            {
                return false;
            }
        }
        private bool validateMaxBet(Bet bet)
        {
            if (bet.amount > 0 && bet.amount <= 10000)
               return true;
           return false;
        }
        private bool validateintervalNumber(Bet bet)
        {
            if (bet.number <= 36 && bet.number >= 0)
                return true;
            return false;
        }
        private bool validateColor(Bet bet)
        {
            if (bet.color == null)
                return false;
            return true;
        }
        private bool validateNumber(Bet bet)
        {
            if (bet.number == null)
                return false;
            return true;
        }
    }
}
