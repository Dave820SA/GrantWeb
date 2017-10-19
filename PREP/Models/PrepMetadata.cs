using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PREP.Models
{

    [MetadataType(typeof(PrepEvent.Metadata))]
    public partial class PrepEvent
    {
        sealed class Metadata
        {
            [Key]
            [Display(Name = "ID")]
            public int EventID { get; set; }

            [Required]
            [Display(Name = "Event")]
            public string Subject { get; set; }

            [Display(Name = "Description")]
            public string Description { get; set; }

            [Required]
            [Display(Name = "Event Start")]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm}")]
            public string Start { get; set; }

            [Display(Name = "Event End")]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm}")]
            public string End { get; set; }

            [Display(Name = "# Presentations")]
            public string Presentation { get; set; }

            [Display(Name = "Media Exposure")]
            public string Exposure { get; set; }

            [Display(Name = "# Community Events")]
            public string ComEvent { get; set; }

            [Display(Name = "# In Attendance")]
            public string Attend { get; set; }

            [Display(Name = "Entered By")]
            public string EnteredBy { get; set; }

            [Display(Name = "Date Entered")]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
            public string EnteredDate { get; set; }

            [Display(Name = "Full Day")]
            public string IsFullDay { get; set; }

            [Display(Name = "Event Color")]
            public string ThemeColor { get; set; }

        }
    }

    
    [MetadataType(typeof(Asset.Metadata))]
    public partial class Asset
    {
        sealed class Metadata
        {
            [Key]
            [Display(Name = "ID")]
            public int AssetID { get; set; }

            [Required]
            [Display(Name = "EventID")]
            public int EventID { get; set; }


            [Display(Name = "AssetID")]
            public int AssetTypeID { get; set; }

        }
    }


    [MetadataType(typeof(AssetType.Metadata))]
    public partial class AssetType
    {
        sealed class Metadata
        {
            [Key]
            [Display(Name = "ID")]
            public int AssetTypeID { get; set; }

            [Required]
            [Display(Name = "Asset Item")]
            public int Asset { get; set; }


            [Display(Name = "Picture")]
            public int PicturePath { get; set; }   

        }
    }

    [MetadataType(typeof(Promo.Metadata))]
    public partial class Promo
    {
        sealed class Metadata
        {
            [Key]
            [Display(Name = "ID")]
            public int PromoID { get; set; }

            [Required]
            [Display(Name = "EventID")]
            public int EventID { get; set; }


            [Display(Name = "PromoID")]
            public int TypeID { get; set; }

        }
    }

    [MetadataType(typeof(PromoType.Metadata))]
    public partial class PromoType
    {
        sealed class Metadata
        {
            [Key]
            [Display(Name = "ID")]
            public int PromoTypeID { get; set; }

            [Required]
            [Display(Name = "Promo Item")]
            public int Type { get; set; }


        }
    }


    [MetadataType(typeof(Target.Metadata))]
    public partial class Target
    {
        sealed class Metadata
        {
            [Key]
            [Display(Name = "ID")]
            public int TargetID { get; set; }

            [Required]
            [Display(Name = "EventID")]
            public int EventID { get; set; }


            [Display(Name = "TargetID")]
            public int TypeID { get; set; }

        }
    }

    [MetadataType(typeof(TargetType.Metadata))]
    public partial class TargetType
    {
        sealed class Metadata
        {
            [Key]
            [Display(Name = "ID")]
            public int TargetTypeID { get; set; }

            [Required]
            [Display(Name = "Target Aud")]
            public int Type { get; set; }


        }
    }
}