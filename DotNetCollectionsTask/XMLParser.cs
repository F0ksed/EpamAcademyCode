using OopTask;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

/// <summary>
/// Practical task 5. Outputs required xml files in its working directory.
/// </summary>
public class XMLParser
{
    static void Main()
    {
        CarPark carPark = new();
        carPark.AddAuto(ParkPopulator.Populate());

        var volumeQuery = from vehicle in carPark.GetAutoList()
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

        var busNTruckQuery = from vehicle in carPark.GetAutoList()
                             where vehicle.GetType().Name == "Bus" || vehicle.GetType().Name == "Truck"
                             select new XElement(vehicle.GetType().Name,
                                new XElement("Name", vehicle.Name),
                                new XElement("Engine",
                                    new XElement("Type", vehicle.Engine.Type),
                                    new XElement("Serial", vehicle.Engine.Serial),
                                    new XElement("Power", vehicle.Engine.Power)));
        xmlWriter = XmlWriter.Create(new StreamWriter("BusNTruck.xml"));
        xmlWriter.WriteStartElement("Root");
        foreach (var vehicle in busNTruckQuery)
        {
            XmlSerializer serializer = new(vehicle.GetType());
            serializer.Serialize(xmlWriter, vehicle);
        }
        xmlWriter.Close();

        var transmissionQuery = from vehicle in carPark.GetAutoList()
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