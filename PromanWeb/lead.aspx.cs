using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proman.BLL;
using System.Data;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxClasses;

namespace PromanWeb
{
    /// <summary>
    /// This page use to view Lead Details
    /// </summary>
    public partial class lead : UserBasePage
    {
        #region Page events

        /// <summary>
        /// Page Load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
          

            if (Request.QueryString["leadid"] != null && !Page.IsPostBack)
            {
                //Show popup box and bind detailes into popup box acoording to Lead Id 
                Bindpopup(Convert.ToInt64(Request.QueryString["leadid"]));
            }

            if (!IsPostBack)
            {
                Common objCommon = new Common();
                //Fill Search Country DropdownList
                objCommon.FillCountry(ref  ddlSearchCountry, true);
                if (Session["CountryName"] != null)
                { ddlSearchCountry.Text = Session["CountryName"].ToString(); }
            }
            //Bind Page details(Bind Lead GridView)

            BindPage();

        }
        #endregion

        #region Events
        /// <summary>
        ///Show Popup to Insert new record into database
        ///</summary>
        protected void addNewRecord_Click(object sender, EventArgs e)
        {
            //Show Popup
            pcAddNewRecord.ShowOnPageLoad = true;
            //clear all popup controls
            clearAll();
            //set the insert or update mode
            ViewState["Insert_status"] = "insert";
            Common objCommon = new Common();

            //Fill Country Dropdownlist
            objCommon.FillCountry(ref ddlCountry, true);

            //Fill Designation Dropdownlist
            objCommon.FillDesignation(ref ddlDesignation, true);

            //Select Max leadid from lead table
            clsLead objLead = new clsLead();
            lblMaxLeadId.Text = objLead.SelectMaxLeadId().ToString();


        }
        ///<summary>
        ///Search Particular record from lead grid
        ///</summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //bind Lead grid 
            clsLead objLead = new clsLead();
            DataSet dsLead = objLead.SelectAll(Convert.ToInt64(ddlSearchCountry.SelectedItem.Value));
            gvLeadList.SettingsPager.PageSize = Convert.ToInt32(AppSetting.GetSetting("GridPageSize", AppSettingCategory.General));
            gvLeadList.DataSource = dsLead;
            gvLeadList.DataBind();
            //store the current country name,selected in country dropdownlist,so when popup is shown then state of dropdownlist can be maintained
            //through session,we retrive this session on page load
            Session["CountryName"] = ddlSearchCountry.SelectedItem.Text;

        }
        /// <summary>
        /// Check the availability of the email address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnChkEmail_Click(object sender, EventArgs e)
        {
            clsLead objLead = new clsLead();
            if (objLead.ExistsEmailOrWebsite("e", txtEmail.Text) == true)
                Helper.ShowMessage(ref lblemailwebsitecheck, "Email Already Exists!!", MessageType.Error);
            else
                Helper.ShowMessage(ref lblemailwebsitecheck, "Email Is Available!!", MessageType.Success);

        }
        /// <summary>
        /// Check the availability of the website
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnChkWebsite_Click(object sender, EventArgs e)
        {
            clsLead objLead = new clsLead();
            if (objLead.ExistsEmailOrWebsite("w", txtWebsite.Text) == true)
                Helper.ShowMessage(ref lblemailwebsitecheck, "Website Name Already Exists!!", MessageType.Error);
            else
                Helper.ShowMessage(ref lblemailwebsitecheck, "Website Name Is Available!!", MessageType.Success);
        }
        ///<summary>
        ///Add New record into the Lead table
        ///</summary>
        protected void submit_Click(object sender, EventArgs e)
        {

            // Insert Lead,if mode is insert 
            if (ViewState["Insert_status"].ToString() == "insert")
            {
                clsLead objLead = new clsLead();
                objLead.LeadId = Convert.ToInt64(lblMaxLeadId.Text);
                objLead.CompanyName = txtCompanyName.Text.Trim();
                objLead.Email = txtEmail.Text.Trim();
                objLead.WebSite = txtWebsite.Text.Trim();
                objLead.ContactPerson = txtContactPerson.Text.Trim();
                if (ddlDesignation.Text != string.Empty)
                    objLead.DesignationId = Convert.ToInt64(ddlDesignation.SelectedItem.Value);
                objLead.PhoneNo1 = txtPhone1.Text.Trim();
                objLead.PhoneNo1Ext = txtPhone1Ext.Text.Trim();
                objLead.PhoneNo2 = txtPhone2.Text.Trim();
                objLead.PhoneNo2Ext = txtPhone2Ext.Text.Trim();
                objLead.MobileNo1 = txtMobile1.Text.Trim();
                objLead.MobileNo2 = txtMobile2.Text.Trim();
                objLead.Address1 = txtAddress1.Text.Trim();
                objLead.Address2 = txtAddress2.Text.Trim();
                objLead.City = txtCity.Text.Trim();
                objLead.ZipCode = txtZipCode.Text.Trim();
                if (ddlState.Text != string.Empty)
                    objLead.StateId = Convert.ToInt64(ddlState.SelectedItem.Value);
                if (ddlCountry.Text != string.Empty)
                    objLead.CountryId = Convert.ToInt64(ddlCountry.SelectedItem.Value);
                objLead.DoNotCall = Convert.ToBoolean(chkDoNotCall.Value);
                objLead.IsCompany = Convert.ToBoolean(chkIsCompany.Value);
                objLead.CreatedBy = SessionData.UserId;
                objLead.Createddate = DateTime.Now;
                objLead.ModifiedBy = SessionData.UserId;
                objLead.ModifiedDate = DateTime.Now;
                objLead.GTalk = txtGtalk.Text;
                objLead.Yahoo = txtYahoo.Text;
                objLead.Skype = txtSkype.Text;
                objLead.Aim = txtAim.Text;
                objLead.Icq = txtIcq.Text;
                objLead.Msn = txtMsn.Text;
                objLead.IsClient = Convert.ToBoolean(chkIsClient.Value);
                objLead.IsProspect = Convert.ToBoolean(chkIsProspect.Value);
                objLead.Email2 = txtEmail2.Text;
                objLead.Email3 = txtEmail3.Text;
                objLead.Insert();

                //clear the text fields of the popup 
                clearAll();
                //Set focus to the First field
                txtCompanyName.Focus();
                //Icrement Lead Id by 1 to insert new record
                lblMaxLeadId.Text = (Convert.ToInt64(lblMaxLeadId.Text) + 1).ToString();
                //refresh the page
                BindPage();
                Helper.ShowMessage(ref lblStatus, "Record Succseesfully Saved", MessageType.Success);
            }
            //if mode is update then update the lead table
            else if (ViewState["Insert_status"].ToString() == "update")
            {
                clsLead objLead1 = new clsLead();
                objLead1.LeadId = Convert.ToInt64(lblMaxLeadId.Text);
                objLead1.CompanyName = txtCompanyName.Text.Trim();
                objLead1.Email = txtEmail.Text.Trim();
                objLead1.WebSite = txtWebsite.Text.Trim();
                objLead1.ContactPerson = txtContactPerson.Text.Trim();
                if (ddlDesignation.Text != string.Empty)
                    objLead1.DesignationId = Convert.ToInt64(ddlDesignation.SelectedItem.Value);
                objLead1.PhoneNo1 = txtPhone1.Text.Trim();
                objLead1.PhoneNo1Ext = txtPhone1Ext.Text.Trim();
                objLead1.PhoneNo2 = txtPhone2.Text.Trim();
                objLead1.PhoneNo2Ext = txtPhone2Ext.Text.Trim();
                objLead1.MobileNo1 = txtMobile1.Text.Trim();
                objLead1.MobileNo2 = txtMobile2.Text.Trim();
                objLead1.Address1 = txtAddress1.Text.Trim();
                objLead1.Address2 = txtAddress2.Text.Trim();
                objLead1.City = txtCity.Text.Trim();
                objLead1.ZipCode = txtZipCode.Text.Trim();
                if (ddlState.Text != string.Empty)
                    objLead1.StateId = Convert.ToInt64(ddlState.SelectedItem.Value);
                if (ddlCountry.Text != string.Empty)
                    objLead1.CountryId = Convert.ToInt64(ddlCountry.SelectedItem.Value);
                objLead1.DoNotCall = Convert.ToBoolean(chkDoNotCall.Value);
                objLead1.IsCompany = Convert.ToBoolean(chkIsCompany.Value);
                objLead1.CreatedBy = Convert.ToInt64(ViewState["CreatedBy"]);
                objLead1.Createddate = Convert.ToDateTime(ViewState["CreatedDate"]);
                objLead1.ModifiedDate = DateTime.Now;
                objLead1.ModifiedBy = SessionData.UserId;
                objLead1.GTalk = txtGtalk.Text;
                objLead1.Yahoo = txtYahoo.Text;
                objLead1.Skype = txtSkype.Text;
                objLead1.Aim = txtAim.Text;
                objLead1.Icq = txtIcq.Text;
                objLead1.Msn = txtMsn.Text;
                objLead1.IsClient = Convert.ToBoolean(chkIsClient.Value);
                objLead1.IsProspect = Convert.ToBoolean(chkIsProspect.Value);
                objLead1.Email2 = txtEmail2.Text;
                objLead1.Email3 = txtEmail3.Text;
                //update database
                objLead1.Update();
                //clear all the input field of the popup
                clearAll();
                //refresh the page
                BindPage();
                Helper.ShowMessage(ref lblStatus, "Update Succseesfully", MessageType.Success);
                pcAddNewRecord.ShowOnPageLoad = false;
            }
        }
        /// <summary>
        /// Clear the input fields of popup
        /// </summary>
        public void clearAll()
        {
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtContactPerson.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobile1.Text = string.Empty;
            txtMobile2.Text = string.Empty;
            txtPhone1.Text = string.Empty;
            txtPhone1Ext.Text = string.Empty;
            txtPhone2.Text = string.Empty;
            txtPhone2Ext.Text = string.Empty;
            txtWebsite.Text = string.Empty; txtZipCode.Text = string.Empty;
            ddlCountry.Text = string.Empty;
            ddlDesignation.Text = string.Empty;
            ddlCountry.Text = string.Empty;
            ddlState.Text = string.Empty;
            chkDoNotCall.Checked = false;
            chkIsCompany.Checked = false;
            txtGtalk.Text = string.Empty;
            txtSkype.Text = string.Empty;
            txtYahoo.Text = string.Empty;
            txtAim.Text = string.Empty;
            txtIcq.Text = string.Empty;
            txtMsn.Text = string.Empty;
            chkIsClient.Checked = false;
            chkIsProspect.Checked = false;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Bind Page Detail
        /// </summary>
        private void BindPage()
        {
            // Bind Lead related data
            clsLead objLead = new clsLead();
            DataSet dsLead = objLead.SelectAll(Convert.ToInt64(ddlSearchCountry.SelectedItem.Value));
            gvLeadList.SettingsPager.PageSize = Convert.ToInt32(AppSetting.GetSetting("GridPageSize", AppSettingCategory.General));
            gvLeadList.DataSource = dsLead;
            gvLeadList.DataBind();
        }
        /// <summary>
        /// This function is fired when Items in Country dropdown list is selected
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void CmbState_Callback(object source, CallbackEventArgsBase e)
        {
            Common objCommon = new Common();
            //Fill State Dropdownlist accordint to country id
            objCommon.FillState(ref ddlState, Convert.ToInt64(e.Parameter));
        }
        /// <summary>
        /// Bind Popup control 
        /// </summary>
        private void Bindpopup(Int64 leadId)
        {
            //Fill DropDownlists
            Common objCommon = new Common();
            //Fill Country Dropdownlist
            objCommon.FillCountry(ref ddlCountry, false);

            //Fill Designation Dropdownlist
            objCommon.FillDesignation(ref ddlDesignation, true);
            //bind popup
            clsLead objLead = new clsLead(leadId);
            lblMaxLeadId.Text = objLead.LeadId.ToString();
            txtCompanyName.Text = objLead.CompanyName;
            txtContactPerson.Text = objLead.ContactPerson;
            txtEmail.Text = objLead.Email;
            txtWebsite.Text = objLead.WebSite;
            txtPhone1.Text = objLead.PhoneNo1;
            txtPhone2.Text = objLead.PhoneNo2;
            txtPhone1Ext.Text = objLead.PhoneNo1Ext;
            txtPhone2Ext.Text = objLead.PhoneNo2Ext;
            txtMobile1.Text = objLead.MobileNo1;
            txtMobile2.Text = objLead.MobileNo2;
            txtCity.Text = objLead.City;
            txtZipCode.Text = objLead.ZipCode;
            txtAddress1.Text = objLead.Address1;
            txtAddress2.Text = objLead.Address2;
            chkDoNotCall.Value = objLead.DoNotCall;
            chkIsCompany.Value = objLead.IsCompany;
            txtGtalk.Text = objLead.GTalk;
            txtYahoo.Text = objLead.Yahoo;
            txtSkype.Text = objLead.Skype;
            txtAim.Text = objLead.Aim;
            txtIcq.Text = objLead.Icq;
            txtMsn.Text = objLead.Msn;
            chkIsClient.Value = objLead.IsClient;
            chkIsProspect.Value = objLead.IsCompany;
            txtEmail2.Text = objLead.Email2;
            txtEmail3.Text = objLead.Email3;

            ListEditItem listItem = ddlCountry.Items.FindByValue(objLead.CountryId.ToString());
            if (listItem != null)
                listItem.Selected = true;


            //Fill State Dropdownlist accordint to country id
            objCommon.FillState(ref ddlState, Convert.ToInt64(ddlCountry.SelectedItem.Value));

            ListEditItem listItemState = ddlState.Items.FindByValue(objLead.StateId.ToString());
            if (listItemState != null)
                listItemState.Selected = true;

            ListEditItem listItemDesignation = ddlDesignation.Items.FindByValue(objLead.DesignationId.ToString());
            if (listItemDesignation != null)
                listItemDesignation.Selected = true;

            pcAddNewRecord.ShowOnPageLoad = true;
            //set mode to update
            ViewState["Insert_status"] = "update";

        }
        #endregion



    }
}