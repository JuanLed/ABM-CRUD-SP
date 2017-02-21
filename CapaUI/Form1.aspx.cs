using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using CapaNegocio;

namespace CapaUI
{
    public partial class Form1 : System.Web.UI.Page
    {
        //Variables//
        private Empleado _empleado = new Empleado();
        private EmpleadoVerif _empleadoVerif = new EmpleadoVerif();
        private int val; //Variable tipo Int utilizada para verificar con TryParse
        const string  DefaultError = "Errores/Notificaciones";
        //

        //Metodos//
        private void ShowAll ()
        {
            errorLabel.Text = DefaultError;
            clearFields();

            List<Empleado> listaEmpleados = _empleadoVerif.returnAll();
            if(listaEmpleados.Count > 0)
            {
                //Luego de obtener la lista actualizada de empleados, se carga la misma en GridView de interfaz
                GridViewEmp.DataSource = listaEmpleados;
                GridViewEmp.DataBind();
                GridViewEmp.Visible = true;
            }
            else
            {
                //Se utiliza en este caso y durante toda interacción con usuario, un Label para comunicar errores y notificaciones pertinentes.
                errorLabel.Text = "No existe ningun empleado cargado";
                errorLabel.Visible = true;
            }

        }

        private void InsertData()
        {
            try
            {
                errorLabel.Text = DefaultError;
                val = 0;

                if (_empleado != null) _empleado = new Empleado();

                //Se obtienen datos desde objetos TextBox correspondientes.
                if (!string.IsNullOrEmpty(primerNombre.Text))
                    _empleado.primerNombre = primerNombre.Text;

                if (!string.IsNullOrEmpty(segundoNombre.Text))
                    _empleado.segundoNombre = segundoNombre.Text;

                if (!string.IsNullOrEmpty(puesto.Text))
                    _empleado.puesto = puesto.Text;

                //TRY PARSE EN VALORES INT
                if (int.TryParse(sueldo.Text, out val))
                    _empleado.sueldo = val;

                if (int.TryParse(antiguedad.Text, out val))
                    _empleado.antiguedad = val;

                if (!string.IsNullOrEmpty(intID.Text))
                {
                    if (int.TryParse(intID.Text, out val))
                        _empleado.id = val;
                }

                _empleadoVerif.Insertar(_empleado);

                if(_empleadoVerif.stringBuilder.Length != 0)
                {
                    //Se hace uso del objeto stringBuilder antes declarado y utilizado en capaNegocio, para notificar nuevamente mediante Label.
                    errorLabel.Text = _empleadoVerif.stringBuilder.ToString() + "Complete los datos faltantes para continuar";
                }
                else
                {
                    errorLabel.Text = "El usuario se ha ingresado/actualizado con exito!";
                    clearFields();
                }
            }
            //De ocurrir un error inesperado, el mismo es obtenido y cargado en label de informe a usuario.
            catch (Exception ex)
            {
                errorLabel.Text = string.Format("Error: {0}", ex.Message);
            }

        }

        private void ShowByID(int id)
        {
            try
            {
                clearFields();
                //Se solicita desde capa negocio mediante la función ShowByID, los datos completos del empelado solicitado.
                _empleado = _empleadoVerif.ShowByID(id);

                if (_empleado != null)
                {
                    GridViewEmp.DataSource = new Empleado[1] { _empleado };
                    GridViewEmp.DataBind();
                    GridViewEmp.Visible = true;
                }
                else
                {
                    errorLabel.Text = "El empleado solicitado no existe";
                }
            }
            catch (Exception ex)
            {
                errorLabel.Text = string.Format("Error: {0}", ex.Message);
            }
        }

        private void DeleteByID(int id)
        {
            try
            {
                _empleadoVerif.DeleteByID(id);

                if(_empleadoVerif.stringBuilder.Length != 0)
                {
                    errorLabel.Text = _empleadoVerif.stringBuilder.ToString();
                }
                else
                {
                    errorLabel.Text = "El usuario fue eliminado con exito!";
                }
            }
            catch (Exception ex)
            {
                errorLabel.Text = string.Format("Error: {0}", ex.Message);
            }
        }
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowAll();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void showBtn_Click(object sender, EventArgs e)
        {
            ShowAll();
        }

        protected void GridViewEmp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void insertbtn_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        private void clearFields()
        {
            primerNombre.Text = null;
            segundoNombre.Text = null;
            sueldo.Text = null;
            intID.Text = null;
            antiguedad.Text = null;
            puesto.Text = null;
        }

        protected void bringBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(intID.Text, out val))
            {
                ShowByID(val);
            }
        }

        protected void deletebtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(intID.Text, out val))
            {
                DeleteByID(val);
            }
        }
    }
}