using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace QuanLyKho_17Dh110194.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Report")]
    [DefaultProperty("TenNhomVatTu")]
    [XafDisplayName("Nhóm vật tư")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class NhomVatTu : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public NhomVatTu(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue("PersistentProperty", ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
        string tenNhomVatTu;
        [RuleRequiredField(DefaultContexts.Save, CustomMessageTemplate = "Bắt buộc nhập Tên nhóm vật tư.")]
        [RuleUniqueValue(DefaultContexts.Save, CustomMessageTemplate = "Tên nhóm vật tư phải là duy nhất, không trùng lặp.")]
        [XafDisplayName("Tên nhóm vật tư")]
        [DetailViewLayout("Thông tin cơ bản", 0)]
        public string TenNhomVatTu
        {
            get
            {
                return tenNhomVatTu;
            }
            set
            {
                SetPropertyValue(nameof(TenNhomVatTu), ref tenNhomVatTu, value);
            }
        }
    }
    
    
}