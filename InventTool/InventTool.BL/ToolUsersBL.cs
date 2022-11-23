using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventTool.BL
{
    public class ToolUsersBL
    {
        Contexto _contexto;
        public List<ToolUsers> ListadeUsuarios { get; set; }

        public ToolUsersBL()
        {
            _contexto = new Contexto();
            ListadeUsuarios = new List<ToolUsers>();
        }

        public List<ToolUsers> ObtenerUsuarios()
        {

            ListadeUsuarios = _contexto.ToolUsers
               .OrderBy(r => r.NombreUsuario)
               .ToList();

            return ListadeUsuarios;
        }

        public List<ToolUsers> ObtenerUsuariosActivos()
        {

            ListadeUsuarios = _contexto.ToolUsers
                .Where(r => r.Activo == true)
                .OrderBy(r => r.NombreUsuario)
                .ToList();

            return ListadeUsuarios;
        }

        public void GuardarUsuarios(ToolUsers toolUsers)
        {
            if (toolUsers.Id == 0)
            {
                _contexto.ToolUsers.Add(toolUsers);
            }
            else
            {
                var usuarioExistente = _contexto.ToolUsers.Find(toolUsers.Id);
                usuarioExistente.NombreUsuario = toolUsers.NombreUsuario;
                usuarioExistente.Activo = toolUsers.Activo;


            }

            _contexto.SaveChanges();

        }

            public ToolUsers ObtenerUsuarios(int id)
            {
            var toolUsers = _contexto.ToolUsers.Find(id);
                    
                return toolUsers;
            }

            public void EliminarUsuarios(int id)
            {
                var toolUsers = _contexto.ToolUsers.Find(id);
                _contexto.ToolUsers.Remove(toolUsers);
                _contexto.SaveChanges();
            }
        }
    }
