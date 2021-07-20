using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioRESTNetCore
{
    public class StorageAzure
    {
        public List<Clientes> ListadeClientes;

        public List<Clientes> Consulta(int ID)
        {
            var dt = new DataTable();
            var connect = new SqlConnection("{SQL Connection string}");
            var cmd = new SqlCommand("SELECT * From Datos Where ID='" + ID + "'", connect);
            try
            {
                connect.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                ListadeClientes = new List<Clientes>();
                Clientes cliente = new Clientes();
                cliente.ID = int.Parse((dt.Rows[0]["ID"]).ToString());
                cliente.Nombre = (dt.Rows[0]["Nombre"]).ToString();
                cliente.Domicilio = (dt.Rows[0]["Domicilio"]).ToString();
                cliente.Correo = (dt.Rows[0]["Correo"]).ToString();
                cliente.Edad = int.Parse((dt.Rows[0]["Edad"]).ToString());
                cliente.Saldo = double.Parse((dt.Rows[0]["Saldo"]).ToString());
                connect.Close();

                ListadeClientes.Add(cliente);
                return ListadeClientes;
            }
            catch (System.Exception ex)
            {
                connect.Close();
                return ListadeClientes;
            }
        }

        public bool Almacenar(string Nombre, string Domicilio, string Correo, int Edad, double Saldo)
        {
            var connect = new SqlConnection("{SQL Connection string}");
            var query = new SqlCommand("INSERT INTO Datos (Nombre, Domicilio, Correo, Edad, Saldo) Values ('" 
                + Nombre + "','" + Domicilio + "','"+ Correo + "','" + Edad + "','" + Saldo + "')", connect);
            try
            {
                connect.Open();
                query.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                connect.Close();
                return false;
            }
        }
    }
}
