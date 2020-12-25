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
    [XafDisplayName("Xuất vật tư")]
    public class XuatVatTu : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public XuatVatTu(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        protected override void OnSaving()
        {
            if (MaLo != null && MaLo.MaVatTu != null)
            {
                MaVatTu = MaLo.MaVatTu;
            }
            base.OnSaving();
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
        NhapVatTu maLo;

        [XafDisplayName("Chọn Mã lô")]
        [DetailViewLayout("Thông tin cơ bản", 0)]
        public NhapVatTu MaLo
        {
            get
            {
                return maLo;
            }
            set
            {
                SetPropertyValue(nameof(MaLo), ref maLo, value);
            }
        }
        DanhMucVatTu maVatTu;
        [ModelDefault("AllowEdit", "False")]
        [Association("DanhMucVatTu-XuatVatTu")]
        [XafDisplayName("Mã vật tư")]
        [DetailViewLayout("Thông tin cơ bản", 0)]
        public DanhMucVatTu MaVatTu
        {
            get
            {
                if (MaLo != null && MaLo.MaVatTu != null)
                {
                    maVatTu = MaLo.MaVatTu;
                }
                return maVatTu;
            }
            set
            {
                SetPropertyValue(nameof(MaVatTu), ref maVatTu, value);
            }
        }
        string tenVatTu;
        [ModelDefault("AllowEdit", "False")]
        [XafDisplayName("Tên vật tư")]
        [DetailViewLayout("Thông tin cơ bản", 0)]
        public string TenVatTu
        {
            get
            {
                if (MaVatTu != null)
                {
                    tenVatTu = MaVatTu.TenVatTu;
                }
                return tenVatTu;
            }
            set
            {
                SetPropertyValue(nameof(TenVatTu), ref tenVatTu, value);
            }
        }
        double soLuong;
        [XafDisplayName("Số lượng")]
        [DetailViewLayout("Thông tin cơ bản", 0)]
        public double SoLuong
        {
            get
            {
                return soLuong;
            }
            set
            {
                SetPropertyValue(nameof(SoLuong), ref soLuong, value);
            }
        }
    }
}