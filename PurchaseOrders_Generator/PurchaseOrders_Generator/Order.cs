using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PurchaseOrders_Generator
{
    class Order
    {
        private XmlDocument xml;
        private string id;
        private string guuid;
        private DateTime issueDate;
        private XmlNamespaceManager nsmgr;

        

        public Order()
        {
            //la ruta del xml es fija dentro del archivo raíz de la aplciación
            string xmlPath = Application.StartupPath.ToString() + "\\Order-template.xml";

            xml = new XmlDocument();
            xml.Load(xmlPath);
            
            //Como el XML Order-template.xml tiene nameSpaces, debe haber un nameSpaceManager para poder efectuar consultas XPath sobre él
            setNameSpaceManager();
        }

        public XmlDocument Xml
        {
            get { return xml; } 
            set { xml = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string GUUID
        {
            get { return guuid; }
            set { guuid = value; }
        }

        public DateTime IssueDate
        {
            //La propiedad issueDate se asignará con la qhora en que se realice la Instancia
            get { return DateTime.Now ; }
            set { issueDate = value; }
        }

        public XmlNamespaceManager Nsmgr
        {
            get { return nsmgr; }
            set { nsmgr = value; }
        }

        public void generarID()
        {
            Random r = new Random();
            string posibles = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitud = posibles.Length;
            char letra;
            //el id debe ser de 10 caracteres
            int longitudNuevaCadena = 10;
            string nuevaCadena = "";
            //hasta alcanzar un tamaño de 10 caracteres concatenaré un caracter dentro del string "Posibles" buscado con un indice aleatorio
            for (int i = 0; i < longitudNuevaCadena; i++)
            {
                letra = posibles[r.Next(longitud)];
                nuevaCadena += letra.ToString();
            }
            id = nuevaCadena;
            //Guardo el ID dentro del XML
            setSingleNodo("/*/cbc:ID", nuevaCadena);
        }

        //metodo para generar un nuevo GUIID
        public void generarGUIID()
        {
            guuid = Guid.NewGuid().ToString();
            //Guardo el ID dentro del XML
            setSingleNodo("/*/cbc:UUID", guuid);
        }

        public void setIssueDate()
        {
            //Guardo el Get de la propiedad Issuedate en un formato de fecha estándar
            setSingleNodo("/*/cbc:IssueDate", IssueDate.ToString("yyyy/MM/dd hh:mm:ss"));
        }

        public void setSingleNodo(string xpath, string value)
        {
            XmlNode node = xml.SelectSingleNode(xpath, Nsmgr);
            node.InnerText = value;
        }

        public void reemplazarNodo(string xpath, XmlNode nuevoNodo)
        {
            //El nodo del xpath sería el hijo
            XmlNode hijo = xml.SelectSingleNode(xpath, Nsmgr);
            //Guardo el padro
            XmlNode padre = hijo.ParentNode;
            //en el padre guardo el nodo como un "hermano" simeplemente añadiendolo como otro nodo
            //hay que importar el nodo dentro del Documento de Order-teplamte que es el propietario (owner) de los nodos, 
            //si no se  hace esto no se peuden mezclar nodos de diferentes documentos XML
            padre.AppendChild(hijo.OwnerDocument.ImportNode(nuevoNodo, true));
            //Elimino el primer hijo para que solo quede el recien agregado
            padre.RemoveChild(hijo);
        }

        public void agregarOrderLine(XmlNode orderLine)
        {
            XmlNode hijo = Xml.SelectSingleNode("/*/cac:OrderLine", nsmgr);
            hijo.ParentNode.AppendChild(hijo.OwnerDocument.ImportNode(orderLine, true));
            //xml.DocumentElement.AppendChild(orderLine);
        }

        private void setNameSpaceManager()
        {
            //El NameSpaceManager simplemente guarda las "referencias" pro asi decirlos de los nameSpaces para poder realizar las consultas dentro del documento XMl
            Nsmgr = new XmlNamespaceManager(xml.NameTable);
            Nsmgr.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"); Nsmgr.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            Nsmgr.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            Nsmgr.AddNamespace("", "urn:oasis:names:specification:ubl:schema:xsd:Order-2");
        }

        public XmlNode getOrderLine()
        {
            return xml.SelectSingleNode("/*/cac:OrderLine", Nsmgr);
        }


    }
}
