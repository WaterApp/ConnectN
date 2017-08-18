using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseAppAdmin.DataModel
{
   public class AdminDataModel
    {
        

    }
    
   public class CheckListItemData
   {
       public string ShiftID { get; set; }
       public string WardID { get; set; }
       public string Date { get; set; }
       public string UserID { get; set; }
       public List<CheckListData> CheckListDataList { get; set; }

   }

   public class KeyValuePair
   {
       public string Value { get; set; }
       public String Key { get; set; }
   }
   public class CheckListTypeContent
   {
       public string Value { get; set; }
       public string Key { get; set; }
       public int IsActive{get;set;}
   }
   public class CheckListOptions
   {
       public string CheckListOptionsID { get; set; }
       public string CheckListOptionsValue { get; set; }
       //public string isDeleted { get; set; }
       //public string UserID { get; set; }
   }

    
   public class CheckListData
   {
       public string CheckListDataID { get; set; }
       public string CheckListDataItemID { get; set; }
       public string CheckListDatavalue { get; set; }
   }

   public class CheckListOptionsContext
   {
       public string CheckListOptionsID { get; set; }
       public string CheckListOptionsValue { get; set; }
       public string CheckListOptionGroupID { get; set; }
       public string isDeleted { get; set; }
       public string UserID { get; set; }
   }

   public class CheckListItem
   {
       public string ChecklistItemId { get; set; }
       public string CheckListItemName { get; set; }
       public string ChecklistType { get; set; }
       
       public string CheckListControlType { get; set; }
       public string isActive { get; set; }
       public string UserID { get; set; }
       public string OptionData { get; set; }

       
      /* public CheckListItemOptions OptionData { get; set; }*/
   }


   public class CheckListItemOptions
   {
       public string CheckListOptionsID { get; set; }
       public string CheckListOptionsValue { get; set; }       
   }

   public class CheckListItemAndData
   {
       public int CheckListItemId { get; set; }
       public String CheckListItemName { get; set; }
       public String ChecklistType { get; set; }
       public String ControlType { get; set; }
       public String IsActive { get; set; }
       public List<KeyValuePair> CheckListData { get; set; }
       public List<CheckListOptions> Options { get; set; }

       //public string CheckListData { get; set; }
   }

   public class ConfigHeaderContext
   {
       public int configID { get; set; }
       public string configName { get; set; }
       public int isActive { get; set; }
       public int userID { get; set; }
   }

   public class WardMapping
   {
       public string Type { get; set; }
       public string WardID { get; set; }
   }

   public class CheckListWardMapping
   {
       public int CheckListMapID { get; set; }
       public int CheckListItemID { get; set; }
       public int Isdeleted { get; set; }
       public int orderNo { get; set; }
   }


   public class WardMappingData
   {
       public string WardID { get; set; }
       public string UserID { get; set; }
       public List<CheckListWardMapping> data { get; set; }
   }
}
