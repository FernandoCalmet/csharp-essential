using design_patterns.adapter.example_manufacturer_data;

var xmlConverter = new XmlConverter();
var adapter = new XmlToJsonAdapter(xmlConverter);
adapter.ConvertXmlToJson();