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
    [DefaultProperty("MaVatTu")]
    [XafDisplayName("Danh mục Vật tư")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class DanhMucVatTu : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public DanhMucVatTu(Session session)
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
        string maVatTu;
        string tenVatTu;
        [RuleRequiredField(DefaultContexts.Save, CustomMessageTemplate ="Bắt buộc nhập Mã vật tư.")]
        [RuleUniqueValue(DefaultContexts.Save, CustomMessageTemplate ="Mã vật tư phải là duy nhất, không trùng lặp.")]
        [XafDisplayName("Mã vật tư")]
        [DetailViewLayout("Thông tin cơ bản", 0)]
        public string MaVatTu
        {
            get
            {
                return maVatTu;
            }
            set
            {
                SetPropertyValue(nameof(MaVatTu), ref maVatTu, value);
            }
        }
        [XafDisplayName("Tên vật tư")]
        [DetailViewLayout("Thông tin cơ bản", 0)]
        public string TenVatTu
        {
            get
            {
                return tenVatTu;
            }
            set
            {
                SetPropertyValue(nameof(TenVatTu), ref tenVatTu, value);
            }
        }

        NhomVatTu nhomVatTu;
        [XafDisplayName("Nhóm vật tư")]
        [DetailViewLayout("Thông tin cơ bản", 0)]
        public NhomVatTu NhomVatTu
        {
            get
            {
                return nhomVatTu;
            }
            set
            {
                SetPropertyValue(nameof(NhomVatTu), ref nhomVatTu, value);
            }
        }
        double tongNhap;
        [ModelDefault("AllowEdit", "False")]
        [XafDisplayName("Tổng nhập")]
        [DetailViewLayout("Thông tin cơ bản", 0)]
        public double TongNhap
        {
            get
            {
                if (NhapVatTu.Count > 0)
                {
                    tongNhap = NhapVatTu.Sum(a => a.SoLuong);
                }
                return tongNhap;
            }
            set
            {
                SetPropertyValue(nameof(TongNhap), ref tongNhap, value);
            }
        }
        double tongXuat;
        [ModelDefault("AllowEdit", "False")]
        [XafDisplayName("Tổng xuất")]
        [DetailViewLayout("Thông tin cơ bản", 0)]
        public double TongXuat
        {
            get
            {
                if (XuatVatTu.Count > 0)
                {
                    tongXuat = XuatVatTu.Sum(a => a.SoLuong);
                }
                return tongXuat;
            }
            set
            {
                SetPropertyValue(nameof(TongXuat), ref tongXuat, value);
            }
        }
        double tongTon;
        [ModelDefault("AllowEdit", "False")]
        [XafDisplayName("Tổng tồn")]
        [DetailViewLayout("Thông tin cơ bản", 0)]
        public double TongTon
        {
            get
            {
                tongTon = TongNhap - TongXuat;
                return tongTon;
            }
            set
            {
                SetPropertyValue(nameof(TongTon), ref tongTon, value);
            }
        }
        [XafDisplayName("Nhập vật tư")]
        [Association("DanhMucVatTu-NhapVatTu")]
        public XPCollection<NhapVatTu> NhapVatTu
        {
            get
            {
                return GetCollection<NhapVatTu>(nameof(NhapVatTu));
            }
        }
        [XafDisplayName("Xuất vật tư")]
        [Association("DanhMucVatTu-XuatVatTu")]
        public XPCollection<XuatVatTu> XuatVatTu
        {
            get
            {
                return GetCollection<XuatVatTu>(nameof(XuatVatTu));
            }
        }
    }
}