using ApiRest.Contexto;
using ApiRest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ApiRest.Services
{
    public class UsuariosServicesSQL:IUsuariosServices
    {
        private dbBancos dbBancos;

        public UsuariosServicesSQL(dbBancos dbBancos)
        {
            this.dbBancos = dbBancos;
        }

        public Usuarios Actualizar(Usuarios dto)
        {
            dbBancos.Usuarios.Update(dto);
            dbBancos.SaveChanges();
            return dto;
        }

        public Usuarios Eliminar(Usuarios dto)
        {
            throw new NotImplementedException();
        }

        public Usuarios Insert(Usuarios dto)
        {
            dbBancos.Usuarios.Add(dto);
            dbBancos.SaveChanges();
            return dto;
        }

        public List<Usuarios> Listar(string dto)
        {
            List<Usuarios> peer = dbBancos.Usuarios.FromSqlRaw($"SELECT * from Usuarios").ToList();
            try
            {
                var user = new SqlParameter("cc", dto);
                var query = dbBancos.Usuarios.FromSqlRaw($"SELECT * from Usuarios where cedula=@cc", user).ToList();
                string clave = query[0].clave;
                peer = query;
            }
            catch
            { }

            
                  
            return peer;

        }
        public List<Usuarios> Imprime()
        {
            var query = dbBancos.Usuarios.ToList();
            string clave = query[0].clave;

            return query;

        }
        public List<Usuarios> LCuenta(string dto)
        {
            var user = new SqlParameter("cc", dto);
            var query = dbBancos.Usuarios.FromSqlRaw($"SELECT * from Usuarios where cuenta=@cc",user).ToList();
            string clave = query[0].clave;

            return query;

        }

        public Usuarios Recuperar(Usuarios dto)
        {
            throw new NotImplementedException();
        }

        public String Login(string dto)
        {
            string clave = "";
            try
            {
                var user = new SqlParameter("cc", dto);
                var query = dbBancos.Usuarios.FromSqlRaw($"SELECT * from Usuarios where cedula=@cc", user).ToList();
                clave = query[0].clave;
                
            }
            catch
            {
                Console.WriteLine("ERROR");
            }
            return clave;


        }

        public String Roles(string dto)
        {
            string clave = "";
            try
            {
                var user = new SqlParameter("cc", dto);
                var query = dbBancos.Usuarios.FromSqlRaw($"SELECT * from Usuarios where cedula=@cc", user).ToList();
                clave = query[0].rol;
            }
            catch
            {
                
            }

            return clave;

        }

    }
}
