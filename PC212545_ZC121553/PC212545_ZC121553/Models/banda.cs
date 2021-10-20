using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PC212545_ZC121553.Models
{
    
    public class banda
    {
        DBTALLER3 contexto;

        public banda()
        {
            contexto = new DBTALLER3();
        }
        public List<Table_2> GetUsuarios()
        {
            // ESTE ESTOY TRABAJANDO
            //ALMACENAR LOS DATOS RECOGIDOS MEDIANTE LA CONSULTA EN LA VIARIABLE ListaUsuarios
            var ListaUsuarios = (from datos in contexto.Table_2 select datos).ToList();

            //RETORNAMOS LOS DATOS QUE OBTUVIMOS EN LA CONSULTA PARA PODER UTILIZARLOS EN usuarioscontroller
            return ListaUsuarios;
        }
        public void InsertarUsuarios(String BANDA, String INTEGRANTES, String ALBUM, String SENCILLOS)
        {
            Table_2 user = new Table_2();

            user.id = (from dt in contexto.Table_2 select dt.id).Max() + 1;
            user.banda = BANDA;
            user.integrantes = INTEGRANTES;
            user.album = ALBUM;
            user.sencillos = SENCILLOS;

            //INSERTAR EL USUARIO al CONTEXTO
            contexto.Table_2.Add(user);

            //GUARDA LOS CAMBIOS
            contexto.SaveChanges();
        }
        //METODO PARA ELIMINAR USUARIOS 
        public void EliminarUsuarios(int ID)
        {
            var user = (from dt in contexto.Table_2
                        where dt.id == ID
                        select dt).FirstOrDefault();

            //ELIMINA EL USUARIO DEL CONTEXTO
            contexto.Table_2.Remove(user);

            //GUARDA LOS CAMBIOS
            contexto.SaveChanges();
        }

        //METODO PARA MODIFICAR LOS DATOS DE LOS USUARIOS
        public void ModificarUsuarios(int ID, String BANDA, String INTEGRANTES, String ALBUM, String SENCILLOS)
        {
            //BUSCAMOS EL USUARIO QUE SE QUIERE EDITAR PASANDOLE COMO PARAMETRO EL id
            Table_2 user = this.DetallesUsuarios(ID);
            user.banda = BANDA;
            user.integrantes = INTEGRANTES;
            user.album = ALBUM;
            user.sencillos = SENCILLOS;

            contexto.SaveChanges();
        }

        //METODO PARA MOSTRAR LOS DATOS DE LOS USUARIOS
        public Table_2 DetallesUsuarios(int ID)
        {
            var user = (from dt in contexto.Table_2
                        where dt.id == ID
                        select dt).FirstOrDefault();

            return user;
        }
    }
}