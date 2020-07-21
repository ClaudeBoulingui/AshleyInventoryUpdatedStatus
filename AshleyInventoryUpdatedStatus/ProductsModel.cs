using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AshleyInventoryUpdatedStatus
{

    //[AllowAnonymous]
    public partial class Response
    {
        [JsonProperty("links")]
        public Link[] Links { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("entities")]
        public ProductEntity[] Entities { get; set; }
    }

    public partial class ProductEntity
    {
        [JsonProperty("additionalDimensions")]
        public AdditionalDimension[] AdditionalDimensions { get; set; }

        [JsonProperty("assemblyInstructionsUrl", NullValueHandling = NullValueHandling.Ignore)]
        public Uri AssemblyInstructionsUrl { get; set; }

        [JsonProperty("brandName")]
        public string BrandName { get; set; }

        [JsonProperty("cartonDepthInches")]
        public double CartonDepthInches { get; set; }

        [JsonProperty("cartonDepthMm")]
        public double CartonDepthMm { get; set; }

        [JsonProperty("cartonHeightInches")]
        public double CartonHeightInches { get; set; }

        [JsonProperty("cartonHeightMm")]
        public double CartonHeightMm { get; set; }

        [JsonProperty("cartonVolumeCuFeet")]
        public double CartonVolumeCuFeet { get; set; }

        [JsonProperty("cartonVolumeCuMeters")]
        public double CartonVolumeCuMeters { get; set; }

        [JsonProperty("cartonWidthInches")]
        public double CartonWidthInches { get; set; }

        [JsonProperty("cartonWidthMm")]
        public double CartonWidthMm { get; set; }

        [JsonProperty("chairQtyPerCarton")]
        public long ChairQtyPerCarton { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("colorSwatch", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ColorSwatch { get; set; }

        [JsonProperty("covers")]
        public Cover[] Covers { get; set; }

        [JsonProperty("detailedDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string DetailedDescription { get; set; }

        [JsonProperty("fabric", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Fabric { get; set; }

        [JsonProperty("fobBasePrice")]
        public double FobBasePrice { get; set; }

        [JsonProperty("friendlyDescription")]
        public string FriendlyDescription { get; set; }

        [JsonProperty("generalColor", NullValueHandling = NullValueHandling.Ignore)]
        public string[] GeneralColor { get; set; }

        [JsonProperty("harmonizationCode", NullValueHandling = NullValueHandling.Ignore)]
        public string HarmonizationCode { get; set; }

        [JsonProperty("intendedRooms", NullValueHandling = NullValueHandling.Ignore)]
        public string[] IntendedRooms { get; set; }

        [JsonProperty("isExpressShipEligible")]
        public bool IsExpressShipEligible { get; set; }

        [JsonProperty("isSupplierDirectShipOnly")]
        public bool IsSupplierDirectShipOnly { get; set; }

        [JsonProperty("itemClass", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemClass { get; set; }

        [JsonProperty("itemCode")]
        public string ItemCode { get; set; }

        [JsonProperty("itemName")]
        public string ItemName { get; set; }

        [JsonProperty("itemsPerCase")]
        public long ItemsPerCase { get; set; }

        [JsonProperty("itemType")]
        public string ItemType { get; set; }

        [JsonProperty("itemWeightKg")]
        public double ItemWeightKg { get; set; }

        [JsonProperty("itemWeightLbs")]
        public double ItemWeightLbs { get; set; }

        [JsonProperty("isCommodity")]
        public bool IsCommodity { get; set; }

        [JsonProperty("kitIncludes")]
        public KitInclude[] KitIncludes { get; set; }

        [JsonProperty("knockout", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Knockout { get; set; }

        [JsonProperty("largeImageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public Uri LargeImageUrl { get; set; }

        [JsonProperty("links")]
        public Link[] Links { get; set; }

        [JsonProperty("manufacturerWarrantyDays")]
        public long ManufacturerWarrantyDays { get; set; }

        [JsonProperty("material", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Material { get; set; }

        [JsonProperty("mediumImageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public Uri MediumImageUrl { get; set; }

        [JsonProperty("partsDrawingsUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string PartsDrawingsUrl { get; set; }

        [JsonProperty("pattern", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Pattern { get; set; }

        [JsonProperty("productDetails")]
        public string[] ProductDetails { get; set; }

        [JsonProperty("promotionalFlags", NullValueHandling = NullValueHandling.Ignore)]
        public string[] PromotionalFlags { get; set; }

        [JsonProperty("purchaseUnitOfMeasure")]
        public string PurchaseUnitOfMeasure { get; set; }

        [JsonProperty("seatCount")]
        public double SeatCount { get; set; }

        [JsonProperty("seriesId")]
        public string SeriesId { get; set; }

        [JsonProperty("shade", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Shade { get; set; }

        [JsonProperty("shippingWeightKg")]
        public double ShippingWeightKg { get; set; }

        [JsonProperty("shippingWeightLbs")]
        public double ShippingWeightLbs { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusDate", NullValueHandling = NullValueHandling.Ignore)]
        public string StatusDate { get; set; }

        [JsonProperty("marketIntroDates", NullValueHandling = NullValueHandling.Ignore)]
        public string[] MarketIntroDates { get; set; }

        [JsonProperty("unavailableByWarehouse", NullValueHandling = NullValueHandling.Ignore)]
        public string[] UnavailableByWarehouse { get; set; }

        [JsonProperty("unitDepthInches")]
        public double UnitDepthInches { get; set; }

        [JsonProperty("unitDepthMm")]
        public double UnitDepthMm { get; set; }

        [JsonProperty("unitFriendlyDimensionsInches")]
        public string UnitFriendlyDimensionsInches { get; set; }

        [JsonProperty("unitFriendlyDimensionsMm")]
        public long UnitFriendlyDimensionsMm { get; set; }

        [JsonProperty("unitHeightInches")]
        public double UnitHeightInches { get; set; }

        [JsonProperty("unitHeightMm")]
        public double UnitHeightMm { get; set; }

        [JsonProperty("unitWidthInches")]
        public double UnitWidthInches { get; set; }

        [JsonProperty("unitWidthMm")]
        public double UnitWidthMm { get; set; }

        [JsonProperty("upc", NullValueHandling = NullValueHandling.Ignore)]
        public string Upc { get; set; }

        [JsonProperty("upholsteryFeature", NullValueHandling = NullValueHandling.Ignore)]
        public string[] UpholsteryFeature { get; set; }

        [JsonProperty("vendorName")]
        public string VendorName { get; set; }

        [JsonProperty("isExclusive")]
        public bool IsExclusive { get; set; }

        [JsonProperty("retailType")]
        public string RetailType { get; set; }

        [JsonProperty("consumerDescription")]
        public string ConsumerDescription { get; set; }

        [JsonProperty("cartonFreightClass")]
        public double CartonFreightClass { get; set; }

        [JsonProperty("cartonDensity")]
        public double CartonDensity { get; set; }

        [JsonProperty("cartonVolume")]
        public double CartonVolume { get; set; }

        [JsonProperty("diningChair")]
        public bool DiningChair { get; set; }

        [JsonProperty("dimensionsConfirmed")]
        public bool DimensionsConfirmed { get; set; }


        [JsonProperty("instructionsUrl")]
        public string InstructionsUrl { get; set; }

        [JsonProperty("itemCodeKey")]
        public long ItemCodeKey { get; set; }

        [JsonProperty("itemColorKey")]
        public long ItemColorKey { get; set; }

        [JsonProperty("itemSalesCategoryCodeKey")]
        public string ItemSalesCategoryCodeKey { get; set; }

        [JsonProperty("itemRetailTypeKey")]
        public long ItemRetailTypeKey { get; set; }

        [JsonProperty("itemStatusKey")]
        public string ItemStatusKey { get; set; }

        [JsonProperty("itemUomKey")]
        public string ItemUomKey { get; set; }

        [JsonProperty("itemLifestyleKey", NullValueHandling = NullValueHandling.Ignore)]
        public string[] ItemLifestyleKey { get; set; }

        [JsonProperty("itemARVRReady")]
        public string ItemArvrReady { get; set; }

        [JsonProperty("itemGeneralLongDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemGeneralLongDescription { get; set; }

        [JsonProperty("itemIntroFeatures", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemIntroFeatures { get; set; }

        [JsonProperty("itemGeneralDescriptionID", NullValueHandling = NullValueHandling.Ignore)]
        public long? ItemGeneralDescriptionId { get; set; }

        [JsonProperty("itemSeriesName")]
        public string ItemSeriesName { get; set; }

        [JsonProperty("itemSellingCountries", NullValueHandling = NullValueHandling.Ignore)]
        public string[] ItemSellingCountries { get; set; }

        [JsonProperty("itemSellingCountriesKey", NullValueHandling = NullValueHandling.Ignore)]
        public string[] ItemSellingCountriesKey { get; set; }

        [JsonProperty("thirdParty")]
        public bool ThirdParty { get; set; }

        [JsonProperty("navigableCategories")]
        public string[] NavigableCategories { get; set; }

        [JsonProperty("lastModifiedDateTime")]
        public DateTimeOffset LastModifiedDateTime { get; set; }

        [JsonProperty("itemClassKey", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemClassKey { get; set; }

        [JsonProperty("isPalletizable")]
        public bool IsPalletizable { get; set; }

        [JsonProperty("shippableUOM", NullValueHandling = NullValueHandling.Ignore)]
        public string ShippableUom { get; set; }

        [JsonProperty("marxentPIDNumber")]
        public string MarxentPidNumber { get; set; }

        [JsonProperty("imageSet", NullValueHandling = NullValueHandling.Ignore)]
        public ImageSet[] ImageSet { get; set; }

        [JsonProperty("itemRoomImage", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ItemRoomImage { get; set; }

        [JsonProperty("lifestyle", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Lifestyle { get; set; }

        [JsonProperty("seriesRetailSalesCategoryKey", NullValueHandling = NullValueHandling.Ignore)]
        public long? SeriesRetailSalesCategoryKey { get; set; }

        [JsonProperty("seriesFeatures", NullValueHandling = NullValueHandling.Ignore)]
        public string SeriesFeatures { get; set; }

        [JsonProperty("seriesFluff", NullValueHandling = NullValueHandling.Ignore)]
        public string SeriesFluff { get; set; }

        [JsonProperty("seriesShowroom", NullValueHandling = NullValueHandling.Ignore)]
        public string SeriesShowroom { get; set; }

        [JsonProperty("seriesExclusiveComment", NullValueHandling = NullValueHandling.Ignore)]
        public string SeriesExclusiveComment { get; set; }

        [JsonProperty("frameSize", NullValueHandling = NullValueHandling.Ignore)]
        public string[] FrameSize { get; set; }

        [JsonProperty("numberofPieces", NullValueHandling = NullValueHandling.Ignore)]
        public string NumberofPieces { get; set; }

        [JsonProperty("shape", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Shape { get; set; }

        [JsonProperty("microsites", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Microsites { get; set; }

        [JsonProperty("consumerAssembly", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsumerAssembly { get; set; }

        [JsonProperty("dimensionSketch", NullValueHandling = NullValueHandling.Ignore)]
        public Uri DimensionSketch { get; set; }

        [JsonProperty("marketingTheme", NullValueHandling = NullValueHandling.Ignore)]
        public string[] MarketingTheme { get; set; }

        [JsonProperty("lastModifiedFields", NullValueHandling = NullValueHandling.Ignore)]
        public string[] LastModifiedFields { get; set; }

        [JsonProperty("childComponentQuantity", NullValueHandling = NullValueHandling.Ignore)]
        public string ChildComponentQuantity { get; set; }

        [JsonProperty("numberofDrawers", NullValueHandling = NullValueHandling.Ignore)]
        public string NumberofDrawers { get; set; }

        [JsonProperty("productVideo", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ProductVideo { get; set; }

        [JsonProperty("lampHeight", NullValueHandling = NullValueHandling.Ignore)]
        public string LampHeight { get; set; }

        [JsonProperty("lampType", NullValueHandling = NullValueHandling.Ignore)]
        public string[] LampType { get; set; }

        [JsonProperty("specialFeature", NullValueHandling = NullValueHandling.Ignore)]
        public string[] SpecialFeature { get; set; }

        [JsonProperty("assemblyVideo1", NullValueHandling = NullValueHandling.Ignore)]
        public Uri AssemblyVideo1 { get; set; }

        [JsonProperty("deskClassification", NullValueHandling = NullValueHandling.Ignore)]
        public string[] DeskClassification { get; set; }

        [JsonProperty("benchOfficeChairSeating", NullValueHandling = NullValueHandling.Ignore)]
        public string BenchOfficeChairSeating { get; set; }

        [JsonProperty("officeChair", NullValueHandling = NullValueHandling.Ignore)]
        public string[] OfficeChair { get; set; }

        [JsonProperty("assemblyVideo2", NullValueHandling = NullValueHandling.Ignore)]
        public Uri AssemblyVideo2 { get; set; }

        [JsonProperty("numberofDoors", NullValueHandling = NullValueHandling.Ignore)]
        public string NumberofDoors { get; set; }

        [JsonProperty("numberofShelves", NullValueHandling = NullValueHandling.Ignore)]
        public string NumberofShelves { get; set; }

        [JsonProperty("barstoolSpecialFeature", NullValueHandling = NullValueHandling.Ignore)]
        public string[] BarstoolSpecialFeature { get; set; }

        [JsonProperty("throwFabricType", NullValueHandling = NullValueHandling.Ignore)]
        public string[] ThrowFabricType { get; set; }

        [JsonProperty("diningSeating", NullValueHandling = NullValueHandling.Ignore)]
        public string[] DiningSeating { get; set; }

        [JsonProperty("itemExclusiveComment", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemExclusiveComment { get; set; }
    }

    public partial class AdditionalDimension
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("alternateDimensionMm")]
        public double AlternateDimensionMm { get; set; }

        [JsonProperty("alternateDimensionInches")]
        public double AlternateDimensionInches { get; set; }

        [JsonProperty("widthMm")]
        public double WidthMm { get; set; }

        [JsonProperty("widthInches")]
        public double WidthInches { get; set; }

        [JsonProperty("heightMm")]
        public double HeightMm { get; set; }

        [JsonProperty("heightInches")]
        public double HeightInches { get; set; }

        [JsonProperty("depthMm")]
        public double DepthMm { get; set; }

        [JsonProperty("depthInches")]
        public double DepthInches { get; set; }
    }

    public partial class Cover
    {
        [JsonProperty("itemNumber")]
        public string ItemNumber { get; set; }

        [JsonProperty("cleaningCode")]
        public string CleaningCode { get; set; }

        [JsonProperty("cleaningCodeDescription")]
        public string CleaningCodeDescription { get; set; }

        [JsonProperty("contents")]
        public Content[] Contents { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("percentageMakeup")]
        public string PercentageMakeup { get; set; }
    }

    public partial class Content
    {
        [JsonProperty("contentTypeDescription")]
        public string ContentTypeDescription { get; set; }

        [JsonProperty("percentage")]

        public long Percentage { get; set; }
    }

    public partial class ImageSet
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }
    }

    public partial class KitInclude
    {
        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }
    }

    public partial class Link
    {
        [JsonProperty("rel")]
        public string Rel { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public partial class Metadata
    {
        [JsonProperty("totalRecords")]

        public long TotalRecords { get; set; }

        [JsonProperty("currentPageRecords")]
        public long CurrentPageRecords { get; set; }
    }
}
