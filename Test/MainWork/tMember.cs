//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MainWork
{
    using System;
    using System.Collections.Generic;
    
    public partial class tMember
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tMember()
        {
            this.tAlbums = new HashSet<tAlbum>();
            this.tPurchaseItems = new HashSet<tPurchaseItem>();
            this.tShoppingCarts = new HashSet<tShoppingCart>();
        }
    
        public string fAccount { get; set; }
        public string fPassword { get; set; }
        public string fEmail { get; set; }
        public Nullable<int> fPrivilege { get; set; }
        public string fNickName { get; set; }
        public Nullable<decimal> fMoney { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAlbum> tAlbums { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPurchaseItem> tPurchaseItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tShoppingCart> tShoppingCarts { get; set; }
    }
}
