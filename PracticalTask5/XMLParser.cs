using PracticalTask3;
using PracticalTask3.Vehicles;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

/// <summary>
/// Practical task 5. Outputs required xml files in its working directory.
/// </summary>
public class XMLParser
{
    static void Main(string[] args)
    {
        List<IVehicle> carPark = ParkPopulator.Populate();

        var volumeQuery = from vehicle in carPark
                    where vehicle.Engine.Volume >= 1500
                    select vehicle;
        var xmlWriter = XmlWriter.Create(new StreamWriter("Engines1500.xml"));
        xmlWriter.WriteStartElement("Root");
        foreach (var vehicle in volumeQuery)
        {
            XmlSerializer serializer = new(vehicle.GetType());
            serializer.Serialize(xmlWriter, vehicle);
        }
        xmlWriter.Close();

        var busNTruckQuery = from vehicle in carPark
                             where vehicle.Type == "Bus" || vehicle.Type == "Truck"
                             select new XElement(vehicle.Type,
                                new XElement("Name", vehicle.Name),
                                new XElement("Engine",
                                    new XElement("Type", vehicle.Engine.Type),
                                    new XElement("Serial", vehicle.Engine.Serial),
                                    new XElement("Volume", vehicle.Engine.Volume)));
        xmlWriter = XmlWriter.Create(new StreamWriter("BusNTruck.xml"));
        xmlWriter.WriteStartElement("Root");
        foreach (var vehicle in busNTruckQuery)
        {
            XmlSerializer serializer = new(vehicle.GetType());
            serializer.Serialize(xmlWriter, vehicle);
        }
        xmlWriter.Close();

        var transmissionQuery = from vehicle in carPark
                     group vehicle by vehicle.Transmission.Type;
        xmlWriter = XmlWriter.Create(new StreamWriter("TransmissionType.xml"));
        xmlWriter.WriteStartElement("Root");
        foreach (var group in transmissionQuery)
        {
            xmlWriter.WriteStartElement(group.Key.Replace(" ", ""));
            foreach (var vehicle in group)
            {
                XmlSerializer serializer = new(vehicle.GetType());
                serializer.Serialize(xmlWriter, vehicle);
            }
            xmlWriter.WriteEndElement();
        }
        xmlWriter.Close();
    }
}