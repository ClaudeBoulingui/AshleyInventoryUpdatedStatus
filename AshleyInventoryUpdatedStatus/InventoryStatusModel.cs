using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AshleyInventoryUpdatedStatus
{
	[System.Xml.Serialization.XmlRoot(ElementName = "document")]
	public class Document
	{
		[XmlElement(ElementName = "creationDate")]
		public string CreationDate { get; set; }
		[XmlElement(ElementName = "creationTime")]
		public string CreationTime { get; set; }
		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName = "purpose")]
		public string Purpose { get; set; }
	}

	[XmlRoot(ElementName = "originalDocument")]
	public class OriginalDocument
	{
		[XmlElement(ElementName = "creationDate")]
		public string CreationDate { get; set; }
		[XmlElement(ElementName = "creationTime")]
		public string CreationTime { get; set; }
		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName = "partyIdentifier", Namespace = "http://support.furnishnet.com/xml/schemas/fnParty_v1.4")]
	public class PartyIdentifier
	{
		[XmlAttribute(AttributeName = "partyIdentifierCode")]
		public string PartyIdentifierCode { get; set; }
		[XmlAttribute(AttributeName = "partyIdentifierQualifierCode")]
		public string PartyIdentifierQualifierCode { get; set; }
	}

	[XmlRoot(ElementName = "potentialBuyer")]
	public class PotentialBuyer
	{
		[XmlElement(ElementName = "partyIdentifier", Namespace = "http://support.furnishnet.com/xml/schemas/fnParty_v1.4")]
		public PartyIdentifier PartyIdentifier { get; set; }
	}

	[XmlRoot(ElementName = "potentialShipTo")]
	public class PotentialShipTo
	{
		[XmlElement(ElementName = "partyIdentifier", Namespace = "http://support.furnishnet.com/xml/schemas/fnParty_v1.4")]
		public PartyIdentifier PartyIdentifier { get; set; }
	}

	[XmlRoot(ElementName = "potentialSeller")]
	public class PotentialSeller
	{
		[XmlElement(ElementName = "partyIdentifier", Namespace = "http://support.furnishnet.com/xml/schemas/fnParty_v1.4")]
		public PartyIdentifier PartyIdentifier { get; set; }
	}

	[XmlRoot(ElementName = "inquiry")]
	public class Inquiry
	{
		[XmlElement(ElementName = "document")]
		public Document Document { get; set; }
		[XmlElement(ElementName = "originalDocument")]
		public OriginalDocument OriginalDocument { get; set; }
		[XmlElement(ElementName = "potentialBuyer")]
		public PotentialBuyer PotentialBuyer { get; set; }
		[XmlElement(ElementName = "potentialShipTo")]
		public PotentialShipTo PotentialShipTo { get; set; }
		[XmlElement(ElementName = "potentialSeller")]
		public PotentialSeller PotentialSeller { get; set; }
	}

	[XmlRoot(ElementName = "itemIdentifier")]
	public class ItemIdentifier
	{
		[XmlAttribute(AttributeName = "itemNumber")]
		public string ItemNumber { get; set; }
		[XmlAttribute(AttributeName = "itemNumberQualifier")]
		public string ItemNumberQualifier { get; set; }
	}

	[XmlRoot(ElementName = "itemId")]
	public class ItemId
	{
		[XmlElement(ElementName = "itemIdentifier")]
		public ItemIdentifier ItemIdentifier { get; set; }
	}

	[XmlRoot(ElementName = "availQty")]
	public class AvailQty
	{
		[XmlAttribute(AttributeName = "unitOfMeasure")]
		public string UnitOfMeasure { get; set; }
		[XmlAttribute(AttributeName = "value")]
		public string Value { get; set; }
	}

	[XmlRoot(ElementName = "availSystemReference")]
	public class AvailSystemReference
	{
		[XmlElement(ElementName = "systemReferenceDescription")]
		public string SystemReferenceDescription { get; set; }
		[XmlElement(ElementName = "systemReferenceValue")]
		public string SystemReferenceValue { get; set; }
	}

	[XmlRoot(ElementName = "itemAvailability")]
	public class ItemAvailability
	{
		[XmlElement(ElementName = "availQty")]
		public AvailQty AvailQty { get; set; }
		[XmlElement(ElementName = "availSystemReference")]
		public AvailSystemReference AvailSystemReference { get; set; }
		[XmlAttribute(AttributeName = "availability")]
		public string Availability { get; set; }
		[XmlElement(ElementName = "availDate")]
		public string AvailDate { get; set; }
	}

	[XmlRoot(ElementName = "itemAdvice")]
	public class ItemAdvice
	{
		[XmlElement(ElementName = "itemId")]
		public ItemId ItemId { get; set; }
		[XmlElement(ElementName = "itemAvailability")]
		public List<ItemAvailability> ItemAvailability { get; set; }
		[XmlAttribute(AttributeName = "lineItemNumber")]
		public string LineItemNumber { get; set; }
	}

	[XmlRoot(ElementName = "items")]
	public class Items
	{
		[XmlElement(ElementName = "itemAdvice")]
		public List<ItemAdvice> ItemAdvice { get; set; }
	}

	[XmlRoot(ElementName = "inventoryInqAdv", Namespace = "http://xml.FIDX.org/xml/schemas/fidxInvInqAdv_v1.3")]

	//[XmlRoot(ElementName = "inventoryInqAdv", Namespace = "http://www.w3.org/2000/xmlns/")]

	public class InventoryInqAdv
	{
		[XmlElement(ElementName = "inquiry", Namespace = "")]
		public Inquiry Inquiry { get; set; }

		[XmlElement(ElementName = "items", Namespace = "")]
		public Items Items { get; set; }

		[XmlAttribute(AttributeName = "fniia", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Fniia { get; set; }
		[XmlAttribute(AttributeName = "fnBase", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string FnBase { get; set; }
		[XmlAttribute(AttributeName = "fnItem", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string FnItem { get; set; }
		[XmlAttribute(AttributeName = "fnParty", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string FnParty { get; set; }
		[XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Xsi { get; set; }
		[XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public string SchemaLocation { get; set; }
	}
}
