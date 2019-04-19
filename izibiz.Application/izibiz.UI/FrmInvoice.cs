﻿using izibiz.CONTROLLER.Singleton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using izibiz.SERVICES.serviceOib;
using izibiz.UI.Properties;
using Microsoft.VisualBasic;
using izibiz.CONTROLLER;
using izibiz.COMMON;
using izibiz.COMMON.Language;
using izibiz.MODEL.Model;

namespace izibiz.UI
{
    public partial class FrmInvoice : Form
    {

        private string gridDirection;

        public FrmInvoice()
        {
            InitializeComponent();
        }


        private void FrmInvoice_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();
        }



        private void localizationItemTextWrite()
        {
            //dil secimini sorgula
            if (Settings.Default.language == "English")
            {
                Lang.Culture = new CultureInfo("en-US");
            }
            else
            {
                Lang.Culture = new CultureInfo("");
            }
            #region writeAllFormItem
            //eleman text yazdır
            this.Text = Lang.formInvoice;
            itemIncomingInvoice.Text = Lang.incomingInvoice;
            itemComingListInvoice.Text = Lang.listInvoice;
            itemSentInvoice.Text = Lang.sentInvoice;
            itemDraftInvoice.Text = Lang.draftInvoice;
            itemDraftNewInvoice.Text = Lang.newInvoice;
            itemSentInvoiceList.Text = Lang.listInvoice;
            itemDraftInvoiceList.Text = Lang.listDraftInvoice;
            //panelSentInvoices butonlar
            btnSentInvGetState.Text = Lang.updateState;
            btnSentInvAgainSent.Text = Lang.againSent;
            btnFaultyInvoices.Text = Lang.faulty;
            //panelIncomingInvoices butonlar
            btnAccept.Text = Lang.accept;
            btnReject.Text = Lang.reject;
            btnDownInvIncoming.Text = Lang.getInvoice;
            btnIncomingInvGetState.Text = Lang.updateState;
            //panelDraftInvoices butonlar
            btnSendDraft.Text = Lang.send;
            btnLoadPortal.Text = Lang.loadPortal;
            #endregion
        }

        private void addViewButtonToDatagridView()
        {
            tableGrid.Columns.Clear();
            //pdf goruntule butonu
            tableGrid.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.iconPdf,
                Name = EI.gridBtnClmName.previewPdf.ToString(),
                HeaderText = Lang.preview
            });
            //xml goruntule butonu
            tableGrid.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.iconXml,
                Name = EI.gridBtnClmName.previewXml.ToString(),
                HeaderText = Lang.preview,
            });
        }



        private void dataGridChangeColoumnName()
        {

            tableGrid.Columns[EI.InvClmName.status.ToString()].HeaderText = Lang.status;

            tableGrid.Columns[EI.InvClmName.statusDesc.ToString()].HeaderText = Lang.statusDesc;

            tableGrid.Columns[EI.InvClmName.gibStatusCode.ToString()].HeaderText = Lang.gibStatusCode;

            tableGrid.Columns[EI.InvClmName.gibStatusDescription.ToString()].HeaderText = Lang.gibSatusDescription;

            tableGrid.Columns[EI.InvClmName.ID.ToString()].HeaderText = Lang.id;

            tableGrid.Columns[EI.InvClmName.uuid.ToString()].HeaderText = Lang.uuid;

            tableGrid.Columns[EI.InvClmName.invType.ToString()].HeaderText = Lang.invType;

            tableGrid.Columns[EI.InvClmName.issueDate.ToString()].HeaderText = Lang.issueDate;

            tableGrid.Columns[EI.InvClmName.profileid.ToString()].HeaderText = Lang.profileid;

            tableGrid.Columns[EI.InvClmName.type.ToString()].HeaderText = Lang.type;

            tableGrid.Columns[EI.InvClmName.suplier.ToString()].HeaderText = Lang.supplier;

            tableGrid.Columns[EI.InvClmName.senderVkn.ToString()].HeaderText = Lang.sender;

            tableGrid.Columns[EI.InvClmName.receiverVkn.ToString()].HeaderText = Lang.receiver;

            tableGrid.Columns[EI.InvClmName.cDate.ToString()].HeaderText = Lang.cDate;

            tableGrid.Columns[EI.InvClmName.envelopeIdentifier.ToString()].HeaderText = Lang.envelopeIdentifier;

            tableGrid.Columns[EI.InvClmName.fromm.ToString()].HeaderText = Lang.from;

            tableGrid.Columns[EI.InvClmName.too.ToString()].HeaderText = Lang.to;

        }



        private void getInvListUpdateGrid(string direction)
        {
            tableGrid.DataSource = null;

            var listInv = Singl.invoiceDALGet.getInvoiceList(direction);         
            if (listInv.Count == 0)
            {
                MessageBox.Show(Lang.noShowInvoice);
            }
            else
            {
                foreach (var inv in listInv)
                {
                    inv.statusDesc = invoiceIncomingStatusWrite(inv.status, inv.gibStatusCode);
                }

                addViewButtonToDatagridView();
                tableGrid.DataSource = listInv;
                dataGridChangeColoumnName();
                tableGrid.Columns[nameof(EI.InvClmName.invType)].Visible = false;
                tableGrid.Columns[nameof(EI.InvClmName.draftFlag)].Visible = false;
                tableGrid.Columns[nameof(EI.InvClmName.status)].Visible = false;
                tableGrid.Columns[nameof(EI.InvClmName.gibStatusDescription)].Visible = false;
                tableGrid.Columns[nameof(EI.InvClmName.content)].Visible = false;
            }
        }




        private void itemComingListInvoice_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lang.incomingInvoice;
            panelSentInv.Visible = false;
            panelIncomingInv.Visible = false;
            panelDraftInv.Visible = false;
            gridDirection = nameof(EI.InvDirection.IN);
            try
            {
                Singl.invoiceControllerGet.getIncomingInvoice();
                getInvListUpdateGrid(nameof(EI.InvDirection.IN));

            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show(Lang.dbFault + " " + ex.Message.ToString(), "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }




        private void itemSentInvoiceList_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lang.sentInvoice;
            panelSentInv.Visible = false;
            panelIncomingInv.Visible = false;
            panelDraftInv.Visible = false;
            btnSentInvAgainSent.Enabled = false;
            gridDirection = nameof(EI.InvDirection.OUT);
            try
            {
                Singl.invoiceControllerGet.getSentInvoice();
                getInvListUpdateGrid(nameof(EI.InvDirection.OUT));
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show(Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void itemDraftInvoiceList_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lang.draftInvoice;
            panelSentInv.Visible = false;
            panelIncomingInv.Visible = false;
            panelDraftInv.Visible = false;
            gridDirection = nameof(EI.InvDirection.DRAFT);
            try
            {
                Singl.invoiceControllerGet.getDraftInvoice();
                getInvListUpdateGrid(nameof(EI.InvDirection.DRAFT));
                
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show(Lang.dbFault + " " + ex.Message, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.ToString());
              }
        }





    


        public string invoiceIncomingStatusWrite(string status, int gibStatusCode)
        {
            //   string status = invoice.status;
            //  int envelopeOpcode = invoice.gibStatusCode;

            if (gibStatusCode == 1210)
            {
                return "GİB'e gönderildi";
            }
            // RECEIVE
            if (status.Contains(EI.StatusType.RECEIVE.ToString()))
            {
                return "Alındı";
            }
            // LOAD
            if (status.Contains(EI.StatusType.LOAD.ToString()) && status.Contains(EI.SubStatusType.SUCCEED.ToString()))
            {
                return "Yüklendi";
            }
            if (status.Contains(EI.StatusType.LOAD.ToString()) && status.Contains(EI.SubStatusType.FAILED.ToString()))
            {
                return "Yüklenemedi";
            }
            // PACKAGE
            if (status.Contains(EI.StatusType.PACKAGE.ToString()) && status.Contains(EI.SubStatusType.FAILED.ToString()))
            {
                return "İşleniyor";
            }
            if (status.Contains(EI.StatusType.PACKAGE.ToString()) && status.Contains(EI.SubStatusType.SUCCEED.ToString()))
            {
                return "Yüklendi";
            }
            if (status.Contains(EI.StatusType.PACKAGE.ToString()) && status.Contains(EI.SubStatusType.PROCESSING.ToString()))
            {
                return "Paketleniyor";
            }
            if (status.Contains(EI.StatusType.SIGN.ToString()) && status.Contains(EI.SubStatusType.PROCESSING.ToString()))
            {
                return "İşleniyor";
            }
            if (status.Contains(EI.StatusType.SIGN.ToString()) && status.Contains(EI.SubStatusType.SUCCEED.ToString()))
            {
                return "İmzalandı";
            }
            if (status.Contains(EI.StatusType.SIGN.ToString()) && status.Contains(EI.SubStatusType.FAILED.ToString()))
            {
                return "İşleniyor";
            }
            return "Durum Atanması Bekleniyor";
        }



        public string invoiceSendStatusWrite(string status)
        {
            // string status = invoice.status;

            // SEND
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.PROCESSING.ToString()))
            {
                return "İşleniyor";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.SUCCEED.ToString()))
            {
                return "Ulaştırıldı";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.FAILED.ToString()))
            {
                return "Ulaştırılamadı";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.WAIT_GIB_RESPONSE.ToString()))
            {
                return "GİB'e gönderildi";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.WAIT_SYSTEM_RESPONSE.ToString()))
            {
                return "Ulaştırıldı";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.WAIT_APPLICATION_RESPONSE.ToString()))
            {
                return "Ulaştırıldı";
            }
            // ACCEPTED
            if (status.Contains(EI.StatusType.ACCEPTED.ToString()))
            {
                return "Kabul edildi";
            }
            // REJECTED
            if (status.Contains(EI.StatusType.REJECTED.ToString()))
            {
                return "Red edildi";
            }
            // ACCEPT
            if (status.Contains(EI.StatusType.ACCEPT.ToString()))
            {
                return "Kabul";
            }
            // REJECT
            if (status.Contains(EI.StatusType.REJECT.ToString()))
            {
                return "Red";
            }
            return "Durum Atanması Bekleniyor";
        }






        private void invoiceResponseAcceptOrReject(string state)
        {
            int verifiedrow = 0;
            int invoiceCount = tableGrid.SelectedRows.Count;
            string[] description = new string[invoiceCount];


            string desc = Interaction.InputBox(Lang.writeDescription, Lang.addDescription, "Default");

            foreach (DataGridViewRow row in tableGrid.SelectedRows)
            {
                DateTime dt = DateTime.Parse(row.Cells[nameof(EI.InvClmName.cDate)].Value.ToString());
                TimeSpan fark = DateTime.Today - dt;

                if (row.Cells[nameof(EI.InvClmName.profileid)].Value == null || row.Cells[nameof(EI.InvClmName.profileid)].Value.ToString() == EI.InvoiceProfileid.TEMELFATURA.ToString())//temel faturaysa
                {
                    MessageBox.Show((row.Cells[nameof(EI.InvClmName.ID)].Value.ToString()) + " " + Lang.warningBasicInvoice);
                    break;
                }
                else if (fark.TotalDays > 8)//8 gün geçmis
                {
                    MessageBox.Show((row.Cells[nameof(EI.InvClmName.ID)].Value.ToString()) + " " + Lang.warning8Day);
                    break;
                }
                else if (row.Cells[nameof(EI.InvClmName.status)].Value == null || row.Cells[nameof(EI.InvClmName.status)].Value.ToString() != EI.SubStatusType.WAIT_APPLICATION_RESPONSE.ToString())//olan varsa
                {
                    MessageBox.Show((row.Cells[nameof(EI.InvClmName.ID)].Value.ToString()) + " " + Lang.warningHasAnswer);
                    break;
                }
                else//fatura noların oldugu kabul lıstesi olustur
                {
                    string uuid = row.Cells[nameof(EI.InvClmName.uuid)].Value.ToString();
                    Singl.invoiceControllerGet.createInvoiceWithUuid(invoiceCount, uuid, verifiedrow);

                    description[verifiedrow] = desc;
                    verifiedrow++;
                }
            }
            if (verifiedrow > 0)
            {
                Singl.invoiceControllerGet.sendInvoiceResponse(state, description);
            }
        }



        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                invoiceResponseAcceptOrReject(EI.InvoiceResponseStatus.KABUL.ToString());
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                invoiceResponseAcceptOrReject(EI.InvoiceResponseStatus.RED.ToString());
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool statusValidCheck(DataGridViewRow row)
        {
            if ((row.Cells[nameof(EI.InvClmName.gibStatusCode)].Value.Equals(1300) || row.Cells[nameof(EI.InvClmName.gibStatusCode)].Value.Equals(1215) || row.Cells[nameof(EI.InvClmName.gibStatusCode)].Value.Equals(1230))
              || (Convert.ToInt32(row.Cells[nameof(EI.InvClmName.gibStatusCode)].Value) < 1100 || (Convert.ToInt32(row.Cells[nameof(EI.InvClmName.gibStatusCode)].Value) > 1200)))
            {
                return false;
            }
            return true;
        }



        private void showStateInvoice(string direction)
        {
            try
            {
                List<string> unvalidList = new List<string>();
                List<string> validList = new List<string>();
                string uuid;

                for (int i = 0; i < tableGrid.SelectedRows.Count; i++)
                {
                    uuid = tableGrid.Rows[i].Cells[nameof(EI.InvClmName.uuid)].Value.ToString();
                    if (!statusValidCheck(tableGrid.SelectedRows[i])) //selectedrows valid degıl ise
                    {
                        unvalidList.Add(uuid);
                    }
                    else //valid ise modelde guncelle
                    {
                        validList.Add(uuid);
                        string updatedState = Singl.invoiceControllerGet.getInvoiceState(uuid);
                        //modelde guncelle
                        Singl.databaseContextGet.Invoices.Where(x => x.uuid == uuid && x.type == direction).FirstOrDefault().statusDesc = updatedState;
                        //datagrıdde yazdır
                        tableGrid.Rows[i].Cells[nameof(EI.InvClmName.statusDesc)].Value = updatedState;
                    }
                }

                if (validList.Count == 0) //hicbiri krıterlere uygun degılse
                {
                    if (tableGrid.SelectedRows.Count == 1)//tekli secim
                    {
                        MessageBox.Show(Lang.warningStateShow);
                    }
                    else//coklu secım
                    {
                        MessageBox.Show(string.Join(Environment.NewLine, unvalidList) + Environment.NewLine + Lang.noInvNotUpdated); //nolu faturalar guncellenemedi
                    }
                }
                else//valid fatura varsa modelden datagride guncelle
                {
                    MessageBox.Show(string.Join(Environment.NewLine, validList) + Environment.NewLine + Lang.noInvUpdated); //nolu faturalar guncellendı
                }
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show(Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void btnIncomingInvGetState_Click(object sender, EventArgs e)
        {
            showStateInvoice(EI.InvDirection.IN.ToString());
        }


        private void btnSentInvGetState_Click(object sender, EventArgs e)
        {
            btnSentInvAgainSent.Enabled = false;
            showStateInvoice(EI.InvDirection.OUT.ToString());
        }






        private void tableGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                #region panelVisiblity
                if (gridDirection == nameof(EI.InvDirection.IN))//gelen faturalara tıklandıysa
                {
                    panelIncomingInv.Visible = true;
                }
                else if (gridDirection == nameof(EI.InvDirection.OUT))//giden faturalar
                {
                    panelSentInv.Visible = true;
                }
                else//taslak faturalar
                {
                    panelDraftInv.Visible = true;
                }
                #endregion


                string uuid = tableGrid.Rows[e.RowIndex].Cells[nameof(EI.InvClmName.uuid)].Value.ToString();

                //PDF göruntule butonuna tıkladıysa
                if (e.ColumnIndex == tableGrid.Columns[nameof(EI.gridBtnClmName.previewPdf)].Index)
                {
                    //pdf ıcın getınvoicewithtype metodu cagırılcak
                    string filepath = Singl.invoiceControllerGet.getInvoiceType(uuid, nameof(EI.DocumentType.PDF), gridDirection);
                    System.Diagnostics.Process.Start(filepath);
                }
                //xml göruntule butonuna tıkladıysa
                else if (e.ColumnIndex == tableGrid.Columns[nameof(EI.gridBtnClmName.previewXml)].Index)
                {
                    // xml contenti db de tutuldugu ıcın conent db den cekılecek
                    string content = Singl.invoiceDALGet.getInvoice(uuid, gridDirection).content;
                    FrmPreviewInvoices previewInvoices = new FrmPreviewInvoices(content);
                    previewInvoices.Show();
                }
            }
        }



        private void btnDownInvIncoming_Click(object sender, EventArgs e)
        {
            try
            {
                Singl.invoiceControllerGet.downloadInvoice();
                MessageBox.Show(Lang.downInvSaveFolder); //Gelen faturalar 'D:\\temp\\GELEN\\' klasorune kaydedılmıstır

            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }










        private void btnSentInvAgainSent_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> uuidArr = new List<string>();

                //ilk secılı rowun receıverını al, karsılastırma yapmak için
                DataGridViewRow gridRow = tableGrid.SelectedRows[0];
                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    //aynı kısıye fatura gonderıyo kontrolu //recevierVkn ilk secılen row vkn ile esıt olmalı
                    if (gridRow.Cells[nameof(EI.InvClmName.receiverVkn)].Value != row.Cells[nameof(EI.InvClmName.receiverVkn)].Value)
                    {
                        MessageBox.Show("aynı kısıye olan faturaları bırlıkte gonderebılırsınız");
                        break;
                    }
                    uuidArr.Add(row.Cells[nameof(EI.InvClmName.uuid)].Value.ToString());
                }

                //send inv 
                Singl.invoiceControllerGet.sendInvoice(nameof(EI.InvDirection.OUT), uuidArr.ToArray());


            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void itemDraftNewInvoice_Click(object sender, EventArgs e)
        {
            FrmCreateInvoice frmCreateInvoice = new FrmCreateInvoice();
            frmCreateInvoice.Show();
        }




        private void btnFaultyInvoices_Click(object sender, EventArgs e)
        {
            try
            {
                //db ye yuklenen gıden faturalardan hatalı olanları getır
                List<Invoices> list = Singl.invoiceDALGet.getFaultyInvoices();
                if (list.Count == 0 || list == null)
                {
                    MessageBox.Show(Lang.notFaultyInv); //gosterılecek hatalı fatura yok
                }
                else //yenı fatura varsa
                {
                    tableGrid.DataSource = null;
                    addViewButtonToDatagridView();
                    tableGrid.DataSource = list;
                    dataGridChangeColoumnName();
                    tableGrid.Columns[EI.InvClmName.status.ToString()].Visible = false;
                    tableGrid.Columns[EI.InvClmName.invType.ToString()].Visible = false;
                    lblTitle.Text = Lang.faulty;
                    btnSentInvAgainSent.Enabled = true;
                }

            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show(Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSendDraft_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> uuidArr = new List<string>();
                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    //LOAD INV YAPMIS MI
                    if (!row.Cells[nameof(EI.InvClmName.status)].Value.ToString().Equals(nameof(EI.StatusType.LOAD)) &&
                            !row.Cells[nameof(EI.InvClmName.status)].Value.ToString().Equals(nameof(EI.SubStatusType.SUCCEED)))
                    {
                        //Load Succes olmadıysa
                        MessageBox.Show("load ınvoice yapamadan send invoice yapamazsınız asagıdakı faturaya " +
                            "önce load ınvoice yapınız" + row.Cells[nameof(EI.InvClmName.ID)].Value.ToString());
                        break;
                    }
                    uuidArr.Add(row.Cells[nameof(EI.InvClmName.uuid)].Value.ToString());
                }

                //send inv 
                int returnCode = Singl.invoiceControllerGet.sendInvoice(nameof(EI.InvDirection.DRAFT), uuidArr.ToArray());

                if (returnCode == 0)
                {
                    //db de taslak faturalardan sıl
                    foreach (var uuid in uuidArr)
                    {
                        Singl.invoiceDALGet.deleteInvoices(uuid, nameof(EI.InvDirection.DRAFT));
                    }
                    Singl.invoiceDALGet.dbSaveChanges();

                    //gridRefresh
                    itemDraftInvoiceList_Click(sender, e);
                }


            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show("İşlem Basarısız " + ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }




        private void btnLoadPortal_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> uuidArr = new List<string>();

                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    uuidArr.Add(row.Cells[nameof(EI.InvClmName.uuid)].Value.ToString());
                }

                int returnCode = Singl.invoiceControllerGet.loadInvoice(uuidArr.ToArray());

                if (returnCode == 0)
                {
                    foreach (var uuid in uuidArr)
                    {
                        //fatura state guncelle  (load succed yapıldı)
                        Singl.invoiceDALGet.updateStateInv(uuid, nameof(EI.InvDirection.DRAFT),
                            nameof(EI.StatusType.LOAD) +" - "+ nameof(EI.SubStatusType.SUCCEED));
                    }
                    //db guncellemeyı kaydet
                    Singl.invoiceDALGet.dbSaveChanges();

                    // datagrıd guncelle
                    getInvListUpdateGrid(nameof(EI.InvDirection.DRAFT));
                }
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

}

