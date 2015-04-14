using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PurchaseOrders_Generator
{
    class Items
    {
        //constructor para recibir la ruta del archivo de parties (empresas)
        public Items(string ruta)
        {
            xml = new XmlDocument();
            xml.Load(ruta);
            setNameSpaceManager();
            r= new Random();
        }

        Random r;
        private XmlDocument xml;
        private XmlNamespaceManager nsmgr;
        private string description;
        private double priceAmount;
        private int quantity;
        private double lineExtensionAmount;
        

        public XmlDocument Xml
        {
            get { return xml; }
            set { xml = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public double PriceAmount
        {
            get { return priceAmount; }
            set { priceAmount = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public double LineExtensionAmount
        {
            get { return PriceAmount * Quantity; }
            set { lineExtensionAmount = value; }
        }


        private void setNameSpaceManager()
        {
            nsmgr = new XmlNamespaceManager(xml.NameTable);
            nsmgr.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"); 
            nsmgr.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            nsmgr.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            nsmgr.AddNamespace("", "urn:oasis:names:specification:ubl:schema:xsd:Catalogue-2");
        }

        public void rotateItem()
        {
            //obtengo el toda la lsita de items que tenga el archivo xml
            XmlNodeList nodes = xml.SelectNodes("/*/cac:CatalogueLine", nsmgr);
            int rand = r.Next(nodes.Count);
            //selecciono un nodo de la lista aleatoriamente y lo clono para que el nodo no se quede estático
            XmlNode node = nodes[rand].CloneNode(true); 
            //Busco dentro del nodo aleatorio el hijo Description sin importar que tan "profundo" esté dentro del nodo
            description = (node.SelectSingleNode("//cbc:Description", nsmgr).InnerText);
            //realizo el mismo proceso para 
            priceAmount = double.Parse(node.SelectSingleNode("//cbc:PriceAmount", nsmgr).InnerText);
            //genero valor aleatorio entre 0 y 100 para la quantity
            Quantity = r.Next(100);
        }
    }
}
