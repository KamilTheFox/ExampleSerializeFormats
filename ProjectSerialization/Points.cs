using System.Text.Json;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using Point = PointLib.Point;
using SerializatorFox;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System;

namespace ProjectSerialization
{
    public partial class Points : Form
    {
        private List<Point> points = [];
        public Points()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            var rnd = new Random();

            points.Add(
                rnd.Next(3) % 2 == 0 ? new Point() : new Point3D()
                );
            RebindData(points);
        }
        

        private void Sort_Click(object sender, EventArgs e)
        {
            points.Sort();
            RebindData(points);
        }

        private void RebindData(object data)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = data;
        }
        private void Serialize_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.Filter = "SOAP|*.soap|XML|*.xml|JSON|*.json|Binary|*.bin|FOX|*.fox";

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            using (var fileStream =
                new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write))
            {
                switch (Path.GetExtension(dlg.FileName))
                {
                    case ".bin":
                        MessageBox.Show("Не поддерживается");
                        //var bf = new BinaryFormatter();
                        //bf.Serialize(fs, points);
                        break;
                    case ".soap":
                        var soap = new SoapFormatter();
                        soap.Serialize(fileStream, points);
                        break;
                    case ".xml":
                        var xml = new XmlSerializer(typeof(Point[]), new[] { typeof(Point3D) } );
                        xml.Serialize(fileStream, points);
                        break;
                    case ".json":
                        var json = JsonSerializer.Serialize(points);
                        fileStream.Write(Encoding.UTF8.GetBytes(json));
                        break;
                    case ".fox":
                        byte[] serializePoints;
                        using (var serializerFox = new ByteSerialeze(true))
                        {
                            serializerFox.Serialize(points);
                            serializePoints = serializerFox.GetData();
                        }
                        fileStream.Write(serializePoints);
                        break;
                    case ".yaml":
                        var serializer = new SerializerBuilder()
                        .WithNamingConvention(CamelCaseNamingConvention.Instance)
                        .Build();
                        string yaml = serializer.Serialize(points);
                        fileStream.Write(Encoding.UTF8.GetBytes(yaml));
                        break;

                }
            }
        }
        private void Deserialize_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "SOAP|*.soap|XML|*.xml|JSON|*.json|Binary|*.bin|FOX|*.fox|YAML|*.yaml";

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            using (var fileStream =
                new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read))
            {
                switch (Path.GetExtension(dlg.FileName))
                {
                    case ".bin":
                        MessageBox.Show("Не поддерживается");
                        //var bf = new BinaryFormatter();
                        //points = (List<Point>)bf.Deserialize(fileStream);
                        break;

                    case ".soap":
                        var soap = new SoapFormatter();
                        points = (List<Point>)soap.Deserialize(fileStream);
                        break;

                    case ".xml":
                        var xml = new XmlSerializer(typeof(List<Point>), new[] { typeof(Point3D) });
                        points = (List<Point>)xml.Deserialize(fileStream);
                        break;

                    case ".json":
                        using (var reader = new StreamReader(fileStream))
                        {
                            string jsonString = reader.ReadToEnd();
                            points = JsonSerializer.Deserialize<List<Point>>(jsonString);
                        }
                        break;

                    case ".fox":
                        byte[] buffer = new byte[fileStream.Length];
                        fileStream.Read(buffer, 0, buffer.Length);
                        using (var deserializerFox = new ByteDeserializer(buffer))
                        {
                            points = deserializerFox.Deserialize<List<Point>>();
                        }
                        break;

                    case ".yaml":
                        using (var reader = new StreamReader(fileStream))
                        {
                            var deserializer = new DeserializerBuilder()
                                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                                .Build();
                            string yamlContent = reader.ReadToEnd();
                            points = deserializer.Deserialize<List<Point>>(yamlContent);
                        }
                        break;
                }
            }
        }
    }
}
