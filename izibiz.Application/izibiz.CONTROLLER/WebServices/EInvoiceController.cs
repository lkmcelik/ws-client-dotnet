﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using izibiz.MODEL.Model;
using izibiz.SERVICES.serviceOib;
using izibiz.MODEL;
using System.IO;
using System.IO.Compression;
using izibiz.COMMON;
using System.Data;
using izibiz.MODEL.Data;
using System.Data.Entity;
using izibiz.CONTROLLER.Singleton;
using System.Xml.Serialization;
using izibiz.COMMON.UblSerializer;
using Ubl_Invoice_2_1;

namespace izibiz.CONTROLLER.Web_Services
{
    public class EInvoiceController
    {

        private EFaturaOIBPortClient EFaturaOIBPortClient = new EFaturaOIBPortClient();
        string inboxFolder = "D:\\temp\\GELEN\\";
        INVOICE[] stateInvoice = null;



        public EInvoiceController()
        {
            InvoiceSearchKey.createInvoiceSearchKeyGetInvoiceRequest();
            InvoiceSearchKey.createinvoiceSearchKeyGetInvoiceWithTypeRequest();
        }



        public List<InvoicesTable> getIncomingInvoice()
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest(); //sistemdeki gelen efatura listesi için request parametreleri
                req.REQUEST_HEADER = RequestHeader.requestHeader;
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
                req.INVOICE_SEARCH_KEY.DIRECTION = EI.Direction.IN.ToString();
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

                INVOICE[] invoiceArray = EFaturaOIBPortClient.GetInvoice(req);
                if (invoiceArray.Length > 0)
                {
                    //       invoiceMarkRead(invoiceArray);
                    SaveInvoiceArrayToEntitiy(invoiceArray, Singl.databaseContextGet.Invoices, EI.Direction.IN.ToString());
                }
                return Singl.databaseContextGet.Invoices.Where(x => x.invType == nameof(EI.Direction.IN)).ToList();
            }
        }




        public List<InvoicesTable> getSentInvoice()
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest();//sistemdeki gelen efatura listesi için request parametreleri

                req.REQUEST_HEADER = RequestHeader.requestHeader;
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
                req.INVOICE_SEARCH_KEY.DIRECTION = EI.Direction.OUT.ToString();
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

                INVOICE[] invoiceArray = EFaturaOIBPortClient.GetInvoice(req);
                if (invoiceArray.Length > 0)
                {
                    invoiceMarkRead(invoiceArray);
                    SaveInvoiceArrayToEntitiy(invoiceArray, Singl.databaseContextGet.Invoices, EI.Direction.OUT.ToString());
                }

                return Singl.databaseContextGet.Invoices.Where(x => x.invType == nameof(EI.Direction.OUT)).ToList();
            }
        }



        public List<InvoicesTable> getDraftInvoice()
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest(); //sistemdeki gelen efatura listesi için request parametreleri

                req.REQUEST_HEADER = RequestHeader.requestHeader;
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
                req.INVOICE_SEARCH_KEY.DIRECTION = EI.Direction.OUT.ToString();
                req.INVOICE_SEARCH_KEY.DRAFT_FLAG = EI.ActiveOrPasive.Y.ToString();
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

                INVOICE[] invoiceArray = EFaturaOIBPortClient.GetInvoice(req);
                if (invoiceArray.Length > 0)
                {
         //           invoiceMarkRead(invoiceArray);
                    SaveInvoiceArrayToEntitiy(invoiceArray, Singl.databaseContextGet.Invoices, EI.Direction.DRAFT.ToString());
                }

                return Singl.databaseContextGet.Invoices.Where(x => x.invType == nameof(EI.Direction.DRAFT)).ToList();
            }
        }


        private void SaveInvoiceArrayToEntitiy(INVOICE[] invoiceArray, DbSet<InvoicesTable> entitiyInv, string type)
        {
            foreach (var inv in invoiceArray)
            {
                InvoicesTable invoice = new InvoicesTable();

                invoice.ID = inv.ID;
                invoice.Uuid = inv.UUID;
                invoice.invType = type;
                invoice.issueDate = inv.HEADER.ISSUE_DATE;
                invoice.profileid = inv.HEADER.PROFILEID;
                invoice.type = inv.HEADER.INVOICE_TYPE_CODE;
                invoice.suplier = inv.HEADER.SUPPLIER;
                invoice.senderVkn = inv.HEADER.SENDER;
                invoice.receiverVkn = inv.HEADER.RECEIVER;
                invoice.cDate = inv.HEADER.CDATE;
                invoice.envelopeIdentifier = inv.HEADER.ENVELOPE_IDENTIFIER;
                invoice.status = inv.HEADER.STATUS;
                invoice.statusDesc = inv.HEADER.STATUS;
                invoice.gibStatusCode = inv.HEADER.GIB_STATUS_CODE;
                invoice.gibStatusDescription = inv.HEADER.GIB_STATUS_DESCRIPTION;
                invoice.fromm = inv.HEADER.FROM;
                invoice.too = inv.HEADER.TO;
                invoice.content = Encoding.UTF8.GetString(inv.CONTENT.Value); //xml db de tututlur

                if (type == EI.Direction.DRAFT.ToString())
                {
                    invoice.draftFlag = EI.ActiveOrPasive.Y.ToString();  //servisten cektıklerımız flag Y  ☺
                }
                entitiyInv.Add(invoice);
            }
            Singl.databaseContextGet.SaveChanges();
        }



        private void invoiceMarkRead(INVOICE[] invoiceList)
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var markReq = new MarkInvoiceRequest() //sistemdeki gelen efatura listesi için request parametreleri
                {
                    REQUEST_HEADER = RequestHeader.requestHeader,
                    MARK = new MarkInvoiceRequestMARK()
                    {
                        INVOICE = invoiceList,
                        value = MarkInvoiceRequestMARKValue.READ,
                        valueSpecified = true
                    }
                };
                MarkInvoiceResponse markRes = EFaturaOIBPortClient.MarkInvoice(markReq);
            }
        }



        private byte[] stringToByteArr(string content)
        {
            return Encoding.UTF8.GetBytes(content);
        }


    

        public INVOICE[] createInvArrWithContent(string[] uuidArr,string direction)
        {
            INVOICE[] invoiceArr = new INVOICE[uuidArr.Length];
        
            for (int i = 0; i < invoiceArr.Length; i++)
            {
                INVOICE inv = new INVOICE();
                invoiceArr[i] = inv;
                //uuid array ile db den cekılen contentı base64 tipide yazdır
                base64Binary cont = new base64Binary();
             
                cont.Value = stringToByteArr(Singl.invoiceDALGet.getInvoice(uuidArr[i], direction).content);
                invoiceArr[i].CONTENT = cont;

            }

            return invoiceArr;
        }



        public void sendInvoice(string direction,string[] uuidArr,string senderVkn,string fromAlias,string receiverVkn,string toAlias)
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var req = new SendInvoiceRequest();

                req.REQUEST_HEADER = RequestHeader.requestHeader;
                req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.N.ToString();
                req.SENDER = new SendInvoiceRequestSENDER();
                req.SENDER.vkn = senderVkn; 
                req.SENDER.alias =fromAlias;  
                req.RECEIVER = new SendInvoiceRequestRECEIVER();
                req.RECEIVER.vkn = receiverVkn;   
                req.RECEIVER.alias = toAlias;

                INVOICE[] invoiceArr= createInvArrWithContent(uuidArr,direction);
                req.INVOICE = invoiceArr;

               var o= EFaturaOIBPortClient.SendInvoice(req).REQUEST_RETURN.RETURN_CODE;
            }
        }

     public void loadInvoice()
        {
            //using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            //{
            //    var req = new SendInvoiceRequest();

            //    req.REQUEST_HEADER = RequestHeader.requestHeader;
            //    req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.N.ToString();
            //    req.SENDER = new LoadInvoiceRequest();
  
            //    req.RECEIVER = new SendInvoiceRequestRECEIVER();
 

            //    INVOICE[] invoiceArr = createInvArrWithContent(uuidArr, direction);
            //    req.INVOICE = invoiceArr;

            //    var o = EFaturaOIBPortClient.SendInvoice(req).REQUEST_RETURN.RETURN_CODE;
            //}
        }



        public void sendInvoiceResponse(string status, string[] description)
        {

            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                SendInvoiceResponseWithServerSignRequest req = new SendInvoiceResponseWithServerSignRequest()
                {
                    REQUEST_HEADER = RequestHeader.requestHeader,
                    STATUS = status,
                    INVOICE = stateInvoice,
                    DESCRIPTION = description
                };

                SendInvoiceResponseWithServerSignResponse res = EFaturaOIBPortClient.SendInvoiceResponseWithServerSign(req);
                stateInvoice = null;
            }
        }

        public void createInvoiceWithUuid(int arrayLength, string invoiceUuid, int i)
        {
            stateInvoice = new INVOICE[arrayLength];
            INVOICE invoice = new INVOICE();
            invoice.UUID = invoiceUuid;
            stateInvoice[i] = invoice;
        }

        /*  public INVOICE[] ArrayUuidToInvoice(string[] invoiceUuid)
          {
              INVOICE[] invoiceArray = new INVOICE[invoiceUuid.Length];
              for(int i = 0; i <= invoiceUuid.Length; i++)
              {
                  INVOICE invoice = new INVOICE();
                  invoice.UUID = invoiceUuid[i];
              }
              return invoiceArray;
          }*/



        public string getInvoiceState(string invoiceUuid)
        {
            INVOICE invoice = new INVOICE();
            invoice.UUID = invoiceUuid;

            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                GetInvoiceStatusRequest req = new GetInvoiceStatusRequest()
                {
                    REQUEST_HEADER = RequestHeader.requestHeader,
                    INVOICE = invoice,
                };

                GetInvoiceStatusResponse res = EFaturaOIBPortClient.GetInvoiceStatus(req);
                return res.INVOICE_STATUS.STATUS;
            }
        }




        private void createInboxIfDoesNotExist(String inboxFolder)
        {
            if (!Directory.Exists(inboxFolder))
            {
                Directory.CreateDirectory(inboxFolder);
            }
        }


        private string saveInvoiceType(INVOICE invoice, string type)
        {
            createInboxIfDoesNotExist(inboxFolder); //dosya yolu yoksa olustur
            string filePath;
            filePath = inboxFolder + invoice.ID + "." + type;

            System.IO.File.WriteAllBytes(filePath, invoice.CONTENT.Value);
            return filePath;
        }


        public void downloadInvoice()
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                GetInvoiceRequest req = new GetInvoiceRequest();

                req.REQUEST_HEADER = RequestHeader.requestHeader;
                req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.Y.ToString();
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
                req.INVOICE_SEARCH_KEY.DIRECTION = EI.Direction.IN.ToString();
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

                INVOICE[] invoiceList = EFaturaOIBPortClient.GetInvoice(req);
                foreach (INVOICE invoice in invoiceList)
                {
                    ınvoiceToUnzip(invoice);
                }
                invoiceMarkRead(invoiceList);
                if (invoiceList.Length == 100)
                {
                    downloadInvoice();
                }
            }
        }


        private void ınvoiceToUnzip(INVOICE invoice)
        {
            //invoice daha 
            byte[] content = invoice.CONTENT.Value;
            using (var zippedStream = new MemoryStream(content))
            {
                using (var archive = new ZipArchive(zippedStream))
                {
                    var entry = archive.Entries.FirstOrDefault();
                    if (entry != null)
                    {
                        using (var unzippedEntryStream = entry.Open())
                        {
                            using (var ms = new MemoryStream())
                            {
                                unzippedEntryStream.CopyTo(ms);
                                var unzippedArray = ms.ToArray();

                                System.IO.File.WriteAllBytes(inboxFolder + invoice.ID + ".xml", unzippedArray);
                            }
                        }
                    }
                }
            }
        }



        public string getInvoiceType(string invoiceUuid, string type, string direction)
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                GetInvoiceWithTypeRequest req = new GetInvoiceWithTypeRequest();

                req.REQUEST_HEADER = RequestHeader.requestHeader;

                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceWithTypeRequest;
                req.INVOICE_SEARCH_KEY.UUID = invoiceUuid;
                req.INVOICE_SEARCH_KEY.TYPE = type;//XML,PDF 
                req.INVOICE_SEARCH_KEY.DIRECTION = direction;
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

                INVOICE[] invoice = EFaturaOIBPortClient.GetInvoiceWithType(req);
                return saveInvoiceType(invoice[0], type);
            }
        }



        public byte[] getInvoiceXml(string invoiceUuid)
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                GetInvoiceWithTypeRequest req = new GetInvoiceWithTypeRequest();
                req.REQUEST_HEADER = RequestHeader.requestHeader;

                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceWithTypeRequest;
                req.INVOICE_SEARCH_KEY.UUID = invoiceUuid;
                req.INVOICE_SEARCH_KEY.TYPE = EI.DocumentType.PDF.ToString();
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

                INVOICE[] invoice = EFaturaOIBPortClient.GetInvoiceWithType(req);
                return invoice[0].CONTENT.Value;
            }
        }


        public string CreateInvoiceXml(InvoiceType createdUBL)
        {
            /////// DİSKE KAYDETMEK İSTERSEK ASAGIDAKI KODU ACARIZ 

            //string draftPath = "D://Taslak//";
            //createInboxIfDoesNotExist(draftPath); //dosya yolu yoksa olustur
            //inboxFolder = Path.Combine(draftPath, createdUBL.UUID.Value.ToString() + ".xml");


            //using (FileStream stream = new FileStream(inboxFolder, FileMode.Create))
            //{
            //    XmlSerializer xmlSerializer = new XmlSerializer(createdUBL.GetType());

            //    xmlSerializer.Serialize(stream, createdUBL, InvoiceSerializer.GetXmlSerializerNamespace());
            //}

            using (StringWriter textWriter = new StringWriter())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(createdUBL.GetType());

                xmlSerializer.Serialize(textWriter, createdUBL, InvoiceSerializer.GetXmlSerializerNamespace());
                return textWriter.ToString();
            }
        }




    }
}


