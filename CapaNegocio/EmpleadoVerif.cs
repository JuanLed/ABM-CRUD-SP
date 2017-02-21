using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using CapaDatos;

namespace CapaNegocio
{
   public class EmpleadoVerif
    {

        //Se inicialia objeto publico de tipo stringBuilder, la cual sera util para mostrar mensajes a usuario en Capa Presentación
        public readonly StringBuilder stringBuilder = new StringBuilder();
        //Se inicializa instancia de objeto Connection
        Connection connection = new Connection();

        //METODOS//      

        public List<Empleado> returnAll()
        {
            return connection.ShowAll();
        }
        //Verifica que todos los valores ingresados en capa de presentación sean correctos y luego procede a insertar o actualizar estado de entrada en tabla.  
        //Los demas metodos en esta clase siguen el mismo proceso de verificar datos ingresados y luego ejecutar acción deseada usando metodos en capa de Datos.
        public void Insertar(Empleado empleado)
        {
           
            if(ValidarEmpleado(empleado) == true)
            {
                if (connection.GetByID(empleado.id) == null)
                {
                    connection.Insert(empleado);
                }
                else
                {
                    connection.Update(empleado);
                }
            }
            
        } 

        public Empleado ShowByID(int id)        
        {
            stringBuilder.Clear();

            if (connection.GetByID(id) == null)
            {
                stringBuilder.Append("El ID proporcionado no existe en la tabla");
                return null;
            }
            else return connection.GetByID(id);           
        }

        public void DeleteByID (int id)
        {
            if (connection.GetByID(id) == null)
            {
                stringBuilder.Append("El ID proporcionado no existe en la tabla");
            }
            else connection.Delete(id);

        }

        private bool ValidarEmpleado(Empleado empleado)  // Verifica datos ingresados por Usuario, de ser correctos devuelve Boolean True 
        {
            stringBuilder.Clear();

            //Se carga objeto tipo StringBuilder con texto necesario para comunicar mensajes, en caso de ser pertinente.
            if (string.IsNullOrEmpty(empleado.primerNombre)) stringBuilder.Append("El campo 'Primer Nombre' es obligatorio. ");
            if (string.IsNullOrEmpty(empleado.segundoNombre)) stringBuilder.Append(Environment.NewLine + "El campo 'Segundo Nombre' es obligatorio. ");
            if (string.IsNullOrEmpty(empleado.puesto)) stringBuilder.Append(Environment.NewLine + "El campo 'Puesto' es obligatorio.");
            if (empleado.antiguedad <= 0) stringBuilder.Append(Environment.NewLine + "El campo 'Antiguedad' es obligatorio. ");
            if (empleado.sueldo <= 0) stringBuilder.Append(Environment.NewLine + "El campo 'Sueldo' es obligatorio. ");

            return stringBuilder.Length == 0;
        }

    }
}
