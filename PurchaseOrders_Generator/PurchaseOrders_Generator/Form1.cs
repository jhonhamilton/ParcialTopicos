using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PurchaseOrders_Generator
{
    public partial class Form1 : Form
    {
        // el objeto random debe ser una variable de instancia (global) y solo se puede instanciar 1 vez para que los numeros no se repitan
        Random r;
        public Form1()
        {
            InitializeComponent();
            //Asigno las rutas por defecto que es dentro de la carpeta "bin" del aplicativo
            txtParties.Text = Application.StartupPath.ToString() + @"\parties.xml";
            txtProducts.Text = Application.StartupPath.ToString() + @"\items.xml";
            r = new Random();
        }

        private void btnOpenParties_Click(object sender, EventArgs e)
        {
            //muestro el cuadro de diálogo
            openFileParties.Filter = "Archivos XML|*.xml";
            if (openFileParties.ShowDialog() == DialogResult.OK)
            {
                txtParties.Text = openFileParties.FileName;
               //string strParties = File.ReadAllText(archivo);
            }

        }

        private void btnExaminarProductos_Click(object sender, EventArgs e)
        {
            //muestro el cuadro de diálogo
            openFileParties.Filter = "Archivos XML|*.xml";
            if (openFileParties.ShowDialog() == DialogResult.OK)
            {
                //muestro la nueva ruta del archivo de productos
                txtProducts.Text = openFileParties.FileName;
                //string strParties = File.ReadAllText(archivo);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //Ésta clase nos ayuda a medir tiempos
            Stopwatch tiempo = Stopwatch.StartNew();
            //Realizar el proceso el numero de veces que se asigne en el numericUpDown
            for (int i = 0; i < nudCantidadOrdenes.Value; i++)
            {
                //Instancio la clase ordenCOmpra y uso sus funciones para generar ID, GUIID y la FECHA y serán asignados a la spropiedades de la clase
                Order ordenCompra = new Order();
                ordenCompra.generarID();
                ordenCompra.generarGUIID();
                ordenCompra.setIssueDate();

                //instancio la clase parties y le mando la ruta del archivo en el constructor de la clase
                Parties parties = new Parties(txtParties.Text);
                //roto el SellerCustomerParty para que la propiedad SellerCustomerParty obtenga un nuevo nodo aleatoriamente
                parties.rotateSeller();
                //roto el BuyerCustomerParty para que la propiedad BuyerCustomerParty obtenga un nuevo nodo aleatoriamente
                parties.rotateBuyer();

                //sustituyo los nodos de la orden de compra SellerSupplierParty y BuyerCustomerParty, por los nuevos nodos obtenidos
                ordenCompra.reemplazarNodo("/*/cac:SellerSupplierParty/cac:Party", parties.SellerSupplierParty);
                ordenCompra.reemplazarNodo("/*/cac:BuyerCustomerParty/cac:Party", parties.BuyerCustomerParty);

                //Instancio una clase de items y mando la ruta por el constructor
                Items item = new Items(txtProducts.Text);

                //Aleatoriamente obtendo la cantidad de orderLines que se crearán (entre 1 y 10)
                int cantidadOrderLines = r.Next(10);
                for (int j = 0; j < cantidadOrderLines; j++)
                {
                    //Cambio de item, esto variará los valores de las propiedades de la clase aleatoriamente
                    item.rotateItem();

                    //obtendo una "copia" de un nodo XmlOrderLine para tenerlo como base, reemplazar sus valores, y luego añadirlo nuevamente al documento de Order de compra
                    XmlNode orderLine = ordenCompra.getOrderLine();
                    //Guardo en el nodo temporal de orderLine los valores de Description, Quantity, PriceAmount, LineExtensionAmount. tomandolos de las propiedades de la clase Items.cs
                    orderLine.SelectSingleNode("//cac:Item/cbc:Description", ordenCompra.Nsmgr).InnerText = item.Description.ToString();
                    orderLine.SelectSingleNode("//cbc:Quantity", ordenCompra.Nsmgr).InnerText = item.Quantity.ToString();
                    orderLine.SelectSingleNode("//cbc:PriceAmount", ordenCompra.Nsmgr).InnerText = item.PriceAmount.ToString();
                    orderLine.SelectSingleNode("//cac:LineItem/cbc:LineExtensionAmount", ordenCompra.Nsmgr).InnerText = item.LineExtensionAmount.ToString();
                    //Añado la nueva orderLine
                    ordenCompra.agregarOrderLine(orderLine);
                }

                //ruta para guardar el nuevo archivo dependiendo del ID de la Order de compra
                string ruta = Application.StartupPath.ToString() + @"\Orders\" + ordenCompra.GUUID + ".xml";
                //Guardo
                ordenCompra.Xml.Save(ruta);
            }
            MessageBox.Show("Tiempo total: " + tiempo.Elapsed + " milésimas de segundos");
        }
    }
}
