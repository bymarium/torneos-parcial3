﻿using System;
using System.Linq;
using torneos.Models;
using static torneos.Models.libLogin;

namespace torneos.Clases
{
    public class clsLogin
    {

        private DBExamenEntities dbSuper = new DBExamenEntities();

        public Login login { get; set; }

        private LoginRespuesta logRpta;

        private bool ValidarUsuario()

        {

            try

            {

                AdministradorITM admin = dbSuper.AdministradorITMs.FirstOrDefault(u => u.Usuario == login.Usuario);

                if (admin == null)

                {

                    logRpta = new LoginRespuesta();

                    logRpta.Mensaje = "Usuario no existe";

                    return false;

                }

                login.Clave = admin.Clave;

                return true;

            }

            catch (Exception ex)

            {

                logRpta = new LoginRespuesta();

                logRpta.Mensaje = ex.Message;

                return false;

            }

        }

        public IQueryable<LoginRespuesta> Ingresar()

        {

            if (ValidarUsuario())

            {

                //string token = TokenGenerator.GenerateTokenJwt(login.Usuario);

                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);

                return from U in dbSuper.Set<AdministradorITM>()

                       where U.Usuario == login.Usuario &&

                             U.Clave == login.Clave

                       select new LoginRespuesta

                       {

                           Usuario = U.Usuario,

                           Autenticado = true,

                           Token = token,

                           Mensaje = "Usuario autenticado",

                       };

            }

            else

            {

                return null;

            }

        }


    }
}