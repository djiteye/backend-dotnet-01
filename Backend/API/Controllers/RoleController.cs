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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;
        private readonly ILogger _logger;

        public RoleController(IRoleService service, ILogger logger)
        {
            _service = service;
            _logger = logger;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="Suportid"></param>
        /// <returns></returns>
        [Route("GetRole")]
        [HttpGet]
        public async Task<ActionResult<RoleDto>> GetUser(int Roleid)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                var Rol = await _service.GetRole(Roleid).ConfigureAwait(false);

                if (Rol != null)
                {
                    return new OkObjectResult(Rol);
                }
                else
                {
                    var showmessage = "Role inexistant";
                    dict.Add("Message", showmessage);
                    return NotFound(dict);

                }

            }
            catch (Exception ex)
            {
                _logger.Error("Erreur GetRole <==> " + ex.ToString());
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
        /// Ajout du User.
        /// </summary>
        /// <param name="Role">Le Role.</param>
        /// <returns></returns>
        [Route("AddRole")]
        [HttpPost]
        public async Task<ActionResult> AjoutRole(RoleDto Role)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                var ajt = await _service.AddRole(Role).ConfigureAwait(false);
                if (ajt)
                {
                    var showmessage = "Role Inseré avec succes";
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
        /// <param name="User">The User.</param>
        /// <returns></returns>
        [Route("UpdRole")]
        [HttpPut]
        public async Task<ActionResult> ModifUser(RoleDto Role)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                var upd = await _service.UpdRole(Role).ConfigureAwait(false);
                if (upd)
                {
                    var showmessage = "Role Modifié avec succes";
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

                _logger.Error("Erreur ModifRole <==> " + ex.ToString());
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
        [Route("DelRole")]
        [HttpDelete]
        public async Task<ActionResult> DeletRole(int Suportid)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                var del = await _service.DelRole(Suportid).ConfigureAwait(false);

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

                _logger.Error("Erreur DeletRole <==> " + ex.ToString());
                var showmessage = "Erreur" + ex.Message;
                dict.Add("Message", showmessage);
                return BadRequest(dict);
            }
        }



    }
}

