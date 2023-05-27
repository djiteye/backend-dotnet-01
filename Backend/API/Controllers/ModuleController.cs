using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Service.DTO;
using Service.IService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using API.Models;
using Core.Entities;

namespace API.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("Role")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _service;
        private readonly ILogger _logger;

        public ModuleController(IModuleService service, ILogger logger)
        {
            _service = service;
            _logger = logger;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="Suportid"></param>
        /// <returns></returns>
        [Route("GetModule")]
        [HttpGet]
        public async Task<ActionResult<ModuleDto>> GetModule(int Moduleid)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                var mod = await _service.GetModule(Moduleid).ConfigureAwait(false);

                if (mod != null)
                {
                    return new OkObjectResult(mod);
                }
                else
                {
                    var showmessage = "module inexistant";
                    dict.Add("Message", showmessage);
                    return NotFound(dict);

                }

            }
            catch (Exception ex)
            {
                _logger.Error("Erreur GetModule <==> " + ex.ToString());
                var showmessage = "Erreur" + ex.Message;
                dict.Add("Message", showmessage);
                return BadRequest(dict);
            }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        /* [Route("GetAllRole")]
         [HttpGet]
         public async Task<ActionResult<List<RoleDto>>> GetRoles()
         {
             Dictionary<string, string> dict = new Dictionary<string, string>();
             try
             {
                 var lst = await _service.GetAllRoles();
                 var lstUsr = lst.ToList();

                 if (lstUsr.Count != 0)
                 {
                     return new OkObjectResult(lstUsr);
                 }
                 else
                 {
                     var showmessage = "Pas d'element dans la liste";
                     dict.Add("Message", showmessage);
                     return NotFound(dict);

                 }

             }
             catch (Exception ex)
             {

                 _logger.Error("Erreur GetUsers <==> " + ex.ToString());
                 var showmessage = "Erreur" + ex.Message;
                 dict.Add("Message", showmessage);
                 return BadRequest(dict);
             }
         }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="usr"></param>
         /// <returns></returns>
         [Route("IsLogin")]
         [HttpPost]
         public async Task<ActionResult<UserDto>> IsLogin(Login usr)
         {
             Dictionary<string, string> dict = new Dictionary<string, string>();
             try
             {
                 var userLog = await _service.IsLogin(usr.Username, usr.Pswd).ConfigureAwait(false);
                 if (userLog != null)
                 {
                     return new OkObjectResult(userLog);

                 }
                 else
                 {
                     var showmessage = "Mot de passe ou username invalid";
                     dict.Add("Message", showmessage);
                     return BadRequest(dict);
                 }

             }
             catch (Exception ex)
             {

                 _logger.Error("Erreur IsLogin <==> " + ex.ToString());
                 var showmessage = "Erreur" + ex.Message;
                 dict.Add("Message", showmessage);
                 return BadRequest(dict);
             }
         }*/



        /// <summary>
        /// Ajout du Module.
        /// </summary>
        /// <param name="Module">Le Module.</param>
        /// <returns></returns>
        [Route("AddModule")]
        [HttpPost]
        public async Task<ActionResult> AjoutModule(ModuleDto Module)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                var ajt = await _service.AddModule(Module).ConfigureAwait(false);
                if (ajt)
                {
                    var showmessage = "Module Inseré avec succes";
                    dict.Add("Message", showmessage);
                    return Ok(dict);

                }
                else
                {
                    var showmessage = "Echec d'insertion... Reprendre l'operation";
                    dict.Add("Message", showmessage);
                    return BadRequest(dict);
                }

            }
            catch (Exception ex)
            {

                _logger.Error("Erreur AjoutRole <==> " + ex.ToString());
                var showmessage = "Erreur" + ex.Message;
                dict.Add("Message", showmessage);
                return BadRequest(dict);
            }
        }


        /// <summary>
        /// Modifs the User.
        /// </summary>
        /// <param name="Module">The Module.</param>
        /// <returns></returns>
        [Route("UpdModule")]
        [HttpPut]
        public async Task<ActionResult> ModifModule(ModuleDto Module)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                var upd = await _service.AddModule(Module).ConfigureAwait(false);
                if (upd)
                {
                    var showmessage = "Module Modifié avec succes";
                    dict.Add("Message", showmessage);
                    return Ok(dict);

                }
                else
                {
                    var showmessage = "Echec de modification... Reprendre l'operation";
                    dict.Add("Message", showmessage);
                    return BadRequest(dict);

                }

            }
            catch (Exception ex)
            {

                _logger.Error("Erreur ModifModule <==> " + ex.ToString());
                var showmessage = "Erreur" + ex.Message;
                dict.Add("Message", showmessage);
                return BadRequest(dict);
            }
        }
        /// <summary>
        /// Suppression du User.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [Route("DelModule")]
        [HttpDelete]
        public async Task<ActionResult> DeletModule(int Suportid)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                var del = await _service.DelModule(Suportid).ConfigureAwait(false);

                if (del)
                {
                    var showmessage = "Role supprimé avec succes";
                    dict.Add("Message", showmessage);
                    return Ok(dict);
                }


                else
                {
                    var showmessage = "Erreur lors de la suppression...Svp reprendre l'operation";
                    dict.Add("Message", showmessage);
                    return BadRequest(dict);
                }

            }
            catch (Exception ex)
            {

                _logger.Error("Erreur DeletModule <==> " + ex.ToString());
                var showmessage = "Erreur" + ex.Message;
                dict.Add("Message", showmessage);
                return BadRequest(dict);
            }
        }



    }
}


