using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace AshleyInventoryUpdatedStatus
{
    class AshleyConfiguration
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ApiKey { get; set; }
        public int PageSize { get; set; }
        public string PricesURL { get; set; }
        public string ProductsURL { get; set; }
        public string ProductURL { get; set; }
        public string FailureEmail { get; set; }
        public int MaxRetryCount { get; set; }
    }


    //public partial class Link
    //{
    //    public string rel { get; set; }
    //    public string href { get; set; }
    //}



    public class RootObject
    {
        public List<Link> links { get; set; }

        public Metadata metadata { get; set; }

        public List<ProductEntity> entities { get; set; }

    }









    class AllProducts
    {


        //public static List<Product> GetProductStatuses(string customerNumber, AshleyConfiguration configuration, ref string messages, ref string errors)
        public static List<ProductEntity> GetProductStatuses(string customerNumber, AshleyConfiguration configuration, ref string messages, ref string errors)
        {
            errors = "";
            messages = "";


            List<ProductEntity> productList = new List<ProductEntity>();
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", configuration.UserName, configuration.Password))));
                client.DefaultRequestHeaders.Add("client_id", configuration.ApiKey);
                client.Timeout = TimeSpan.FromMinutes(30);

                //Page 1 get first 10 records
                string firstPageURL = string.Format(configuration.ProductsURL, 0, 500, customerNumber);
                var taskFirstPage = client.GetStringAsync(firstPageURL);
                RootObject firstPageRoot = JsonConvert.DeserializeObject<RootObject>(taskFirstPage.Result);

                //int recordCount = firstPageRoot.metadata.totalRecords;
                long recordCount = firstPageRoot.metadata.TotalRecords;

                long pageCount = recordCount / configuration.PageSize;
                if (recordCount % configuration.PageSize > 0)
                {
                    pageCount++;
                }

                Serilog.Log.Information("Total Records: " + recordCount.ToString() + " Pages: " + pageCount.ToString());

                for (int pageNumber = 1; pageNumber <= pageCount; pageNumber++)
                {
                    Console.WriteLine($"Product Page : {pageNumber} out of {pageCount}");
                    int retryCount = 1;
                    string wholesaleURL = string.Format(configuration.ProductsURL, pageNumber, configuration.PageSize, customerNumber);

                    while (retryCount <= configuration.MaxRetryCount)
                    {

                        try
                        {
                            Serilog.Log.Information("Fetching " + pageNumber.ToString());

                            var taskWholesale = client.GetStringAsync(wholesaleURL);

                            RootObject root = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(taskWholesale.Result);

                            foreach (var entity in root.entities)
                            {
                                //productList.Add(new Product { sku = entity.sku, status = entity.status, isExpressShipEligible = entity.isExpressShipEligible });
                                productList.Add(new ProductEntity
                                {
                                    SeriesId = entity.SeriesId,
                                    Sku = entity.Sku,
                                    Status = entity.Status,
                                    SeriesFeatures = entity.SeriesFeatures,
                                    BrandName = entity.BrandName,
                                    ItemCode = entity.ItemCode,
                                    Upc = entity.Upc,
                                    ItemGeneralLongDescription = entity.ItemGeneralLongDescription,
                                    DetailedDescription = entity.DetailedDescription,
                                    FobBasePrice = entity.FobBasePrice,
                                    FriendlyDescription = entity.FriendlyDescription,
                                    ItemSeriesName = entity.ItemSeriesName,
                                    NumberofDoors = entity.NumberofDoors,
                                    NumberofDrawers = entity.NumberofDrawers,
                                    NumberofShelves = entity.NumberofShelves,
                                    ItemWeightLbs = entity.ItemWeightLbs,
                                    ItemType = entity.ItemType,
                                    Color = entity.Color,
                                    Material = entity.Material,
                                    Lifestyle = entity.Lifestyle,
                                    ConsumerDescription = entity.ConsumerDescription,
                                    ProductDetails = entity.ProductDetails,
                                    AdditionalDimensions = entity.AdditionalDimensions,

                                    KitIncludes = entity.KitIncludes,
                                    IsExpressShipEligible = entity.IsExpressShipEligible,
                                    AssemblyInstructionsUrl = entity.AssemblyInstructionsUrl,
                                    InstructionsUrl = entity.InstructionsUrl,
                                    PartsDrawingsUrl = entity.PartsDrawingsUrl
                                });
                            }

                            break;
                        }
                        catch (Exception ex)
                        {
                            //string errorMessage = "GetProductStatuses Page (" + wholesaleURL + ") " + pageNumber.ToString() + " for " + customerNumber + "-" + ex.GetExceptionMessageSummary();

                            string errorMessage = "GetProductStatuses Page (" + wholesaleURL + ") " + pageNumber.ToString() + " for " + customerNumber + "-" + ex.GetBaseException();
                            messages = messages + "\n" + errorMessage;
                            Serilog.Log.Error(errorMessage);

                            retryCount++;
                        }
                    }
                    if (retryCount > configuration.MaxRetryCount)
                    {
                        string errorMessage = "Max Retry Count reached - " + wholesaleURL;
                        errors = errors + "\n" + errorMessage;
                        Serilog.Log.Error(errorMessage);
                    }
                }

                if (recordCount != productList.Count())
                {
                    string errorMessage = "Expected Record Count =" + recordCount + " does not match Actual Record Count = " + productList.Count().ToString();
                    errors = errors + "\n" + errorMessage;
                    Serilog.Log.Error(errorMessage);
                }
            }
            catch (Exception ex)
            {
                //string errorMessage = "GetProductStatuses for " + customerNumber + "-" + ex.GetExceptionMessageSummary();

                string errorMessage = "GetProductStatuses for " + customerNumber + "-" + ex.GetBaseException();
                errors = errors + "\n" + errorMessage;
                Serilog.Log.Error(errorMessage);
            }

            return productList;
        }

    }
}
