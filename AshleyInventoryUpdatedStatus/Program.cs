using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.ServiceModel;



namespace AshleyInventoryUpdatedStatus
{
    class Program
    {

        static string previousSku = null;


        public const char BOMChar = (char)65279;

        public static bool FixBOMIfNeeded(ref string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            bool hasBom = str[0] == BOMChar;
            if (hasBom)
                str = str.Substring(1);

            return hasBom;
        }






        public static HashSet<string> ReadExcelFileWithListOfItems(string FilePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            HashSet<string> listOfItems = new HashSet<string>();

            FileInfo existingFile = new FileInfo(FilePath);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {

                string valueInCurrentLine = null;
                string memberName = null;

                //get the first worksheet in the workbook
                var firstWorksheet = package.Workbook.Worksheets.First();

                //  ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                int colCount = firstWorksheet.Dimension.End.Column;  //get Column Count
                int rowCount = firstWorksheet.Dimension.End.Row;     //get row count


                int col = 1;
                for (int row = 1; row <= rowCount; row++)
                {

                    if (row > 1)
                    {


                        if (!string.IsNullOrEmpty(valueInCurrentLine = firstWorksheet.Cells[row, col].Text.ToString()))
                        {


                            memberName = firstWorksheet.Cells[row, col].Value.ToString();

                            listOfItems.Add(memberName);

                        }

                        //   


                    }

                }

            }

            return listOfItems;
        }


        public static XmlDocument UpdateCustomerData(XmlDocument xmlRequest, string item, string shipToLocation)

        //  public static XmlDocument UpdateCustomerData(string item, string shipToLocation)

        //  public static List<XmlDocument> updateCustomerNumber(XmlDocument xmlRequest)
        {


            //this one works well with keeping the correct store number
            //xmlRequest.Load(@"C:\Users\cboulingui\Desktop\Ashley_Response_For_Inventory\AshleyInventoryInquiryTemplate.xml");






            List<XmlDocument> listOfAllXmlDocuments = new List<XmlDocument>();

            XmlNamespaceManager manager = new XmlNamespaceManager(xmlRequest.NameTable);

            manager.AddNamespace("fnParty", "http://support.furnishnet.com/xml/schemas/fnParty_v1.4");




            //-----Updating the customer number-----//
            XmlAttribute customerNumber = (XmlAttribute)xmlRequest.SelectSingleNode("//fnParty:partyIdentifier/@partyIdentifierCode", manager);
            if (customerNumber != null)
            {
                customerNumber.Value = "967600"; // Set to new Ashley Customer Number value -- Big Sandy
            }


            //-----Updating the ship-to number-----//
            var potentialShipToElement = xmlRequest.SelectSingleNode("//potentialShipTo", manager);
            var lastNode = potentialShipToElement.LastChild;
            var currentElement = lastNode.OuterXml;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(currentElement);

            var xdoc = xmlDoc.DocumentElement;




            // XmlAttribute shipToNumber = (XmlAttribute)xdoc.SelectSingleNode("//fnParty:partyIdentifier/@partyIdentifierCode", manager);
            //// XmlAttribute shipToNumber = (XmlAttribute)xdoc.SelectSingleNode("//fnParty:partyIdentifier/[@partyIdentifierCode='01']", manager);
            // if (shipToNumber != null)
            // {
            //     string currentShipToLocation = shipToLocation.ToString();
            //       shipToNumber.Value = "03"; // Set Ship-To Number to a new value 
            //    // shipToNumber["partyIdentifierCode"].Value = "03";
            // }







            var nodeShipToList = xmlRequest.GetElementsByTagName("fnParty:partyIdentifier");
            ////-----Updating first Item-----//

            var firstShipToNode = nodeShipToList[1];

            if (shipToLocation == "01")
            {

                if (firstShipToNode.Attributes["partyIdentifierCode"].Value.Equals(""))//initial value from the XML template file
                {
                    //Update this item-Lvl1 when looking for its inventory
                    firstShipToNode.Attributes["partyIdentifierCode"].LastChild.Value = "01";// shipToLocation.ToString();//"1050160";  //1080329: this value works fine!!  value = -1   6/26/2020  

                }

            }


            if (shipToLocation == "02")
            {

                // if (firstShipToNode.Attributes["partyIdentifierCode"].Value.Equals("01")  && firstShipToNode.Attributes["partyIdentifierCode"].Value.Equals(""))//initial value from the XML template file

                if (firstShipToNode.Attributes["partyIdentifierCode"].Value.Equals(""))//initial value from the XML template file
                {
                    //Update this item-Lvl1 when looking for its inventory
                    firstShipToNode.Attributes["partyIdentifierCode"].LastChild.Value = "02";// shipToLocation.ToString();//"1050160";  //1080329: this value works fine!!  value = -1   6/26/2020  

                }

            }






            //---------------------------------------------------------------------------------------------------------
            //---------------------------------------------------------------------------------------------------------





            //int i = 0;



            var nodeList = xmlRequest.GetElementsByTagName("itemIdentifier");
            ////-----Updating first Item-----//

            //var firstItemNode = nodeList[0];

            //if (firstItemNode.Attributes["itemNumber"].Value.Equals("D44-50B"))//initial value from the XML template file
            //{
            //    //Update this item-Lvl1 when looking for its inventory
            //    firstItemNode.Attributes["itemNumber"].LastChild.Value = item;//"1050160";  //1080329: this value works fine!!  value = -1   6/26/2020  

            //}



            ////-----Updating Second Item-----//  
            ///

            //var secondItemNode = nodeList[1];

            //if (secondItemNode.Attributes["itemNumber"].Value.Equals("B47-57"))//initial value from the XML template file
            //{

            //    secondItemNode.Attributes["itemNumber"].LastChild.Value = item;// "1050160";  
            //}


            //////-----Updating Third Item-----//          
            //var thirdItemNode = nodeList[2];

            //if (thirdItemNode.Attributes["itemNumber"].Value.Equals("6050389"))//initial value from the XML template file
            //{

            //    thirdItemNode.Attributes["itemNumber"].LastChild.Value = item;// "1050160"; 
            //}



            //////-----Updating Fourth Item-----//          
            //var fourthItemNode = nodeList[3];

            //if (fourthItemNode.Attributes["itemNumber"].Value.Equals("B219-BED"))//initial value from the XML template file
            //{

            //    fourthItemNode.Attributes["itemNumber"].LastChild.Value = item;// "1050160";  
            //}



            return xmlRequest;




        }






        //public static void GenerateXMLFiles(List<ProductEntity> listOfProducts, string shipToNumber)
        //   public static void GenerateXMLFiles(List<string> listOfProducts, string shipToNumber)

        //public static void GenerateXMLFiles(XmlDocument xmlRequest, List<string> listOfProducts, string shipToNumber)

        //public static void GenerateXMLFiles(XmlDocument xmlRequest,string sku, string shipToNumber)

        public static void GenerateXMLFiles(XmlDocument xmlRequest, string sku, string shipToNumber)
        {


            Console.WriteLine("Starting the program...");

            string externalID = "AVBMarketing";
            string KeyCode = "FbEGyEwjLfwvriJn2pjh1Q==";
            string sUser = "AD_AVB";
            string sPassword = "DF0BY01HI9kA!!!!!!!";



            ///  var xmlRequest = new System.Xml.XmlDocument();
            var sReturnValue = string.Empty;


            //===================================================             
            //Insert code here to build XML request transaction              
            //Example: xmlRequest.Load("C:\ATP\InventoryStatusExample.xml");    

            //xmlRequest.Load(@"C:\Users\cboulingui\Desktop\Ashley_Response_For_Inventory\AshInvStatus.xml");
            //=================================================== 


            //Path to the Excel file containing the list of items
            //    string FilePath = @"C:\Users\cboulingui\source\repos\AshleyInventoryLookUp\BigSandyItemListOf06252020.xlsx";

            //  var listOfItemsOfBigSandy = ReadExcelFileWithListOfItems(FilePath);


            ////return the list of SKUs of the current customer
            //var listOfISkusOfCurrentCustomer = listOfProducts.Select(d => d.Sku).Distinct().ToList();

            //   string item = "1200036";

            //  string shipToNumber = null;


            //  int totalTransCount = 3093;  //total number if items (SKUs)in the Excel file
            int currentBatchCount = 0;
            int amountPerBatch = 248;// 216 took 3h59:32;  //54 =>1k in 15 min    //42 forces application to exit  at 20k!!  -- Try not to let application sleep.



            AshleyATP.ATPServiceSoapClient wsATP = new AshleyATP.ATPServiceSoapClient();

            try
            {
                //this one works well with keeping the correct store number
                // xmlRequest.Load(@"C:\Users\cboulingui\Desktop\Ashley_Response_For_Inventory\AshleyInventoryInquiryTemplate.xml");





                //foreach (var sku in listOfProducts.Take(4))
                //{

                // var sku = "6610306";

                // currentBatchCount++;

                //string sku = item.Sku;


                //below line does not keep the correct store number--- should be removed from here!!!!
                //  xmlRequest.Load(@"C:\Users\cboulingui\Desktop\Ashley_Response_For_Inventory\AshleyInventoryInquiryTemplate.xml");





                // for (int k = 0; k <= 2; k++)
                // {

                currentBatchCount++;

                //if (k == 0)
                //    shipToNumber = "";
                //if (k == 1)
                //    shipToNumber = "01";
                //if (k == 2)
                //    shipToNumber = "02";

                //  var xmlRequestModified = UpdateCustomerData(sku, shipToNumber);

                var xmlRequestModified = UpdateCustomerData(xmlRequest, sku, shipToNumber);

                // var listOfModifiedXmlRequest = updateCustomerNumber(xmlRequest);



                //Get the OuterXml from the modified xmlRequest
                var sXMLRequest = xmlRequestModified.OuterXml;

                //Get the OuterXml from the document             
                // var sXMLRequest = xmlRequest.OuterXml;







                if (currentBatchCount == amountPerBatch)//if the amount per batch is reached...
                {
                    currentBatchCount = 0;
                    wsATP.Close();

                    wsATP = new AshleyATP.ATPServiceSoapClient();

                    try
                    {

                        //Make the webservice call                 
                        sReturnValue = wsATP.ATPRequest(externalID, KeyCode, sUser, sPassword, sXMLRequest);
                    }
                    catch (FaultException ex)
                    {
                        Console.WriteLine(ex.Message);


                    }

                }
                else if (currentBatchCount < amountPerBatch)
                {

                    try
                    {

                        //Make the webservice call                 
                        sReturnValue = wsATP.ATPRequest(externalID, KeyCode, sUser, sPassword, sXMLRequest);
                    }
                    catch (FaultException ex)
                    {
                        Console.WriteLine(ex.Message);


                    }

                }









                if (!String.IsNullOrEmpty(sReturnValue))
                {

                    //Load return XML into a document             
                    var xmlResponse = new System.Xml.XmlDocument();
                    xmlResponse.LoadXml(sReturnValue);

                    //============================================             
                    //Insert code here to parse the XML response              
                    //============================================ 

                    //Use the two lines below to take care of the exception: Data at the root level is invalid
                    bool hadBOM = FixBOMIfNeeded(ref sReturnValue);

                    var xElem = System.Xml.Linq.XElement.Parse(sReturnValue); // 


                    Console.WriteLine();
                    var xmlResponse2 = new System.Xml.XmlDocument();
                    xmlResponse2.LoadXml(sReturnValue);




                    XmlReader rdr = XmlReader.Create(new StringReader(xElem.ToString()));
                    while (rdr.Read())
                    {


                        if (rdr.NodeType == XmlNodeType.Element)
                        {
                            //Console.WriteLine("Local Name: " + rdr.LocalName + "," + " Name: " + rdr.Name + "," + " Value: " + rdr.Value);
                            string elementName = rdr.Name;
                            if (rdr.HasAttributes)
                            {

                                for (int i = 0; i < rdr.AttributeCount; i++)
                                {
                                    rdr.MoveToAttribute(i);
                                    Console.Write("Element Name: " + elementName + " ");
                                    Console.WriteLine(" {0}={1}", rdr.Name, rdr.Value);
                                    Console.WriteLine();

                                }
                                rdr.MoveToElement(); //Moves the reader back to the element node
                            }
                        }
                    }



                    //Path to store the XML files that are generated
                    string GeneratedPath = @"C:\Users\cboulingui\source\repos\AshleyInventoryLookUp\XMLGenerated\" + sku + "_" + shipToNumber + ".xml";

                    xElem.Save(GeneratedPath);

                    Console.WriteLine("**********");
                    Console.WriteLine("*****  New Status Advice*****");

                }

                //  }  //end for loop




                /// }//end loop listOfItemsOfCurrentCustomer


            }

            finally
            {
                if (wsATP.State == CommunicationState.Faulted)
                {
                    wsATP.Abort();
                    wsATP = new AshleyATP.ATPServiceSoapClient();
                }
                else
                    wsATP.Close();
            }
        }








        public static T DeserializeFromFile<T>(string xmlFilePath) where T : class
        {
            using (var reader = XmlReader.Create(xmlFilePath))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

                return (T)serializer.Deserialize(reader);
            }
        }




        public static void ReadXMLFiles()
        {


            Console.WriteLine();
            Console.WriteLine("Mergin all XML files into one file...");

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;



            using (ExcelPackage excel = new ExcelPackage())
            {

                //Create the header of the Excel Worksheet
                List<string[]> headerRow = new List<string[]>()
                {
                  new string[] { "document id", "Type", "Purpose", "Creation Date", "Creation Time", "Original Document Id", "Original Document Type", "Original Creation Date", "Original Creation Time", "Potential Buyer Customer Number", "Potential Ship To Store code", "Potential Seller(Ashley DUNS Id)", "Party identifier Qualifier Code", "Line Item number#1", "Item Number(SKU)", "Item Availability", "Unit of Measure","Quantity available for immediate shipment", "Available date", "System Reference Description", "number of days to ship product to customer's location", "Line Item number#2", "Item Number(SKU)", "Item Availability", "Unit of measure", "Quantity available for shipment on the date","First date the requested quantity is available for shipment", "system Reference Description",  "number of days to ship product to customer's location", "Line Item number#3", "Item Number (SKU)", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment(Today)", "Available Date", "System Reference Description", "number of days to ship product to customer's location",  "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product", "Item Availability to customer's location", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product", "Item Availability to customer's location", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location",  "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Item Availability", "Unit of Measure", "Quantity available for immediate shipment", "Available Date", "System Reference Description", "number of days to ship product to customer's location", "Line Item number#4" }
                };

                int m = 2;

                //create a worksheet and give it the name "MergedWorksheet"
                excel.Workbook.Worksheets.Add("StatusAdvice");

                //Add a header on the worksheet "MergedWorksheet"
                //string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

                //// Target the "StatusAdvice" worksheet to receive the data from all the worksheets
                var worksheetOne = excel.Workbook.Worksheets["StatusAdvice"];




                // Determine the header range (e.g. A1:E1)
                var headerRange = worksheetOne.Cells[1, 1, 1, 280];//format: ws.Cells[int FromRow, int FromCol, int ToRow, int ToCol]
                {
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.ShrinkToFit = false;
                    headerRange.Style.Font.Size = 13;
                    headerRange.Style.Font.Color.SetColor(System.Drawing.Color.Blue);
                    headerRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    //  headerRange.Style.ShrinkToFit = ExcelStyle.Equals;

                    // headerRange.AutoFilter = true;
                }



                // Populate header row data
                worksheetOne.Cells[headerRange.ToString()].LoadFromArrays(headerRow);

                //Autofit every column
                worksheetOne.Cells[worksheetOne.Dimension.Address].AutoFitColumns();



                // Create an instance of the XmlSerializer.
                System.Xml.Serialization.XmlSerializer serializer = new XmlSerializer(typeof(InventoryInqAdv));

                // Declare an object variable of the type to be deserialized.
                InventoryInqAdv info;


                string targetDirectory = @"C:\Users\cboulingui\source\repos\AshleyInventoryLookUp\XMLGenerated";


                // Process the list of files found in the directory.
                string[] fileEntries = Directory.GetFiles(targetDirectory);

                int row = 2;
                int col = 1;

                foreach (string fileName in fileEntries)
                {

                    using (Stream reader = new FileStream(fileName, FileMode.Open))
                    {
                        // Call the Deserialize method to restore the object's state.
                        info = (InventoryInqAdv)serializer.Deserialize(reader);
                    }





                    int maxRowOfProductSku = 0;

                    int trackingRowWithProductId = row;

                    //**************************Store data in workshee One**********************************




                    string currentDocumentId = info.Inquiry.Document.Id;
                    worksheetOne.Cells[row, col].Value = currentDocumentId;

                    string currentDocumentType = info.Inquiry.Document.Type;
                    col++;
                    worksheetOne.Cells[row, col].Value = currentDocumentType;


                    string currentPurpose = info.Inquiry.Document.Purpose;
                    col++;
                    worksheetOne.Cells[row, col].Value = currentPurpose;


                    string currentDocumentCreationDate = info.Inquiry.Document.CreationDate;
                    col++;
                    worksheetOne.Cells[row, col].Value = currentDocumentCreationDate;


                    string currentCreationTime = info.Inquiry.Document.CreationTime;
                    col++;
                    worksheetOne.Cells[row, col].Value = currentCreationTime;


                    string currentOriginalDocumentId = info.Inquiry.OriginalDocument.Id;
                    col++;
                    worksheetOne.Cells[row, col].Value = currentOriginalDocumentId;


                    string currentOriginalDocumentType = info.Inquiry.OriginalDocument.Type;
                    col++;
                    worksheetOne.Cells[row, col].Value = currentOriginalDocumentType;




                    string currentOriginalDocumentCreationDate = info.Inquiry.OriginalDocument.CreationDate;
                    col++;
                    worksheetOne.Cells[row, col].Value = currentOriginalDocumentCreationDate;


                    string currentOriginalDocumentCreationTime = info.Inquiry.OriginalDocument.CreationTime;
                    col++;
                    worksheetOne.Cells[row, col].Value = currentOriginalDocumentCreationTime;



                    string currentPotentialBuyerCustomerNumber = info.Inquiry.PotentialBuyer.PartyIdentifier.PartyIdentifierCode;
                    col++;
                    worksheetOne.Cells[row, col].Value = currentPotentialBuyerCustomerNumber;


                    string currentPotentialShipToLocation = info.Inquiry.PotentialShipTo.PartyIdentifier.PartyIdentifierCode;
                    col++;
                    worksheetOne.Cells[row, col].Value = currentPotentialShipToLocation;


                    string currentAshleyDUNSNId = info.Inquiry.PotentialSeller.PartyIdentifier.PartyIdentifierCode;
                    col++;
                    worksheetOne.Cells[row, col].Value = currentAshleyDUNSNId;


                    string currentAshleyQualifierCode = info.Inquiry.PotentialSeller.PartyIdentifier.PartyIdentifierQualifierCode;
                    col++;
                    worksheetOne.Cells[row, col].Value = currentAshleyQualifierCode;


                    var listOfItemAdvice = info.Items.ItemAdvice;


                    foreach (var itemAdvice in listOfItemAdvice)
                    {


                        string currentLineItemNumber = itemAdvice.LineItemNumber;
                        col++;
                        worksheetOne.Cells[row, col].Value = currentLineItemNumber;

                        if (itemAdvice.LineItemNumber != "4")
                        {

                            string currentItemNumber = itemAdvice.ItemId.ItemIdentifier.ItemNumber;
                            col++;
                            worksheetOne.Cells[row, col].Value = currentItemNumber;


                            var listOfItemAvailability = itemAdvice.ItemAvailability;

                            foreach (var itemAvailability in listOfItemAvailability)
                            {

                                string currentAvailability = itemAvailability.Availability;
                                col++;
                                worksheetOne.Cells[row, col].Value = currentAvailability;


                                string currentUnitOfMeasure = itemAvailability.AvailQty.UnitOfMeasure;
                                col++;
                                worksheetOne.Cells[row, col].Value = currentUnitOfMeasure;



                                //Quantity available for shipment on the date
                                string currentAvailableQuantity = itemAvailability.AvailQty.Value;
                                col++;
                                worksheetOne.Cells[row, col].Value = currentAvailableQuantity;


                                if (!String.IsNullOrEmpty(itemAvailability.AvailDate))
                                {
                                    string currentAvailableDate = itemAvailability.AvailDate;
                                    col++;
                                    worksheetOne.Cells[row, col].Value = currentAvailableDate;

                                }
                                else
                                    col++;

                                string currentSystemReferenceDescription = itemAvailability.AvailSystemReference.SystemReferenceDescription;
                                col++;
                                worksheetOne.Cells[row, col].Value = currentSystemReferenceDescription;



                                string currentSystemReferenceValue = itemAvailability.AvailSystemReference.SystemReferenceValue;
                                col++;
                                worksheetOne.Cells[row, col].Value = currentSystemReferenceValue;

                            }


                        }
                        else
                        {
                            col = 578;
                            string currentItemNumber = itemAdvice.ItemId.ItemIdentifier.ItemNumber;
                            col++;
                            worksheetOne.Cells[row, col].Value = currentItemNumber;

                        }


                    }






                    row++;
                    col = 1;

                }

                string excelFileName = "StatusOfAllItems";

                FileInfo excelFile = new FileInfo(@"C:\Users\cboulingui\source\repos\AshleyInventoryLookUp\ExcelGenerated\" + excelFileName + ".xlsx");


                excel.SaveAs(excelFile);



                Console.WriteLine("Merging completed...");

            }
        }








        public static List<string> readXLSThatContainsAllAshleyMembers(string FilePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;


            //Dictionary<string, string> dictionaryOfSkuToMap = new Dictionary<string, string>();

            //Dictionary<string, string> dictionaryOfSkuToMap1 = new Dictionary<string, string>();

            //Dictionary<string, string> dictionaryOfSkuToMap2 = new Dictionary<string, string>();


            List<string> allAshleyCustomerNumbers = new List<string>();

            FileInfo existingFile = new FileInfo(FilePath);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {

                string sku = null;
                string brandName = null;
                string customerNumber = null;

                //get the first worksheet in the workbook
                var firstWorksheet = package.Workbook.Worksheets.First();

                //  ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                int colCount = firstWorksheet.Dimension.End.Column;  //get Column Count
                int rowCount = firstWorksheet.Dimension.End.Row;     //get row count
                for (int row = 2; row <= rowCount; row++)
                {
                    // for (int col = 1; col <= colCount; col++)
                    // {
                    // Console.WriteLine(" Row:" + row + " column:" + col + " Value:" + firstWorksheet.Cells[row, col].Value.ToString().Trim());

                    //  if (row > 1 && col > 0)
                    // {
                    //  sku = firstWorksheet.Cells[row, col].Value.ToString().Trim();
                    //  brandName = firstWorksheet.Cells[row, col + 1].Value.ToString().Trim();
                    customerNumber = firstWorksheet.Cells[row, 4].Value.ToString().Trim();
                    allAshleyCustomerNumbers.Add(customerNumber);



                    ////these if statements are used just to remove duplicates
                    //if (!dictionaryOfSkuToMap.ContainsKey(sku))
                    //    dictionaryOfSkuToMap.Add(sku, brandName);

                    //else if (!dictionaryOfSkuToMap1.ContainsKey(sku))
                    //    dictionaryOfSkuToMap1.Add(sku, brandName);

                    //else if (!dictionaryOfSkuToMap2.ContainsKey(sku))
                    //    dictionaryOfSkuToMap2.Add(sku, brandName);
                    //   col++;
                    //  }

                    // }
                }
            }

            //  return dictionaryOfSkuToMap;

            return allAshleyCustomerNumbers;
        }




        static async Task Main(string[] args)
        {


            //***************start initiating stopwatch******************//
            System.Diagnostics.Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            //**************End initiating stopwatch ***********************//


            string pathToXLFileWithListOfCustomerNumbers = @"C:\Users\cboulingui\source\repos\ExtractAshleyFeed\CustomerNumbers\AshleyAllCustomerNumbers.xlsx";
            List<string> listOfAllCustomerNumbers = readXLSThatContainsAllAshleyMembers(pathToXLFileWithListOfCustomerNumbers);





            string customerNumber = "967600"; //;"3416700";

            // string customerNumber = "";

            //Note: For all Ashley Products, add comments on the PricesURL and comment out the line containing List<Entity> listOfAllPricesOfCurrentMemberId = AllPrices.GetProductPrices(customerNumber, configuration, ref messages, ref errors);

            // foreach (var currentCustomerNumber in listOfAllCustomerNumbers)
            // {
            // string customerNumber = currentCustomerNumber;// "1655000";

            AshleyConfiguration configuration = new AshleyConfiguration
            {
                UserName = "AD_AVB",
                Password = "DF0BY01HI9kA!!!!!!!",
                ProductsURL = "https://apigw3.ashleyfurniture.com/productinformation/products?customer={2}&page={0}&limit={1}",  //this and the below line should be used only when the  customer number is provided

                //  PricesURL = "https://apigw3.ashleyfurniture.com/productinformation/prices/?customer={0}&page={1}&limit={2}",



                //   ProductsURL = "https://apigw3.ashleyfurniture.com/productinformation/products?customer={2}&page={0}&limit={1}&ENVIRONMENT=AFI",  //This should be used only when extracting the complete Ashley Products List. No customer number is needed.







                ApiKey = "03d1d425039441c29443cd23b55166ed",
                PageSize = 500,
                MaxRetryCount = 1

            };

            string errors = "";
            string messages = "";



            //List of all products of current member
            //   List<ProductEntity> listOfAllProductsOfCurrentMember = AllProducts.GetProductStatuses(customerNumber, configuration, ref messages, ref errors);

            //return the list of SKUs of the current customer
            //  var listOfSkusOfCurrentCustomer = listOfAllProductsOfCurrentMember.Select(d => d.Sku).Distinct().ToList();


            var xmlRequestEmpty = new System.Xml.XmlDocument();

            var xmlRequestOne = new System.Xml.XmlDocument();

            var xmlRequestTwo = new System.Xml.XmlDocument();

            //xmlRequestEmpty.Load(@"C:\Users\cboulingui\Desktop\Ashley_Response_For_Inventory\AshleyInventoryInquiryTemplateEmpty.xml");

            //xmlRequestOne.Load(@"C:\Users\cboulingui\Desktop\Ashley_Response_For_Inventory\AshleyInventoryInquiryTemplateOne.xml");

            //xmlRequestTwo.Load(@"C:\Users\cboulingui\Desktop\Ashley_Response_For_Inventory\AshleyInventoryInquiryTemplateTwo.xml");




            string shipToNumberEmpty = "";

            string shipToNumberOne = "01";

            string shipToNumberTwo = "02";

            //await Task.Run(() => GenerateXMLFiles(listOfSkusOfCurrentCustomer, shipToNumberEmpty));

            //await Task.Run(() => GenerateXMLFiles(listOfSkusOfCurrentCustomer, shipToNumberOne));

            //await Task.Run(() => GenerateXMLFiles(listOfSkusOfCurrentCustomer, shipToNumberTwo));

            //foreach (var sku in listOfSkusOfCurrentCustomer.Take(4))
            // foreach (var sku in listOfSkusOfCurrentCustomer.Take(1))
            // {

            var sku = "A8010025";

            //var xmlRequestEmpty = new System.Xml.XmlDocument();

            //var xmlRequestOne = new System.Xml.XmlDocument();

            //var xmlRequestTwo = new System.Xml.XmlDocument();

            xmlRequestEmpty.Load(@"C:\Users\cboulingui\Desktop\Ashley_Response_For_Inventory\AshleyInventoryInquiryTemplateEmpty.xml");

            xmlRequestOne.Load(@"C:\Users\cboulingui\Desktop\Ashley_Response_For_Inventory\AshleyInventoryInquiryTemplateOne.xml");

            xmlRequestTwo.Load(@"C:\Users\cboulingui\Desktop\Ashley_Response_For_Inventory\AshleyInventoryInquiryTemplateTwo.xml");


            //Task t1 = Task.Run(() => GenerateXMLFiles(xmlRequestEmpty, listOfSkusOfCurrentCustomer, shipToNumberEmpty));
            //Task t2 = Task.Run(() => GenerateXMLFiles(xmlRequestOne, listOfSkusOfCurrentCustomer, shipToNumberOne));
            //Task t3 = Task.Run(() => GenerateXMLFiles(xmlRequestTwo, listOfSkusOfCurrentCustomer, shipToNumberTwo));


            Task t1 = Task.Run(() => GenerateXMLFiles(xmlRequestEmpty, sku, shipToNumberEmpty));
            Task t2 = Task.Run(() => GenerateXMLFiles(xmlRequestOne, sku, shipToNumberOne));
            Task t3 = Task.Run(() => GenerateXMLFiles(xmlRequestTwo, sku, shipToNumberTwo));





            await Task.WhenAll(t1, t2, t3);
            // }


            ReadXMLFiles();


            Console.WriteLine();
            Console.WriteLine("**********");
            Console.WriteLine();
            Console.WriteLine("Program completed");


            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");




            Console.ReadKey();




            Console.WriteLine("Press any key to exit...");









        }

    }
}

